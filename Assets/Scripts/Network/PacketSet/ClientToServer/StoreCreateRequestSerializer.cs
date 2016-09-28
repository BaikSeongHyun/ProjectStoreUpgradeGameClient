using System;

public class StoreCreateRequestSerializer : Serializer
{
    // serialize store update request data
    public bool Serialize(StoreCreateRequestData data)
    {
        // clear buffer
        Clear();

        //serialize element
        bool result = true;    
        result &= Serialize(data.storeType);
        result &= Serialize(data.playerID);
        result &= Serialize(".");
        result &= Serialize(data.storeID);
        result &= Serialize(".");
        result &= Serialize(data.storeName);

        // failure serialize -> method exit
        if (!result)
            return false;
        // success serialize -> return result
        return result;
    }

    // deserialize store update request data
    public bool Deserialize(ref StoreCreateRequestData data)
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // data intialize
        byte storeType = 0;
        result &= Deserialize(ref storeType);

        data.storeType = storeType;

        // packet -> multiple string -> seperate string
        string linkedString;
        result &= Deserialize(out linkedString, (int)GetDataSize());

        string[] dataSet = linkedString.Split('.');

        // input data
        data.playerID = dataSet[0];
        data.storeID = dataSet[1];
        data.storeName = dataSet[2];       

        // return result   
        return result;
    }
}

