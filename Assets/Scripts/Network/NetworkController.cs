using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

public class NetworkController : MonoBehaviour
{
	// client connection socket
	[SerializeField] TCPClient myClientSocket;

	// queue -> input / output check point
	[SerializeField] PacketQueue receiveQueue;
	[SerializeField] PacketQueue sendQueue;

	// delegate -> for packtet receive check
	public delegate void ReceiveNotifier(Socket socket,byte[] data);

	// client notifier set -> socket library
	Dictionary <int, ReceiveNotifier> notifierForServer = new Dictionary<int, ReceiveNotifier>();

	// byte array data
	byte[] receiveBuffer;
	byte[] sendBuffer;
	const int bufferSize = 2048;

	// server information
	[SerializeField] string serverIP;
	[SerializeField] int serverPort;

	// unity method
	// data initailize
	void Awake()
	{
		// allocate queue
		receiveQueue = new PacketQueue();
		sendQueue = new PacketQueue();

		// allocate buffer
		receiveBuffer = new byte[bufferSize];
		sendBuffer = new byte[bufferSize];

		// client information set
		myClientSocket = new TCPClient();
		//myClientSocket.OnReceived += OnReceivedPacketFromServer;
		myClientSocket.SetServerInformation( serverIP, serverPort );
	}

	void Start()
	{

	}

	void Update()
	{
		Receive( myClientSocket.ClientSocket );
	}

	// game quit
	void OnApplicationQuit()
	{
		myClientSocket.Disconnect();
	}

	// private method
	// packet seperate id / data
	private bool SeperatePacket( byte[] originalData, out int packetID, out byte[] seperatedData )
	{
		PacketHeader header = new PacketHeader();
		HeaderSerializer serializer = new HeaderSerializer();

		serializer.SetDeserializedData( originalData );
		serializer.Deserialize( ref header );

		seperatedData = null;

		packetID = 0;
		return true;
	}

	// public method
	// data receive
	public void Receive( Socket socket )
	{
		int count = receiveQueue.Count;

		for ( int i = 0; i < count; i++ )
		{
			int receiveSize = 0;
			receiveSize = receiveQueue.Dequeue( ref receiveBuffer, receiveBuffer.Length );

			if( receiveSize > 0 )
			{
				byte[] message = new byte[receiveSize];
				Array.Copy( receiveBuffer, message, receiveSize );

				int packetID;
				byte[] packetData;
				SeperatePacket( message, out packetID, out packetData );

			}
		}
	}

	// receive packet
	public void ReceivePacket( Dictionary<int, ReceiveNotifier> notifier, Socket socket, byte[] data )
	{

	}
}
