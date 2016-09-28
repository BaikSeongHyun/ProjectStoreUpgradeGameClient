using System;

public class StoreDataSerializer : Serializer
{
    // serialize store data
    public bool Serialize(StoreData data)
    {
        // clear buffer
        Clear();

        //serialize element
        bool result = true;
        result &= Serialize(data.storeType);
        result &= Serialize(data.step);
        result &= Serialize(data.presentEXP);
        result &= Serialize(data.requireEXP);
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

    // deserialize store data
    public bool Deserialize(ref StoreData data)
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // return data initialize
        byte storeType = 0;
        byte step = 0;
        float presentEXP = 0.0f;
        float requireEXP = 0.0f;

        // remain data deserialize
        result &= Deserialize(ref storeType);
        result &= Deserialize(ref step);
        result &= Deserialize(ref presentEXP);
        result &= Deserialize(ref requireEXP);

        // input data
        data.storeType = storeType;
        data.step = step;
        data.presentEXP = presentEXP;
        data.requireEXP = requireEXP;

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