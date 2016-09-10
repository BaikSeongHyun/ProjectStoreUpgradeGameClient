using System;

public class LoginResultSerializer : Serializer
{
	// serialize login result data
	public bool Serialize( LoginResultData data )
	{
		// clear buffer
		Clear();

		// serialize element
		bool result = true;
		result &= Serialize( data.loginResult );
		result &= Serialize( data.message );

		// failure serialize -> method exit
		if( !result )
			return false;

		// success serialize -> return result
		return true;
	}

	// deserialize login result data
	public bool Deserialize( ref LoginResultData data )
	{
		// set deserialize data
		bool result = ( GetDataSize() > 0 ) ? true : false;

		// data read failure -> method exit
		if( !result )
			return false;

		// return data initialize 
		bool loginResult = false;
		string message ;

		// data deserizlize
		result &= Deserialize( ref loginResult );
		result &= Deserialize( out message, (int) GetDataSize() );

		// input data
		data.loginResult = loginResult;
		data.message = message;

		// return result
		return result;			
	}
}


