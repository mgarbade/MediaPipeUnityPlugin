// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Collections.Generic;
using NUnit.Framework;
using System;

namespace Mediapipe.Tests
{
  public class FloatVectorPacketTest
  {
    #region Constructor
    //    [Test, SignalAbort]
    //    public void Ctor_ShouldInstantiatePacket_When_CalledWithNoArguments()
    //    {
    //      using (var packet = new FloatPacket())
    //      {
    //#pragma warning disable IDE0058
    //        Assert.AreEqual(Status.StatusCode.Internal, packet.ValidateAsType().Code());
    //        Assert.Throws<MediaPipeException>(() => { packet.Get(); });
    //        Assert.AreEqual(Timestamp.Unset(), packet.Timestamp());
    //#pragma warning restore IDE0058
    //      }
    //    }

    [Test]
    public void Ctor_ShouldInstantiatePacket_When_CalledWithValue()
    {
      var floatVector = new List<float>(new float[6] { 10, 11, 12, 13, 14, 15 });
      using (var packet = new FloatVectorPacket(floatVector))
      {
        Assert.True(packet.ValidateAsType().Ok());
        Assert.AreEqual(floatVector, packet.Get());
        Assert.AreEqual(Timestamp.Unset(), packet.Timestamp());
      }
    }

    //[Test]
    //public void Ctor_ShouldInstantiatePacket_When_CalledWithValueAndTimestamp()
    //{
    //  using (var timestamp = new Timestamp(1))
    //  {
    //    var floatArray = new float[6] { 10, 11, 12, 13, 14, 15 };
    //    using (var packet = new FloatPacket(floatArray, timestamp))
    //    {
    //      Assert.True(packet.ValidateAsType().Ok());
    //      Assert.AreEqual(0.01f, packet.Get());
    //      Assert.AreEqual(timestamp, packet.Timestamp());
    //    }
    //  }
    //}
    #endregion

    #region #isDisposed
    [Test]
    public void IsDisposed_ShouldReturnFalse_When_NotDisposedYet()
    {
      using (var packet = new FloatVectorPacket())
      {
        Assert.False(packet.isDisposed);
      }
    }

    [Test]
    public void IsDisposed_ShouldReturnTrue_When_AlreadyDisposed()
    {
      var packet = new FloatVectorPacket();
      packet.Dispose();

      Assert.True(packet.isDisposed);
    }
    #endregion

    #region #At
    [Test]
    public void At_ShouldReturnNewPacketWithTimestamp()
    {
      using (var timestamp = new Timestamp(1))
      {
        var floatVector = new List<float>(new float[6] { 10, 11, 12, 13, 14, 15 });
        var packet = new FloatVectorPacket(floatVector).At(timestamp);
        Assert.AreEqual(floatVector, packet.Get());
        Assert.AreEqual(timestamp, packet.Timestamp());

        using (var newTimestamp = new Timestamp(2))
        {
          var newPacket = packet.At(newTimestamp);
          Assert.AreEqual(floatVector, newPacket.Get());
          Assert.AreEqual(newTimestamp, newPacket.Timestamp());
        }

        Assert.AreEqual(timestamp, packet.Timestamp());
      }
    }
    #endregion

    #region #Consume
    [Test]
    public void Consume_ShouldThrowNotSupportedException()
    {
      using (var packet = new FloatVectorPacket())
      {
#pragma warning disable IDE0058
        Assert.Throws<NotSupportedException>(() => { packet.Consume(); });
#pragma warning restore IDE0058
      }
    }
    #endregion

    // #region #DebugTypeName
    // [Test]
    // public void DebugTypeName_ShouldReturnFloat_When_ValueIsSet()
    // {
    //   using (var packet = new FloatPacket(0.01f))
    //   {
    //     Assert.AreEqual("float", packet.DebugTypeName());
    //   }
    // }
    // #endregion
  }
}
