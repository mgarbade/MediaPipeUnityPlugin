using System;

namespace Mediapipe {
  public class RectPacket : Packet<Rect> {
    public RectPacket() : base() {}
    public RectPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) {}

    public override Rect Get() {
      UnsafeNativeMethods.mp_Packet__GetRect(mpPtr, out var serializedProto).Assert();
      GC.KeepAlive(this);

      var rect = serializedProto.Deserialize(Rect.Parser);
      serializedProto.Dispose();

      return rect;
    }

    public override StatusOr<Rect> Consume() {
      throw new NotSupportedException();
    }
  }
}
