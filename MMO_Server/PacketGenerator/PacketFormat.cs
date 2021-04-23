﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PacketGenerator
{
	class PacketFormat
	{
		// {0} Packet Asign
		public static string managerFormat =
@"using ServerCore;
using System;
using System.Collections.Generic;

public class PacketManager
{{
	#region Singleton
	static PacketManager _instance = new PacketManager();
	public static PacketManager Instance {{ get {{ return _instance; }} }}
	#endregion

	PacketManager()
	{{
		Register();
	}}

	Dictionary<ushort, Func<PacketSession, ArraySegment<byte>, IPacket>> _makeFunc = new Dictionary<ushort, Func<PacketSession, ArraySegment<byte>, IPacket>>();
	Dictionary<ushort, Action<PacketSession, IPacket>> _handler = new Dictionary<ushort, Action<PacketSession, IPacket>>();
		
	public void Register()
	{{
{0}
	}}

	public void OnRecvPacket(PacketSession session, ArraySegment<byte> buffer, Action<PacketSession, IPacket> onRecvCallback = null)
	{{
		ushort count = 0;

		ushort size = BitConverter.ToUInt16(buffer.Array, buffer.Offset);
		count += 2;
		ushort id = BitConverter.ToUInt16(buffer.Array, buffer.Offset + count);
		count += 2;

		Func<PacketSession, ArraySegment<byte>, IPacket> func = null;
		if (_makeFunc.TryGetValue(id, out func))
        {{
			IPacket packet = func.Invoke(session, buffer);
			if (onRecvCallback != null)
				onRecvCallback.Invoke(session, packet);
			else
				HandlePacket(session, packet);
		}}
	}}

	T MakePacket<T>(PacketSession session, ArraySegment<byte> buffer) where T : IPacket, new()
	{{
		T pkt = new T();
		pkt.Read(buffer);
		return pkt;
	}}

	public void HandlePacket(PacketSession session, IPacket packet)
	{{
		Action<PacketSession, IPacket> action = null;
		if (_handler.TryGetValue(packet.Protocol, out action))
			action.Invoke(session, packet);
	}}
}}";

		// {0} Packet Name
		public static string managerRegisterFormat =
@"		_makeFunc.Add((ushort)PacketID.{0}, MakePacket<{0}>);
		_handler.Add((ushort)PacketID.{0}, PacketHandler.{0}Handler);";

		// {0} Packet Name/Number List
		// {1} Packet List
		public static string fileFormat =
@"using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ServerCore;

public enum PacketID
{{
	{0}
}}

public interface IPacket
{{
	ushort Protocol {{ get; }}
	void Read(ArraySegment<byte> segment);
	ArraySegment<byte> Write();
}}

{1}
";

		// {0} Packet Name
		// {1} Packet Number
		public static string packetEnumFormat =
@"{0} = {1},";


		// {0} Packet Name
		// {1} Member Variable
		// {2} Member Variable Read
		// {3} Member Variable Write
		public static string packetFormat =
@"
public class {0} : IPacket
{{
	{1}

	public ushort Protocol {{ get {{ return (ushort)PacketID.{0}; }} }}

	public void Read(ArraySegment<byte> segment)
	{{
		ushort count = 0;

		count += sizeof(ushort);
		count += sizeof(ushort);
		{2}
	}}

	public ArraySegment<byte> Write()
	{{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		ushort count = 0;

		count += sizeof(ushort);
		Array.Copy(BitConverter.GetBytes((ushort)PacketID.{0}), 0, segment.Array, segment.Offset + count, sizeof(ushort));
		count += sizeof(ushort);
		{3}

		Array.Copy(BitConverter.GetBytes(count), 0, segment.Array, segment.Offset, sizeof(ushort));

		return SendBufferHelper.Close(count);
	}}
}}
";
		// {0} Variable Type
		// {1} Variable Name
		public static string memberFormat =
@"public {0} {1};";

		// {0} List Name [Capital]
		// {1} List Name [small]
		// {2} Member Variables
		// {3} Member Variable Read
		// {4} Member Variable Write
		public static string memberListFormat =
@"public class {0}
{{
	{2}

	public void Read(ArraySegment<byte> segment, ref ushort count)
	{{
		{3}
	}}

	public bool Write(ArraySegment<byte> segment, ref ushort count)
	{{
		bool success = true;
		{4}
		return success;
	}}	
}}
public List<{0}> {1}s = new List<{0}>();";

		// {0} Variable Name
		// {1} To~ Variable Type
		// {2} Variable Type
		public static string readFormat =
@"this.{0} = BitConverter.{1}(segment.Array, segment.Offset + count);
count += sizeof({2});";

		// {0} Variable Name
		// {1} Variable Type
		public static string readByteFormat =
@"this.{0} = ({1})segment.Array[segment.Offset + count];
count += sizeof({1});";

		// {0} Variable Name
		public static string readStringFormat =
@"ushort {0}Len = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
count += sizeof(ushort);
this.{0} = Encoding.Unicode.GetString(segment.Array, segment.Offset + count, {0}Len);
count += {0}Len;";

		// {0} List Name [Capital]
		// {1} List Name [small]
		public static string readListFormat =
@"this.{1}s.Clear();
ushort {1}Len = BitConverter.ToUInt16(segment.Array, segment.Offset + count);
count += sizeof(ushort);
for (int i = 0; i < {1}Len; i++)
{{
	{0} {1} = new {0}();
	{1}.Read(segment, ref count);
	{1}s.Add({1});
}}";

		// {0} Variable Name
		// {1} Variable Type
		public static string writeFormat =
@"Array.Copy(BitConverter.GetBytes(this.{0}), 0, segment.Array, segment.Offset + count, sizeof({1}));
count += sizeof({1});";

		// {0} Variable Name
		// {1} Variable Type
		public static string writeByteFormat =
@"segment.Array[segment.Offset + count] = (byte)this.{0};
count += sizeof({1});";

		// {0} Variable Name
		public static string writeStringFormat =
@"ushort {0}Len = (ushort)Encoding.Unicode.GetBytes(this.{0}, 0, this.{0}.Length, segment.Array, segment.Offset + count + sizeof(ushort));
Array.Copy(BitConverter.GetBytes({0}Len), 0, segment.Array, segment.Offset + count, sizeof(ushort));
count += sizeof(ushort);
count += {0}Len;";

		// {0} List Name [Capital]
		// {1} List Name [small]
		public static string writeListFormat =
@"Array.Copy(BitConverter.GetBytes((ushort)this.{1}s.Count), 0, segment.Array, segment.Offset + count, sizeof(ushort));
count += sizeof(ushort);
foreach ({0} {1} in this.{1}s)
	{1}.Write(segment, ref count);";

	}
}
