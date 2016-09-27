using System;

public class ItemCreateRequestPacket : Packet<ItemCreateRequestData, ItemCreateRequestSerializer>
{
    // constructor - packet data
    public ItemCreateRequestPacket(ItemCreateRequestData data)
    {
        // allocate serializer
        serializer = new ItemCreateRequestSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public ItemCreateRequestPacket(byte[] data)
    {
        // allocate serializer
        serializer = new ItemCreateRequestSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new ItemCreateRequestData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override ItemCreateRequestData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ClientToServerPacket.ItemCreateRequest;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}
