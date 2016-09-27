using System;

public class StoreCreateResultSerializer : Serializer
{
    // serialize store create result data
    public bool Serialize(StoreCreateResultData data)
    {
        // clear buffer
        Clear();

        // serialize element
        bool result = true;
        result &= Serialize(data.createResult);
        result &= Serialize(data.message);

        // failure serialize -> method exit
        if (!result)
            return false;

        // success serialize -> return result
        return true;
    }

    // deserialize store create result data
    public bool Deserialize(ref StoreCreateResultData data)
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // return data initialize 
        bool createResult = false;
        string message;

        // data deserizlize
        result &= Deserialize(ref createResult);
        result &= Deserialize(out message, (int)GetDataSize());

        // input data
        data.createResult = createResult;
        data.message = message;

        // return result
        return result;
    }
}

