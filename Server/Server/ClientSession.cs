using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ServerCore;

namespace Server
{
    public abstract class Packet
    {
        public ushort size;
        public ushort packetId;

        public abstract ArraySegment<byte> Write();
        public abstract void Read(ArraySegment<byte> s);

    }

    class PlayerInfoReq : Packet
    {
        public long playerId;
        public string name;

        public PlayerInfoReq()
        {
            this.packetId = (ushort)PacketID.PlayerInfoReq;
        }

        public override void Read(ArraySegment<byte> segment)
        {
            ushort count = 0;

            ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);

            count += sizeof(ushort);
            count += sizeof(ushort);
            this.playerId = BitConverter.ToUInt16(s.Slice(count, s.Length - count));
            count += sizeof(long);

            ushort nameLen = BitConverter.ToUInt16(s.Slice(count, s.Length - count));
            count += sizeof(ushort);
            this.name = Encoding.Unicode.GetString(s.Slice(count, nameLen));
        }

        public override ArraySegment<byte> Write()
        {
            ArraySegment<byte> segment = SendBufferHelper.Open(4096);

            ushort count = 0;
            bool success = true;

            Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

            count += sizeof(ushort);
            success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.packetId);
            count += sizeof(ushort);
            success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.playerId);
            count += sizeof(long);

            ushort nameLen = (ushort)Encoding.Unicode.GetByteCount(this.name);
            success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), nameLen);
            count += sizeof(ushort);
            Array.Copy(Encoding.Unicode.GetBytes(this.name), 0, segment.Array, count, nameLen);
            count += nameLen;

            success &= BitConverter.TryWriteBytes(s, count);


            if (success == false)
                return null;

            return SendBufferHelper.Close(count);
        }
    }

    public enum PacketID
    {
        PlayerInfoReq = 1,
        PlayerInfoOk = 2,
    }

    class ClientSession : PacketSession
    {
        public override void OnConnected(EndPoint endPoint)
        {
            Console.WriteLine($"OnConnected: {endPoint}");
            Thread.Sleep(5000);
            Disconnect();
        }

        public override void OnRecvPacket(ArraySegment<byte> buffer)
        {
            ushort count = 0;
            ushort size = BitConverter.ToUInt16(buffer.Array, buffer.Offset);
            count += 2;
            ushort id = BitConverter.ToUInt16(buffer.Array, buffer.Offset + count);
            count += 2;

            switch ((PacketID)id)
            {
                case PacketID.PlayerInfoReq:
                    {
                        PlayerInfoReq p = new PlayerInfoReq();
                        p.Read(buffer);
                        Console.WriteLine($"PlaeyrInfoReq: { p.playerId } {p.name}");
                    }
                    break;

            }

            Console.WriteLine($"RecvPacketId: {id}, RecvPacketSize: {size}");
        }

        public override void OnDisconnected(EndPoint endPoint)
        {
            Console.WriteLine($"OnDisconnected: {endPoint}");
        }

        public override void OnSend(int numOfBytes)
        {
            Console.WriteLine($"Transferred bytes: {numOfBytes}");
        }
    }
}
