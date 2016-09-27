using System;

public class JoinRequestPacket : Packet<JoinRequestData, JoinRequestSerializer>
{
	// constructor - packet data
	public JoinRequestPacket( JoinRequestData data )
	{
		// allocate serialier
		serializer = new JoinRequestSerializer();
	
		// allocate data
		dataElement = data;
	}

	// constructor - byte stream
	public JoinRequestPacket( byte[] data )
	{
		// allocate serializer
		serializer = new JoinRequestSerializer();
		serializer.SetDeserializedData( data );

		// allocate data
		dataElement = new JoinRequestData();

		// deserialize data
		serializer.Deserialize( ref dataElement );
	}

	// return data set
	public override JoinRequestData GetData()
	{
		return dataElement;
	}

	// return packet data -> packet od
	public override int GetPacketID()
	{
		return (int) ClientToServerPacket.JoinRequest;
	}

	// return packet data -> byte stream data section
	public override byte[] GetPacketData()
	{
		serializer.Serialize( dataElement );

		return serializer.GetSerializeData();
	}
}