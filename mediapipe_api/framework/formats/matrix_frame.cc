// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

#include "mediapipe_api/framework/formats/matrix_frame.h"

MpReturnCode mp__MakeMatrixPacket__PKc_i(const char* matrix_data, int size, mediapipe::Packet** packet_out) {
  TRY
    mediapipe::Matrix matrix;

    // fill matrix with data from matrix_data
    mediapipe::MatrixFromMatrixDataProto(matrix_data, matrix);

    *packet_out = new mediapipe::Packet{mediapipe::MakePacket<mediapipe::Matrix>(matrix)};
    RETURN_CODE(MpReturnCode::Success);
  CATCH_EXCEPTION
}

MpReturnCode mp__MakeMatrixPacket_At__PA_i_Rt(const char* matrix_data, int size, mediapipe::Timestamp* timestamp,
                                                      mediapipe::Packet** packet_out) {
  TRY
    mediapipe::Matrix matrix;

    // fill matrix with data from matrix_data
    mediapipe::MatrixFromMatrixDataProto(matrix_data, matrix);

    *packet_out = new mediapipe::Packet{mediapipe::MakePacket<mediapipe::Matrix>(matrix).At(*timestamp)};
    RETURN_CODE(MpReturnCode::Success);
  CATCH_EXCEPTION
}




