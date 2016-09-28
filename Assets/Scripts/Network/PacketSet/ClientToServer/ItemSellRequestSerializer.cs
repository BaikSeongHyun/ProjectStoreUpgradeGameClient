using System;

public class ItemSellRequestSerializer : Serializer
{
    // serialize item sell request data
    public bool Serialize(ItemSellRequestData data)
    {
        // clear buffer
        Clear();

        //serialize element
        bool result = true;
        result &= Serialize(data.count);
        result &= Serialize(data.playerID);
        result &= Serialize(".");
        result &= Serialize(data.itemID);

        // failure serialize -> method exit
        if (!result)
            return false;

        // success serialize -> return result
        return result;
    }

    // deserialize item sell request data
    public bool Deserialize(ref ItemSellRequestData data)
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // return data initialize
        short count = 0;

        // remain data deserialize
        result &= Deserialize(ref count);

        // input data
        data.count = count;

        // packet -> multiple string -> seperate string
        string linkedString;
        result &= Deserialize(out linkedString, (int)GetDataSize());

        string[] dataSet = linkedString.Split('.');

        // input data
        data.playerID = dataSet[0];
        data.itemID = dataSet[1];

        // return result   
        return result;
    }
}

