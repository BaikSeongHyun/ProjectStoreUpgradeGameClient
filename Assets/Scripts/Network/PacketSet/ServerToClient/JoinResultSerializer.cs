using System;

public class JoinResultSerializer : Serializer
{
	// serialize join result data
	public bool Serialize( JoinResultData data )
	{
		// clear buffer
		Clear();
    
        // serialize element
		bool result = true;
		result &= Serialize( data.joinResult );
        result &= Serialize( data.message );

		// failure serialize -> method exit
		if( !result )
			return false;

		// success serialize -> return result
		return result;
	}

	// deserialize join result data
	public bool Deserialize( ref JoinResultData data )
	{
		// set deserialize data
		bool result = ( GetDataSize() > 0 ) ? true : false;

		// data read failure -> method exit
		if( !result )
			return false;

		// return data initialize 
		bool joinResult = false;
		string message;

		// data deserizlize
		result &= Deserialize( ref joinResult );
		result &= Deserialize( out message, (int) GetDataSize() );

		// input data
		data.joinResult = joinResult;
		data.message = message;


		// return result
		return result;
	}

}