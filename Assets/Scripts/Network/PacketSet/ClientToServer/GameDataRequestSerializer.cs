using System;

public class GameDataRequestSerializer : Serializer
{
    // serialize game data request data
    public bool Serialize(GameDataRequestData data)
    {
        // clear buffer
        Clear();

        // serialize element
        bool result = true;
        result &= Serialize(data.playerID);

        // failure serialize -> method exit
        if (!result)
            return false;

        // success serialize -> return result
        return true;
    }

    // deserialize game data request data
    public bool Deserialize(ref GameDataRequestData data)
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // return data initialize 
        string playerID;

        // data deserizlize
        result &= Deserialize(out playerID, (int)GetDataSize());

        // input data
        data.playerID = playerID;

        // return result
        return result;
    }
}

