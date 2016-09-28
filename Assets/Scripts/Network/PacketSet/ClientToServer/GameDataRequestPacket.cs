using System;
public class GameDataRequestPacket : Packet <GameDataRequestData, GameDataRequestSerializer>
{
    // constructor - packet data
    public GameDataRequestPacket(GameDataRequestData data)
    {
        // allocate serialzier
        serializer = new GameDataRequestSerializer();

        // allocate data
        dataElement = data;
    }

    // constructor - byte stream
    public GameDataRequestPacket(byte[] data)
    {
        // allocate serializer
        serializer = new GameDataRequestSerializer();
        serializer.SetDeserializedData(data);

        // allocate data
        dataElement = new GameDataRequestData();

        // deserialize data
        serializer.Deserialize(ref dataElement);
    }

    // return data set
    public override GameDataRequestData GetData()
    {
        return dataElement;
    }

    // return packet data -> packet id
    public override int GetPacketID()
    {
        return (int)ClientToServerPacket.GameDataRequest;
    }

    // return packet data -> byte stream data section
    public override byte[] GetPacketData()
    {
        serializer.Serialize(dataElement);

        return serializer.GetSerializeData();
    }
}

