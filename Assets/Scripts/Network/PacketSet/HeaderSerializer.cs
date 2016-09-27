using System;
using System.IO;

public class HeaderSerializer : Serializer
{
    // serialize packet header
    public bool Serialize(PacketHeader data)
    {
        // clear buffer
        Clear();

        // serialize element
        bool result = true;
        result &= Serialize(data.id);
        result &= Serialize(data.length);

        // failure serialize -> method exit
        if (!result)
            return false;

        // success serialize -> return result
        return true;
    }

    // deserialize packet header
    public bool Deserialize(ref PacketHeader data)
    {
        // set deserialize data
        bool result = (GetDataSize() > 0) ? true : false;

        // data read failure -> method exit
        if (!result)
            return false;

        // return data initialize
        byte packetID = 1;
        short packetLength = 0;

        // data deserialize 
        result &= Deserialize(ref packetID);
        result &= Deserialize(ref packetLength);

        // input data
        data.id = packetID;
        data.length = packetLength;

        // return result
        return result;
    }
}
