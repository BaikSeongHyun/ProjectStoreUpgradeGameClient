using System;

public class StoreCreateResultPacket : Packet<StoreCreateResultData, StoreCreateResultSerializer>
{
    // constructor - packet data
    public StoreCreateResultPacket(StoreCreateResultData data)
    {
        // allocate serialzier
        serializer = new StoreCreateResultSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public StoreCreateResultPacket(byte[] data)
    {
        // allocate serializer
        serializer = new StoreCreateResultSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new StoreCreateResultData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override StoreCreateResultData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ServerToClientPacket.StoreCreateResult;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

