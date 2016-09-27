using System;

public class ItemSellRequestPacket : Packet <ItemSellRequestData, ItemSellRequestSerializer>
{
    // constructor - packet data
    public ItemSellRequestPacket(ItemSellRequestData data)
    {
        // allocate serializer
        serializer = new ItemSellRequestSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public ItemSellRequestPacket(byte[] data)
    {
        // allocate serializer
        serializer = new ItemSellRequestSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new ItemSellRequestData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override ItemSellRequestData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ClientToServerPacket.ItemSellRequest;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

