using System;

public class ItemDataSerializer : Serializer
{
    // serialize item data
    public bool Serialize(ItemData data)
    {
        // clear buffer
        Clear();

        //serialize element
        bool result = true;
        result &= Serialize(data.storeType);
        result &= Serialize(data.count);
        result &= Serialize(data.price);
        result &= Serialize(data.isSell);
        result &= Serialize(data.sellPrice);
        result &= Serialize(data.sellCount);
        result &= Serialize(data.playerID);
        result &= Serialize(".");
        result &= Serialize(data.itemID);
        result &= Serialize(".");
        result &= Serialize(data.itemName);

        // failure serialize -> method exit
        if (!result)
            return false;

        // success serialize -> return result
        return result;
    }

    // deserialize item data
    public bool Deserialize(ref ItemData data)
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // return data initialize
        byte storeType = 0;
        short count = 0;
        int price = 0;
        bool isSell = false;
        int sellPrice = 0;
        short sellCount = 0;

        // remain data deserialize
        result &= Deserialize(ref storeType);
        result &= Deserialize(ref count);
        result &= Deserialize(ref price);
        result &= Deserialize(ref isSell);
        result &= Deserialize(ref sellPrice);
        result &= Deserialize(ref sellCount);

        // input data
        data.storeType = storeType;
        data.count = count;
        data.price = price;
        data.isSell = isSell;
        data.sellPrice = sellPrice;
        data.sellCount = sellCount;

        // packet -> multiple string -> seperate string
        string linkedString;
        result &= Deserialize(out linkedString, (int)GetDataSize());

        string[] dataSet = linkedString.Split('.');

        // input data
        data.playerID = dataSet[0];
        data.itemID = dataSet[1];
        data.itemName = dataSet[2];

        // return result   
        return result;
    }
}

