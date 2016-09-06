using System;
using System.IO;

public class HeaderSerializer : Serializer
{
	public bool Serialize( PacketHeader data )
	{
		// clear buffer
		Clear();

		// serialize element
		bool ret = true;
		ret &= Serialize( data.length );
		ret &= Serialize( data.id );

		if( !ret )
			return false;

		return true;
	}

	public bool Deserialize( ref PacketHeader serialized )
	{
		// set deserialize data
		bool ret = ( GetDateSize() > 0 ) ? true : false;

		if( !ret )
			return false;

		short packetLength = 0;
		byte packetID = 0;

		ret &= Deserialize( ref packetLength );
		//ret &= Deserialize( ref packetID );
		serialized.length = packetLength;
		serialized.id = packetID;

		return ret;
	}
}
