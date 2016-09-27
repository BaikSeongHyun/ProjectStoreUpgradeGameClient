using System;
using System.IO;

public class Serializer
{
    protected MemoryStream memoryBuffer = null;
    protected int memoryOffset = 0;

    // constructor -> default parameter
    public Serializer()
    {
        memoryBuffer = new MemoryStream();
    }

    // return memory buffer
    public byte[] GetSerializeData()
    {
        return memoryBuffer.ToArray();
    }

    // set deserialize data
    public bool SetDeserializedData(byte[] data)
    {
        // clear buffer
        Clear();

        try
        {
            memoryBuffer.Write(data, 0, data.Length);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.Data);
            return false;
        }
        return true;
    }

    // return memory offset
    public long GetDataSize()
    {
        return memoryBuffer.Length;
    }

    // clear buffer
    public void Clear()
    {
        byte[] buffer = memoryBuffer.GetBuffer();

        Array.Clear(buffer, 0, buffer.Length);

        memoryBuffer.Position = 0;
        memoryBuffer.SetLength(0);
        memoryOffset = 0;
    }

    // write buffer -> serialize data write
    protected bool WriteBuffer(byte[] data, int size)
    {
        try
        {
            memoryBuffer.Position = memoryOffset;
            memoryBuffer.Write(data, 0, size);
            memoryOffset += size;
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Serializer : Null Reference Expection - On Write Buffer");
            return false;
        }

        return true;
    }

    // read buffer -> data read and deserialize data
    protected bool ReadBuffer(ref byte[] data, int size)
    {
        try
        {
            memoryBuffer.Position = memoryOffset;
            memoryBuffer.Read(data, 0, size);
            memoryOffset += size;
        }
        catch
        {
            return false;
        }
        return true;
    }


    // serialize data
    // serialize - bool
    protected bool Serialize(bool element)
    {
        byte[] data = BitConverter.GetBytes(element);

        return WriteBuffer(data, sizeof(bool));
    }

    // serialize - byte
    protected bool Serialize(byte element)
    {
        byte[] data = new byte[1];
        data[0] = element;

        return WriteBuffer(data, sizeof(byte));
    }

    // serialize - short
    protected bool Serialize(short element)
    {
        byte[] data = BitConverter.GetBytes(element);

        return WriteBuffer(data, sizeof(short));
    }

    // serialize - ushort
    protected bool Serialize(ushort element)
    {
        byte[] data = BitConverter.GetBytes(element);

        return WriteBuffer(data, sizeof(ushort));
    }

    // serialize - int
    protected bool Serialize(int element)
    {
        byte[] data = BitConverter.GetBytes(element);

        return WriteBuffer(data, sizeof(int));
    }

    // serialize - uint
    protected bool Serialize(uint element)
    {
        byte[] data = BitConverter.GetBytes(element);

        return WriteBuffer(data, sizeof(uint));
    }

    // serialize - long
    protected bool Serialize(long element)
    {
        byte[] data = BitConverter.GetBytes(element);

        return WriteBuffer(data, sizeof(long));
    }

    // serialize - ulong
    protected bool Serialize(ulong element)
    {
        byte[] data = BitConverter.GetBytes(element);

        return WriteBuffer(data, sizeof(ulong));
    }

    // serialize - float
    protected bool Serialize(float element)
    {
        byte[] data = BitConverter.GetBytes(element);

        return WriteBuffer(data, sizeof(float));
    }

    // serialize - double
    protected bool Serialize(double element)
    {
        byte[] data = BitConverter.GetBytes(element);

        return WriteBuffer(data, sizeof(double));
    }

    // serialize - byte array
    protected bool Serialize(byte[] element, int length)
    {
        return WriteBuffer(element, length);
    }

    // serialize - string
    protected bool Serialize(string element)
    {
        byte[] data = System.Text.Encoding.Unicode.GetBytes(element);

        return WriteBuffer(data, data.Length);
    }

    // deserialize data
    // deserialize - bool
    protected bool Deserialize(ref bool element)
    {
        int size = sizeof(bool);
        byte[] data = new byte[size];

        bool result = ReadBuffer(ref data, data.Length);

        if (result)
        {
            element = BitConverter.ToBoolean(data, 0);
            return true;
        }

        return false;
    }
    // deserialize - byte
    protected bool Deserialize(ref byte element)
    {
        int size = sizeof(byte);
        byte[] data = new byte[size];

        bool result = ReadBuffer(ref data, data.Length);

        if (result)
        {
            element = data[0];
            return true;
        }

        return false;
    }

    // deserialize - short
    protected bool Deserialize(ref short element)
    {
        int size = sizeof(short);
        byte[] data = new byte[size];

        bool result = ReadBuffer(ref data, data.Length);

        if (result)
        {
            element = BitConverter.ToInt16(data, 0);
            return true;
        }

        return false;
    }

    // deserialize - ushort
    protected bool Deserialize(ref ushort element)
    {
        int size = sizeof(ushort);
        byte[] data = new byte[size];

        bool result = ReadBuffer(ref data, data.Length);

        if (result)
        {
            element = BitConverter.ToUInt16(data, 0);
            return true;
        }

        return false;
    }

    // deserialize - int
    protected bool Deserialize(ref int element)
    {
        int size = sizeof(int);
        byte[] data = new byte[size];

        bool result = ReadBuffer(ref data, data.Length);

        if (result)
        {
            element = BitConverter.ToInt32(data, 0);
            return true;
        }

        return false;
    }

    // deserialize - uint
    protected bool Deserialize(ref uint element)
    {
        int size = sizeof(uint);
        byte[] data = new byte[size];

        bool result = ReadBuffer(ref data, data.Length);

        if (result)
        {
            element = BitConverter.ToUInt32(data, 0);
            return true;
        }

        return false;
    }

    // deserialize - long
    protected bool Deserialize(ref long element)
    {
        int size = sizeof(long);
        byte[] data = new byte[size];

        bool result = ReadBuffer(ref data, data.Length);

        if (result)
        {
            element = BitConverter.ToInt64(data, 0);
            return true;
        }

        return false;
    }

    // deserialize - ulong
    protected bool Deserialize(ref ulong element)
    {
        int size = sizeof(ulong);
        byte[] data = new byte[size];

        bool result = ReadBuffer(ref data, data.Length);

        if (result)
        {
            element = BitConverter.ToUInt64(data, 0);
            return true;
        }

        return false;
    }

    // deserialize - float
    protected bool Deserialize(ref float element)
    {
        int size = sizeof(float);
        byte[] data = new byte[size];

        bool result = ReadBuffer(ref data, data.Length);

        if (result)
        {
            element = BitConverter.ToSingle(data, 0);
            return true;
        }

        return false;
    }

    // deserialize - double
    protected bool Deserialize(ref double element)
    {
        int size = sizeof(double);
        byte[] data = new byte[size];

        bool result = ReadBuffer(ref data, data.Length);

        if (result)
        {
            element = BitConverter.ToDouble(data, 0);
            return true;
        }

        return false;
    }

    // deserialize - byte array
    protected bool Deserialize(ref byte[] element, int length)
    {
        bool result = ReadBuffer(ref element, length);

        if (result)
        {
            return true;
        }

        return false;
    }

    // deserialize - string
    protected bool Deserialize(out string element, int length)
    {
        byte[] data = new byte[length];

        bool result = ReadBuffer(ref data, length);

        if (result)
        {
            element = System.Text.Encoding.Unicode.GetString(data);
            return true;
        }

        element = null;
        return false;
    }
}