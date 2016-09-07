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
	[SerializeField] TCPClient clientProcesser;

	// queue -> input / output check point
	[SerializeField] PacketQueue receiveQueue;
	[SerializeField] PacketQueue sendQueue;

	// delegate -> for packtet receive check
	public delegate void ReceiveNotifier(Socket socket,byte[] data);

	// client notifier set -> socket library
	Dictionary <int, ReceiveNotifier> notifierForClient = new Dictionary<int, ReceiveNotifier>();

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
		clientProcesser = new TCPClient();
		clientProcesser.OnReceived += OnReceivedPacketFromServer;
		clientProcesser.SetServerInformation( serverIP, serverPort );
	}

	void Update()
	{
		Receive( clientProcesser.ClientSocket );
	}

	// game quit
	void OnApplicationQuit()
	{
		clientProcesser.Disconnect();
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

	// enqueue - receive queue
	private void OnReceivedPacketFromServer( byte[] message, int size )
	{
		receiveQueue.Enqueue( message, size );
	}

	// public method
	// start network connection
	public bool ConnectToServer()
	{
		return clientProcesser.Connect();
	}

	// data receive
	public void Receive( Socket socket )
	{
		int count = receiveQueue.Count;

		for ( int i = 0; i < count; i++ )
		{
			int receiveSize = 0;
			receiveSize = receiveQueue.Dequeue( ref receiveBuffer, receiveBuffer.Length );

			// packet precess
			if( receiveSize > 0 )
			{
				byte[] message = new byte[receiveSize];
				Array.Copy( receiveBuffer, message, receiveSize );

				int packetID;
				byte[] packetData;

				// packet seperate -> header / data
				SeperatePacket( message, out packetID, out packetData );

				ReceiveNotifier notifier;

				// use notifier
				try
				{
					notifierForClient.TryGetValue( packetID, out notifier );
					notifier( socket, packetData );			
				}
				catch ( NullReferenceException e )
				{
					Debug.Log( e.Message );
					Debug.Log( e.InnerException );
					Debug.Log( "Client : Null Reference Exception - On Receive (use notifier)" );
				}
			}
		}
	}

	// client receive notifier register
	public void RegisterServerReceivePacket( int packetID, ReceiveNotifier notifier )
	{
		notifierForClient.Add( packetID, notifier );
	}

	// client receive notifier unregister
	public void UnregisterServerReceivePackter( int packetID )
	{
		notifierForClient.Remove( packetID );
	}
}
