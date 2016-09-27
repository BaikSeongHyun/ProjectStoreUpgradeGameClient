using System;

public class ItemUpdateResultPacket : Packet<ItemCreateResultData, ItemCreateResultSerializer>
{
    // constructor - packet data
    public ItemUpdateResultPacket(ItemCreateResultData data)
    {
        // allocate serialzier
        serializer = new ItemCreateResultSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public ItemUpdateResultPacket(byte[] data)
    {
        // allocate serializer
        serializer = new ItemCreateResultSerializer();

        // allocate data
        dataElement = new ItemCreateResultData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override ItemCreateResultData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ServerToClientPacket.ItemCreateResult;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

