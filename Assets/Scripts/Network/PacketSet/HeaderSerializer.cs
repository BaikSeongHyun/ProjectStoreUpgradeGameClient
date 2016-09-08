using System;
using System.IO;

public class HeaderSerializer : Serializer
{
	// serialize packet header
	public bool Serialize( PacketHeader data )
	{
		// clear buffer
		Clear();

		// serialize element
		bool result = true;
		result &= Serialize( data.length );
		result &= Serialize( data.id );

		// failure serialize -> method exit
		if( !result )
			return false;

		// success serialize -> return result
		return true;
	}

	// deserialize packet header
	public bool Deserialize( ref PacketHeader data )
	{
		// set deserialize data
		bool result = ( GetDataSize() > 0 ) ? true : false;

		// data read failure -> method exit
		if( !result )
			return false;

		// return data initialazie
		short packetLength = 0;
		byte packetID = 0;

		// data deserialize 
		result &= Deserialize( ref packetLength );
		result &= Deserialize( ref packetID );

		// input data
		data.length = packetLength;
		data.id = packetID;

		// return result
		return result;
	}
}
