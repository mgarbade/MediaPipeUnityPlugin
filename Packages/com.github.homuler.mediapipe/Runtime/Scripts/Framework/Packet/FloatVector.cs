// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Mediapipe
{
  [StructLayout(LayoutKind.Sequential)]
  internal struct FloatVector
  {
    public IntPtr data;
    public int size;

    public void Dispose()
    {
      UnsafeNativeMethods.mp_FloatVectorFrame__delete(data);
    }

    public List<float> ToList()
    {
      var anchors = new List<float>(size);

      unsafe
      {
        var anchorPtr = (float*)data;

        for (var i = 0; i < size; i++)
        {
          anchors.Add(Marshal.PtrToStructure<float>((IntPtr)anchorPtr++));
        }
      }

      return anchors;
    }
  }
}
