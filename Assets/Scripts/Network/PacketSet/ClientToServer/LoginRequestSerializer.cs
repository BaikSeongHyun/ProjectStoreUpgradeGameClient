using System;

public class LoginRequestSerializer : Serializer
{
	// serialize login request data
	public bool Serialize( LoginRequestData data )
	{
		// clear buffer
		Clear();

		// serialize element
		bool result = true;
		result &= Serialize( data.id );
		result &= Serialize( "." );
		result &= Serialize( data.password );

		// failure serialize -> method exit
		if( !result )
			return false;

		// success serialize -> return result
		return result;
	}

	// deserialize login request data
	public bool Deserialize( ref LoginRequestData data )
	{
		// set deserialize data
		bool result = ( GetDataSize() > 0 ) ? true : false;

		// data read failure -> method exit
		if( !result )
			return false;

		// packet -> multiple string -> seperate stirng 
		string linkedString;
		result &= Deserialize( out linkedString, (int) GetDataSize() );

		string[] dataSet = linkedString.Split( '.' );

		// input data
		data.id = dataSet[0];
		data.password = dataSet[1];

		//return result
		return result;
	}
}

