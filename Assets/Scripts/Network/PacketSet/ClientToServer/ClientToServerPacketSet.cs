using System;

public enum ClientToServerPacket : int
{
	JoinRequest = 1,
    LoginRequest = 2,
    GameDataRequest = 3,
    StoreCreateRequest = 4,
    ItemCreateRequest = 5,
    ItemAcquireRequest = 6,
    ItemSellRequest = 7,
    AuctionRequest = 8
}

// Packet ID : 1 -> Join Request
public class JoinRequestData
{
	public string id;
	public string password;
}

// Packet ID : 2 -> Login Request
public class LoginRequestData
{
	public string id;
	public string password;
}

// Packet ID : 3 -> GameData Request
public class GameDataRequestData
{
    public string playerID;
}

// Packet ID : 4 -> Store Create Request
public class StoreCreateRequestData
{
    public string storeID;
    public string playerID;
    public string storeName;
    public byte storeType;
}

// Packet ID : 5 -> Item Create Request
public class ItemCreateRequestData
{
    public string itemID;
    public string playerID;
    public short count;   
}

// Packet ID : 6 -> Item Acquire Request
public class ItemAcquireRequestData
{
    public string itemID;
    public string playerID;
    public short count;
}

// Packet ID : 7 -> Item Sell Request
public class ItemSellRequestData
{
    public string itemID;
    public string playerID;
    public short count;
}

// Packet ID : 8 -> Auction Request
public class AuctionRequestData
{
}