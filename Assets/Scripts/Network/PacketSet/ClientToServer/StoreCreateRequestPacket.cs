using System;

public class StoreCreateRequestPacket : Packet <StoreCreateRequestData, StoreCreateRequestSerializer>
{
    // constructor - packet data
    public StoreCreateRequestPacket(StoreCreateRequestData data)
    {
        // allocate serializer
        serializer = new StoreCreateRequestSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public StoreCreateRequestPacket(byte[] data)
    {
        // allocate serializer
        serializer = new StoreCreateRequestSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new StoreCreateRequestData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override StoreCreateRequestData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ClientToServerPacket.StoreCreateRequest;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

