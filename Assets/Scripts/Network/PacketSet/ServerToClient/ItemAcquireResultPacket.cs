using System;

public class ItemAcquireResultPacket : Packet<ItemAcquireResultData, ItemAcquireResultSerializer>
{
    // constructor - packet data
    public ItemAcquireResultPacket(ItemAcquireResultData data)
    {
        // allocate serialzier
        serializer = new ItemAcquireResultSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public ItemAcquireResultPacket(byte[] data)
    {
        // allocate serializer
        serializer = new ItemAcquireResultSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new ItemAcquireResultData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override ItemAcquireResultData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ServerToClientPacket.ItemAcquireResult;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

