using System;

public enum ServerToClientPacket : int
{
	JoinResult = 1,
	LoginResult = 2,
    MoneyData = 3,
    StoreData = 4,
    ItemData = 5,
    StoreCreateResult = 6,
    ItemCreateResult = 7,
    ItemAcquireResult = 8,
    ItemSellResult = 9
}

// Packet ID : 1 -> Login Result Data
public class JoinResultData
{
	public bool joinResult;
	public string message;
}

// Packet ID : 2 -> Login Result Data
public class LoginResultData
{
	public bool loginResult;
	public string message;
}

// Packet ID : 3 -> Money Data
public class MoneyData
{
    public int money;
}

// Packet ID : 4 -> Store Data
public class StoreData
{ 
    public string storeID;
    public string playerID;
    public string storeName;
    public byte storeType;
    public byte step;
    public float presentEXP;
    public float requireEXP;
}

// Packet ID : 5 -> Item Data
public class ItemData
{
    public string itemID;
    public string playerID;
    public string itemName;
    public byte storeType;
    public short count;
    public int price;
    public bool isSell;
    public int sellPrice;
    public short sellCount;
}

// Packet ID : 6 -> Store Create Result Data
public class StoreCreateResultData
{
    public bool createResult;
    public string message;
}

// Packet ID : 7 -> Item Create Result Data
public class ItemCreateResultData
{
    public bool createResult;
    public string message;
}

// Packet ID : 8 -> Item Acquire Result
public class ItemAcquireResultData
{
    public bool acquireResult;
    public string message;
}

// Packet ID : 9 -> Item Sell Result
public class ItemSellResultData
{
    public bool sellResult;
    public string message;
}
