using System;

public class LoginRequestPacket : Packet<LoginRequestData, LoginRequestSerializer>
{
	// constructor - packet data
	public LoginRequestPacket( LoginRequestData data )
	{
		// allocate serialier
		serializer = new LoginRequestSerializer();

		// allocate data
		dataElement = data;
	}

	// constructor - byte stream
	public LoginRequestPacket( byte[] data )
	{
		// allocate serializer
		serializer = new LoginRequestSerializer();
		serializer.SetDeserializedData( data );

		// allocate data
		dataElement = new LoginRequestData();

		// deserialize data
		serializer.Deserialize( ref dataElement );
	}

	// return data set
	public override LoginRequestData GetData()
	{
		return dataElement;
	}

	// return packet data -> packet id
	public override int GetPacketID()
	{
		return (int) ClientToServerPacket.LoginRequest;
	}

	// return packet data -> byte stream data section
	public override byte[] GetPacketData()
	{
		serializer.Serialize( dataElement );

		return serializer.GetSerializeData();
	}
}