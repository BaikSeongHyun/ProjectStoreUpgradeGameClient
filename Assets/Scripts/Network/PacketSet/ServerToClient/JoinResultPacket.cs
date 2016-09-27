using System;

public class JoinResultPacket : Packet<JoinResultData, JoinResultSerializer>
{
	// constructor - packet data
	public JoinResultPacket( JoinResultData data )
	{
		// allocate serialzier
		serializer = new JoinResultSerializer();

		// allocate data
		dataElement = data;
	}

	// constructor - byte stream
	public JoinResultPacket( byte[] data )
	{
		// allocate serializer
		serializer = new JoinResultSerializer();
		serializer.SetDeserializedData( data );

		// allocate data
		dataElement = new JoinResultData();

		// deserialize data
		serializer.Deserialize( ref dataElement );
	}

	// return data set
	public override JoinResultData GetData()
	{
		return dataElement;
	}

	// return packet data -> packet id
	public override int GetPacketID()
	{
		return (int) ServerToClientPacket.JoinResult;
	}

	// return packet data -> byte stream data section 
	public override byte[] GetPacketData()
	{
		serializer.Serialize( dataElement );

		return serializer.GetSerializeData();
	}
}


