using System;

public enum ClientToServerPacket : int
{
	JoinRequest = 1,
	LoginRequest = 2
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