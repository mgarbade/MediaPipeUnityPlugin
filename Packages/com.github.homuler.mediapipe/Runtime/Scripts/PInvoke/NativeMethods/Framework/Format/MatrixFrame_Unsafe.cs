// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Runtime.InteropServices;

namespace Mediapipe
{
  internal static partial class UnsafeNativeMethods
  {
    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_MatrixFrame__(out IntPtr matrixFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_MatrixFrame__ui_i_i_ui(
    //    ImageFormat.Types.Format format, int width, int height, uint alignmentBoundary, out IntPtr matrixFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_MatrixFrame__ui_i_i_i_Pui8_PF(
    //    ImageFormat.Types.Format format, int width, int height, int widthStep, IntPtr pixelData,
    //    [MarshalAs(UnmanagedType.FunctionPtr)] MatrixFrame.Deleter deleter, out IntPtr matrixFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern void mp_MatrixFrame__delete(IntPtr matrixFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_MatrixFrame__SetToZero(IntPtr matrixFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_MatrixFrame__SetAlignmentPaddingAreas(IntPtr matrixFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_MatrixFrame__CopyToBuffer__Pui8_i(IntPtr matrixFrame, IntPtr buffer, int bufferSize);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_MatrixFrame__CopyToBuffer__Pui16_i(IntPtr matrixFrame, IntPtr buffer, int bufferSize);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_MatrixFrame__CopyToBuffer__Pf_i(IntPtr matrixFrame, IntPtr buffer, int bufferSize);

    //#region StatusOr
    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern void mp_StatusOrMatrixFrame__delete(IntPtr statusOrMatrixFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_StatusOrMatrixFrame__status(IntPtr statusOrMatrixFrame, out IntPtr status);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_StatusOrMatrixFrame__value(IntPtr statusOrMatrixFrame, out IntPtr matrixFrame);
    //#endregion

    #region Packet
    [DllImport(MediaPipeLibrary, ExactSpelling = true)]
    public static extern MpReturnCode mp__MakeMatrixFramePacket__PKc_i(byte[] serializedMatrixData, int size, out IntPtr packet_out);

    [DllImport(MediaPipeLibrary, ExactSpelling = true)]
    public static extern MpReturnCode mp__MakeMatrixFramePacket_At__PA_i_Rt(byte[] serializedMatrixData, int size, IntPtr timestamp, out IntPtr packet_out);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_Packet__ConsumeMatrixFrame(IntPtr packet, out IntPtr statusOrMatrixFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_Packet__GetMatrixFrame(IntPtr packet, out IntPtr matrixFrame);

    //[DllImport(MediaPipeLibrary, ExactSpelling = true)]
    //public static extern MpReturnCode mp_Packet__ValidateAsMatrixFrame(IntPtr packet, out IntPtr status);
    #endregion
  }
}
