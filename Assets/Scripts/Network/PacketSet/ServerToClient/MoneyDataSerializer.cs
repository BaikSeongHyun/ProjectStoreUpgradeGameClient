using System;

public class MoneyDataSerializer : Serializer
{
    // serialize money data 
    public bool Serialize(MoneyData data)
    {
        // clear buffer
        Clear();

        // serialize element
        bool result = true;
        result &= Serialize(data.money);

        // failure serialize -> method exit
        if (!result)
            return false;

        // success serialize -> return result
        return result;
    }

    // deserialize money data
    public bool Deserialize( ref MoneyData data )
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // set data
        int money = 0;

        // deserialize data
        result &= Deserialize(ref money);

        // input data
        data.money = money;

        // return result
        return result;
    }
}

