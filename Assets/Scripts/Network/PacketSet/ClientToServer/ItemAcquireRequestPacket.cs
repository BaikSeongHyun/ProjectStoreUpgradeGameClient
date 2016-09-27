using System;

public class ItemAcquireRequestPacket : Packet<ItemAcquireRequestData, ItemAcquireRequestSerializer>
{
    // constructor - packet data
    public ItemAcquireRequestPacket(ItemAcquireRequestData data)
    {
        // allocate serializer
        serializer = new ItemAcquireRequestSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public ItemAcquireRequestPacket(byte[] data)
    {
        // allocate serializer
        serializer = new ItemAcquireRequestSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new ItemAcquireRequestData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override ItemAcquireRequestData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ClientToServerPacket.ItemAcquireRequest;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

