using System;

public class StoreDataPacket : Packet<StoreData, StoreDataSerializer>
{
    // constructor - packet data
    public StoreDataPacket(StoreData data)
    {
        // allocate serializer
        serializer = new StoreDataSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public StoreDataPacket(byte[] data)
    {
        // allocate serializer
        serializer = new StoreDataSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new StoreData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override StoreData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ServerToClientPacket.StoreData;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

