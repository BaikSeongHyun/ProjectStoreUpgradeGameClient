using System;

public class ItemAcquireResultSerializer : Serializer
{
    // serialize item acquire result data
    public bool Serialize(ItemAcquireResultData data)
    {
        // clear buffer
        Clear();

        // serialize element
        bool result = true;
        result &= Serialize(data.acquireResult);
        result &= Serialize(data.message);

        // failure serialize -> method exit
        if (!result)
            return false;

        // success serialize -> return result
        return true;
    }

    // deserialize item acquire result data
    public bool Deserialize(ref ItemAcquireResultData data)
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // return data initialize 
        bool acquireResult = false;
        string message;

        // data deserizlize
        result &= Deserialize(ref acquireResult);
        result &= Deserialize(out message, (int)GetDataSize());

        // input data
        data.acquireResult = acquireResult;
        data.message = message;

        // return result
        return result;
    }
}

