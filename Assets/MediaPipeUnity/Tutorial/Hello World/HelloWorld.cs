// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Google.Protobuf;

namespace Mediapipe.Unity
{
  public class HelloWorld : MonoBehaviour
  {

    private readonly string TAG = "HelloWorldTutorial";

    private void OnEnable()
    {
      var _ = StartCoroutine(Init());
    }

    private void Start()
    {
      Debug.Log("Setup Protobuf Logging");
      Protobuf.SetLogHandler(Protobuf.DefaultLogHandler);

      Debug.Log("Start");
      var configText = @"
        input_stream: ""MATRIX:in""
        output_stream: ""FLOATS:out""

        node 
        {
          calculator: ""TfLiteConverterCalculator""
          input_stream: ""MATRIX:in""
          output_stream: ""TENSORS:image_tensor""
          options: 
          {
              [mediapipe.TfLiteConverterCalculatorOptions.ext]
              {
              zero_center: false
              }
          }
        }

        node 
        {
          calculator: ""TfLiteInferenceCalculator""
          input_stream: ""TENSORS:image_tensor""
          output_stream: ""TENSORS:tensor_features""
          options: 
          {
            [mediapipe.TfLiteInferenceCalculatorOptions.ext] 
            {
              model_path: ""mediapipe/models/adder_model_single_input_2x3.tflite""
            }
          }
        }

        node 
        {
          calculator: ""TfLiteTensorsToFloatsCalculator""
          input_stream: ""TENSORS:tensor_features""
          output_stream: ""FLOATS:out""
        }
      ";
      var graph = new CalculatorGraph(configText);
      var poller = graph.AddOutputStreamPoller<List<float>>("out").Value();

      Debug.Log("StartRun");
      graph.StartRun().AssertOk();
      for (var i = 0; i < 10; i++)
      {

        var matrix = new MatrixData();
        matrix.PackedData.Add(0);
        matrix.PackedData.Add(1);
        matrix.PackedData.Add(2);
        matrix.PackedData.Add(3);
        matrix.PackedData.Add(4);
        matrix.PackedData.Add(5);

        matrix.Rows = 2;
        matrix.Cols = 3;

        var input = new MatrixFramePacket(matrix.ToByteArray(), new Timestamp(i));
        graph.AddPacketToInputStream("in", input).AssertOk();
      }
      graph.CloseInputStream("in").AssertOk();

      Debug.Log("Poll output");


      // Create output container with suitable size
      var outputFloatArray = new float[6] { 10, 11, 12, 13, 14, 15 };
      var output = new FloatVectorFramePacket(outputFloatArray);

      while (poller.Next(output))
      {
        Debug.Log(output.Get());
      }


      graph.WaitUntilDone().AssertOk();
      graph.Dispose();

      Debug.Log("Done");
    }

    private void OnApplicationQuit()
    {
      Protobuf.ResetLogHandler();
    }

    // Load tflite model from assets
    private IList<WaitForResult> RequestDependentAssets()
    {
      return new List<WaitForResult> {
          WaitForAsset("model_ar_v18s_01_mediapipe_tflite.bytes"),
        };
    }

    private WaitForResult WaitForAsset(string assetName, bool overwrite = false)
    {
      return WaitForAsset(assetName, assetName, overwrite);
    }

    private WaitForResult WaitForAsset(string assetName, string uniqueKey, bool overwrite = false)
    {
      return new WaitForResult(this, AssetLoader.PrepareAssetAsync(assetName, uniqueKey, overwrite));
    }

    private IEnumerator Init()
    {
      Logger.LogInfo(TAG, "Loading dependent assets...");
      var assetRequests = RequestDependentAssets();
      yield return new WaitWhile(() => assetRequests.Any((request) => request.keepWaiting));

      var errors = assetRequests.Where((request) => request.isError).Select((request) => request.error).ToList();
      if (errors.Count > 0)
      {
        foreach (var error in errors)
        {
          Logger.LogError(TAG, error);
        }
        throw new InternalException("Failed to prepare dependent assets");
      }
    }

  }
}



