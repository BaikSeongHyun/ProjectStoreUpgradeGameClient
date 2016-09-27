using System;

public abstract class Packet<Data, Serializer>
{
    // field for packet
    public Data dataElement;
    public Serializer serializer;

    // abstract method for packet
    // return data set
    public abstract Data GetData();

    // return packet data -> packet id
    public abstract int GetPacketID();

    // return packet data -> byte stream data section 
    public abstract byte[] GetPacketData();
}