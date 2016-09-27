using System;

public class MoneyDataPacket : Packet<MoneyData, MoneyDataSerializer>
{
    // constructor - packet data
    public MoneyDataPacket(MoneyData data)
    {
        // allocate serialier
        serializer = new MoneyDataSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public MoneyDataPacket(byte[] data)
    {
        // allocate serializer
        serializer = new MoneyDataSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new MoneyData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override MoneyData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet od
    public override int GetPacketID()
    {
        return (int)ServerToClientPacket.MoneyData;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

