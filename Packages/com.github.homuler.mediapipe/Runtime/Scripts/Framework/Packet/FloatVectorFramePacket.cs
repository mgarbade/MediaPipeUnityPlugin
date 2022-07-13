// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediapipe
{
  public class FloatVectorFramePacket : Packet<List<float>>
  {
    /// <summary>
    ///   Creates an empty <see cref="FloatVectorFramePacket" /> instance.
    /// </summary>
    /// 

    private int _vectorLength;


    public FloatVectorFramePacket() : base(true) { }

    [UnityEngine.Scripting.Preserve]
    public FloatVectorFramePacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

    public FloatVectorFramePacket(float[] value) : base()
    {
      UnsafeNativeMethods.mp__MakeFloatVectorFramePacket__PA_i(value, value.Length, out var ptr).Assert();
      this.ptr = ptr;
      _vectorLength = value.Length;
      //throw new NotImplementedException();
    }

    public FloatVectorFramePacket(float[] value, Timestamp timestamp) : base()
    {
      UnsafeNativeMethods.mp__MakeFloatVectorFramePacket_At__PA_i_Rt(value, value.Length, timestamp.mpPtr, out var ptr).Assert();
      GC.KeepAlive(timestamp);
      this.ptr = ptr;
      //throw new NotImplementedException();
    }

    public FloatVectorFramePacket At(Timestamp timestamp)
    {
      return At<FloatVectorFramePacket>(timestamp);
    }

    public override List<float> Get()
    {
      if (_vectorLength < 0)
      {
        throw new InvalidOperationException("The array's length is unknown, set Length first");
      }

      var result = new float[_vectorLength];

      unsafe
      {
        var src = (float*)GetArrayPtr();

        for (var i = 0; i < result.Length; i++)
        {
          result[i] = *src++;
        }
      }

      return result.ToList();
    }

    public IntPtr GetArrayPtr()
    {
      UnsafeNativeMethods.mp_Packet__GetFloatVectorFrame(mpPtr, out var floatFrameVector).Assert();
      GC.KeepAlive(this);

      return floatFrameVector;
    }

    public override StatusOr<List<float>> Consume()
    {
      throw new NotSupportedException();
    }
  }
}
