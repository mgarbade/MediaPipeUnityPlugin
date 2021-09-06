using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Mediapipe.Unity.ObjectDetection {
  public class ObjectDetectionGraph : GraphRunner {
    public UnityEvent<List<Detection>> OnOutputDetectionsOutput = new UnityEvent<List<Detection>>();

    const string inputStreamName = "input_video";

    const string outputDetectionsStreamName = "output_detections";
    OutputStreamPoller<List<Detection>> outputDetectionsStreamPoller;
    DetectionVectorPacket outputDetectionsPacket;
    protected long prevOutputDetectionsMicrosec = 0;

    public override Status StartRun(ImageSource imageSource) {
      outputDetectionsStreamPoller = calculatorGraph.AddOutputStreamPoller<List<Detection>>(outputDetectionsStreamName, true).Value();
      outputDetectionsPacket = new DetectionVectorPacket();

      return calculatorGraph.StartRun(BuildSidePacket(imageSource));
    }

    public Status StartRunAsync(ImageSource imageSource) {
      calculatorGraph.ObserveOutputStream(outputDetectionsStreamName, OutputDetectionsCallback, true).AssertOk();
      return calculatorGraph.StartRun(BuildSidePacket(imageSource));
    }

    public override void Stop() {
      base.Stop();
      OnOutputDetectionsOutput.RemoveAllListeners();
    }

    public Status AddTextureFrameToInputStream(TextureFrame textureFrame) {
      return AddTextureFrameToInputStream(inputStreamName, textureFrame);
    }

    public List<Detection> FetchNextDetections() {
      var detections = FetchNextVector<Detection>(outputDetectionsStreamPoller, outputDetectionsPacket, outputDetectionsStreamName);
      OnOutputDetectionsOutput.Invoke(detections);
      return detections;
    }

    [AOT.MonoPInvokeCallback(typeof(CalculatorGraph.NativePacketCallback))]
    static IntPtr OutputDetectionsCallback(IntPtr graphPtr, IntPtr packetPtr){
      try {
        var isFound = TryGetGraphRunner(graphPtr, out var graphRunner);
        if (!isFound) {
          return Status.FailedPrecondition("Graph runner is not found").mpPtr;
        }
        using (var packet = new DetectionVectorPacket(packetPtr, false)) {
          var objectDetectionGraph = (ObjectDetectionGraph)graphRunner;
          if (objectDetectionGraph.TryGetPacketValue(packet, ref objectDetectionGraph.prevOutputDetectionsMicrosec, out var value)) {
            objectDetectionGraph.OnOutputDetectionsOutput.Invoke(value);
          }
        }
        return Status.Ok().mpPtr;
      } catch (Exception e) {
        return Status.FailedPrecondition(e.ToString()).mpPtr;
      }
    }

    protected override void PrepareDependentAssets() {
      AssetLoader.PrepareAsset("ssdlite_object_detection_labelmap.txt");
      AssetLoader.PrepareAsset("ssdlite_object_detection.bytes");
    }

    SidePacket BuildSidePacket(ImageSource imageSource) {
      var sidePacket = new SidePacket();

      // Coordinate transformation from Unity to MediaPipe
      if (imageSource.isMirrored) {
        sidePacket.Emplace("input_rotation", new IntPacket(180));
        sidePacket.Emplace("input_vertically_flipped", new BoolPacket(false));
      } else {
        sidePacket.Emplace("input_rotation", new IntPacket(0));
        sidePacket.Emplace("input_vertically_flipped", new BoolPacket(true));
      }

      return sidePacket;
    }
  }
}
