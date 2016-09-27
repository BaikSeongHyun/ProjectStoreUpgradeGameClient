using System;

public class ItemDataPacket : Packet <ItemData, ItemDataSerializer >
{
    // constructor - packet data
    public ItemDataPacket(ItemData data)
    {
        // allocate serializer
        serializer = new ItemDataSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public ItemDataPacket(byte[] data)
    {
        // allocate serializer
        serializer = new ItemDataSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new ItemData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override ItemData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ServerToClientPacket.ItemData;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

