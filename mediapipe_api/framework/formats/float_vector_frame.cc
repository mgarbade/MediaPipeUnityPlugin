#include "mediapipe_api/framework/formats/float_vector_frame.h"

#include <vector>

MpReturnCode mp_Packet__GetFloatVectorFrame(mediapipe::Packet* packet, mp_api::StructArray<std::vector<float>>* value_out) {
  return mp_Packet__GetStructVector<std::vector<float>>(packet, value_out);
}

void mp_FloatVectorFrame__delete(std::vector<float>* vector_data) { delete[] vector_data; }