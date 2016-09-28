using System;

public class ItemSellResultPacket : Packet <ItemSellResultData, ItemSellResultSerializer>
{
    // constructor - packet data
    public ItemSellResultPacket(ItemSellResultData data)
    {
        // allocate serialzier
        serializer = new ItemSellResultSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public ItemSellResultPacket(byte[] data)
    {
        // allocate serializer
        serializer = new ItemSellResultSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new ItemSellResultData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override ItemSellResultData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ServerToClientPacket.ItemSellResult;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

