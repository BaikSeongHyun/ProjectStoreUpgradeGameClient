using System;

public class ItemCreateResultSerializer : Serializer
{
    // serialize item create result data
    public bool Serialize(ItemCreateResultData data)
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

    // deserialize item create result data
    public bool Deserialize(ref ItemCreateResultData data)
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

