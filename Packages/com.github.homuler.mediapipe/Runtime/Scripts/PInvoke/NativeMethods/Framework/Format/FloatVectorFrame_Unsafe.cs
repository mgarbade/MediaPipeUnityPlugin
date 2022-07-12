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
  internal static partial class UnsafeNativeMethods
  {
    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_FloatVectorFrame__(out IntPtr floatVectorFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_FloatVectorFrame__ui_i_i_ui(
    //    ImageFormat.Types.Format format, int width, int height, uint alignmentBoundary, out IntPtr floatVectorFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_FloatVectorFrame__ui_i_i_i_Pui8_PF(
    //    ImageFormat.Types.Format format, int width, int height, int widthStep, IntPtr pixelData,
    //    [MarshalAs(UnmanagedType.FunctionPtr)] FloatVectorFrame.Deleter deleter, out IntPtr floatVectorFrame);

    [DllImport(MediaPipeLibrary, ExactSpelling = true)]
    public static extern void mp_FloatVectorFrame__delete(IntPtr floatVectorFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_FloatVectorFrame__SetToZero(IntPtr floatVectorFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_FloatVectorFrame__SetAlignmentPaddingAreas(IntPtr floatVectorFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_FloatVectorFrame__CopyToBuffer__Pui8_i(IntPtr floatVectorFrame, IntPtr buffer, int bufferSize);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_FloatVectorFrame__CopyToBuffer__Pui16_i(IntPtr floatVectorFrame, IntPtr buffer, int bufferSize);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_FloatVectorFrame__CopyToBuffer__Pf_i(IntPtr floatVectorFrame, IntPtr buffer, int bufferSize);

    #region StatusOr
    [DllImport(MediaPipeLibrary, ExactSpelling = true)]
    public static extern void mp_StatusOrFloatVectorFrame__delete(IntPtr statusOrFloatVectorFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_StatusOrFloatVectorFrame__status(IntPtr statusOrFloatVectorFrame, out IntPtr status);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_StatusOrFloatVectorFrame__value(IntPtr statusOrFloatVectorFrame, out IntPtr floatVectorFrame);
    #endregion

    #region Packet
    // [DllImport(MediaPipeLibrary, ExactSpelling = true)]
    // public static extern MpReturnCode mp__MakeFloatVectorFramePacket__PKc_i(byte[] serializedMatrixData, int size, out IntPtr packet_out);

    // [DllImport(MediaPipeLibrary, ExactSpelling = true)]
    // public static extern MpReturnCode mp__MakeFloatVectorFramePacket_At__PA_i_Rt(byte[] serializedMatrixData, int size, IntPtr timestamp, out IntPtr packet_out);

    // [DllImport(MediaPipeLibrary, ExactSpelling = true)]
    // public static extern MpReturnCode mp_Packet__ConsumeFloatVectorFrame(IntPtr packet, out IntPtr statusOrFloatVectorFrame);

    [DllImport(MediaPipeLibrary, ExactSpelling = true)]
    public static extern MpReturnCode mp_Packet__GetFloatVectorFrame(IntPtr packet, out List<float> floatVectorFrame);

    // [DllImport(MediaPipeLibrary, ExactSpelling = true)]
    // public static extern MpReturnCode mp_Packet__ValidateAsFloatVectorFrame(IntPtr packet, out IntPtr status);
    #endregion
  }
}
