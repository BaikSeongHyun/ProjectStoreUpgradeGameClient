using System;

public class ItemSellResultSerializer : Serializer
{
    // serialize item sell result data
    public bool Serialize(ItemSellResultData data)
    {
        // clear buffer
        Clear();

        // serialize element
        bool result = true;
        result &= Serialize(data.sellResult);
        result &= Serialize(data.message);

        // failure serialize -> method exit
        if (!result)
            return false;

        // success serialize -> return result
        return true;
    }

    // deserialize item sell result data
    public bool Deserialize(ref ItemSellResultData data)
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // return data initialize 
        bool sellResult = false;
        string message;

        // data deserizlize
        result &= Deserialize(ref sellResult);
        result &= Deserialize(out message, (int)GetDataSize());

        // input data
        data.sellResult = sellResult;
        data.message = message;

        // return result
        return result;
    }
}

