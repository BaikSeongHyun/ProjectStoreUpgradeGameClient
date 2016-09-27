using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ItemCreateRequestSerializer : Serializer
{
    // serialize item create request data
    public bool Serialize(ItemCreateRequestData data)
    {
        // clear buffer
        Clear();

        //serialize element
        bool result = true;
        result &= Serialize(data.playerID);
        result &= Serialize(".");
        result &= Serialize(data.itemID);
        result &= Serialize(data.count);
        

        // failure serialize -> method exit
        if (!result)
            return false;

        // success serialize -> return result
        return result;
    }

    // deserialize item create request data
    public bool Deserialize(ref ItemCreateRequestData data)
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // packet -> multiple string -> seperate string
        string linkedString;
        result &= Deserialize(out linkedString, (int)GetDataSize());

        string[] dataSet = linkedString.Split('.');

        // input data
        data.playerID = dataSet[0];
        data.itemID = dataSet[1];
       
        // return data initialize
        short count = 0;  

        // remain data deserialize
        result &= Deserialize(ref count);
        
        // input data
        data.count = count;
               
        // return result   
        return result;
    }
}

