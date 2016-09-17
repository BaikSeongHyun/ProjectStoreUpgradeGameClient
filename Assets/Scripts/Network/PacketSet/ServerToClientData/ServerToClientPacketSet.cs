using System;

public enum ServerToClientPacket : int
{
	JoinResult = 1,
	LoginResult = 2
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
