using System;

public class LoginResultPacket : Packet<LoginResultData, LoginResultSerializer>
{
	// constructor - packet data
	public LoginResultPacket( LoginResultData data )
	{
		// allocate serialzier
		serializer = new LoginResultSerializer();

		// allocate data
		dataElement = data;
	}

	// constructor - byte stream
	public LoginResultPacket( byte[] data )
	{
		// allocate serializer
		serializer = new LoginResultSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new LoginResultData();

		// deserialize data
		serializer.Deserialize( ref dataElement );
	}

	// return data set
	public override LoginResultData GetData()
	{
		return dataElement;
	}

	// return packet data -> packet id
	public override int GetPacketID()
	{
		return (int) ServerToClientPacket.LoginResult;
	}

	// return packet data -> byte stream data section
	public override byte[] GetPacketData()
	{
		serializer.Serialize( dataElement );

		return serializer.GetSerializeData();
	}
}


