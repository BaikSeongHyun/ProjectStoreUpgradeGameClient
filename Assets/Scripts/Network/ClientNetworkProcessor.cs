using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

[System.Serializable]
public class ClientNetworkProcessor
{
	class AsyncData
	{
		public Socket clientSocket;
		public const int messageMaxLength = 1024;
		public byte[] message = new byte[messageMaxLength];
		public int messageLength;
	}

	public delegate void OnReceiveEvent(byte[] message,int messageSize);

	public event OnReceiveEvent OnReceived;

	[SerializeField] Socket myClientSocket;
	AsyncCallback receiveAsyncCallback;
	[SerializeField] string serverIP;
	[SerializeField] int serverPort;

	public Socket ClientSocket { get { return myClientSocket; } }

	public ClientNetworkProcessor()
	{
		receiveAsyncCallback = new AsyncCallback( ReceiveAsyncCallback );
	}

	// private method
	// create packet include header
	private byte[] CreatePacketStream<T, U>( Packet<T,U> packet )
	{
		Debug.Log( packet.GetPacketData().Length );
		// data iniialize  
		byte[] packetData = packet.GetPacketData();	

		PacketHeader header = new PacketHeader();
		HeaderSerializer serializer = new HeaderSerializer();

		// set header data
		header.id = (byte) packet.GetPacketID();
		header.length = (short) packetData.Length;

		byte[] headerData = null;

		if( !serializer.Serialize( header ) )
			return null;

		headerData = serializer.GetSerializeData();

		// header / packet data combine
		byte[] data = new byte[headerData.Length + packetData.Length];

		int headerSize = Marshal.SizeOf( header.id ) + Marshal.SizeOf( header.length );
		Buffer.BlockCopy( headerData, 0, data, 0, headerSize );
		Buffer.BlockCopy( packetData, 0, data, headerSize, packetData.Length );

		return data;
	}

	// public method
	// set serverInformation
	public void SetServerInformation( string _serverIP, int _serverPort )
	{
		serverIP = _serverIP;
		serverPort = _serverPort;
	}

	// connect client to server
	public bool Connect()
	{
		// client socket connect
		try
		{
			myClientSocket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
			myClientSocket.Connect( new IPEndPoint( IPAddress.Parse( serverIP ), serverPort ) );
		}
		catch ( NullReferenceException e )
		{
			Debug.Log( e.Message );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Null Reference Exception - On Connect (connect section)" );
			return false;
		}
		catch ( SocketException e )
		{
			Debug.Log( e.ErrorCode );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Socket Exception - On Connect (connect section)" );
			return false;
		}

		// async data set
		AsyncData asyncData = new AsyncData();
		asyncData.clientSocket = myClientSocket;

		// set begin receive
		try
		{
			myClientSocket.BeginReceive( asyncData.message, 0, AsyncData.messageMaxLength, SocketFlags.None, receiveAsyncCallback, asyncData );
		}
		catch ( NullReferenceException e )
		{
			Debug.Log( e.Message );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Null Reference Exception - On Connect (begin receive section)" );
			return false;
		}
		catch ( SocketException e )
		{
			Debug.Log( e.ErrorCode );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Socket Exception - On Connect (begin receive section)" );
			return false;
		}

		Debug.Log( "Client : Connect Success -> IP : " + serverIP + " / port : " + serverPort.ToString() );
		return true;
	}

	// callback method -> async callback receive
	public void ReceiveAsyncCallback( IAsyncResult asyncResult )
	{
		// async data set
		AsyncData asyncData = (AsyncData) asyncResult.AsyncState;
		Socket clientSocket = asyncData.clientSocket;

		// end receive process
		try
		{
			asyncData.messageLength = clientSocket.EndReceive( asyncResult );
		}
		catch ( NullReferenceException e )
		{
			Debug.Log( e.Message );
			Debug.Log( e.InnerException );
			Debug.Log( "Clinet : Null Reference Exception - On Receive Async Callback (end receive section)" );
		}
		catch ( SocketException e )
		{
			Debug.Log( e.ErrorCode );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Socket Exception - On Receive Async Callback (end receive section)" );			
		}

		// add event 
		try
		{
			OnReceived( asyncData.message, asyncData.messageLength );
		}
		catch ( NullReferenceException e )
		{
			Debug.Log( e.Message );
			Debug.Log( e.InnerException );
			Debug.Log( "Clinet : Null Reference Exception - On Receive Async Callback (add event section)" );
		}

		// set begin receive
		try
		{
			clientSocket.BeginReceive( asyncData.message, 0, AsyncData.messageMaxLength, SocketFlags.None, receiveAsyncCallback, asyncData );
		}
		catch ( NullReferenceException e )
		{
			Debug.Log( e.Message );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Null Reference Exception - On Connect (begin receive section)" );
		}
		catch ( SocketException e )
		{
			Debug.Log( e.ErrorCode );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Socket Exception - On Connect (begin receive section)" );
		}
	}

	// send method
	public int Send<T,U>( Packet<T,U> packet )
	{
		byte[] data = CreatePacketStream( packet );
		Debug.Log( data.Length );

		AnalysisPacket( data );

		// send message to client
		try
		{
			
			return myClientSocket.Send( data, data.Length, SocketFlags.None );
		}
		catch ( NullReferenceException e )
		{
			Debug.Log( e.Message );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Null Reference Exception - Send (send section)" );
			return -1;
		}
		catch ( SocketException e )
		{
			Debug.Log( e.ErrorCode );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Socket Exception - Send (send section)" );
			return -1;
		}
	}

	// disconnect from server
	public void Disconnect()
	{
		try
		{
			myClientSocket.Close();
		}
		catch ( NullReferenceException e )
		{
			Debug.Log( e.Message );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Null Reference Exception - On Disconnect (close section)" );
		}
		catch ( SocketException e )
		{
			Debug.Log( e.ErrorCode );
			Debug.Log( e.InnerException );
			Debug.Log( "Client : Socket Exception - On Disconnect (close section)" );
		}
	}

	public void AnalysisPacket( byte[] data )
	{
		int packetID;
		byte[] packetData;

		SeperatePacket( data, out packetID, out packetData );
		Debug.Log( packetData.Length );
		ReceiveJoinRequest( packetData );		
	}

	public bool SeperatePacket( byte[] originalData, out int packetID, out byte[] seperatedData )
	{
		PacketHeader header = new PacketHeader();
		HeaderSerializer serializer = new HeaderSerializer();

		serializer.SetDeserializedData( originalData );
		serializer.Deserialize( ref header );

		Debug.Log( "Packet ID : " + header.id.ToString() + " , Packet Length :" + header.length.ToString() ); 
		int headerSize = Marshal.SizeOf( header.id ) + Marshal.SizeOf( header.length );
		int packetDataSize = originalData.Length - headerSize;
		byte[] packetData = null;

		if( packetDataSize > 0 )
		{
			packetData = new byte[packetDataSize];
			Buffer.BlockCopy( originalData, headerSize, packetData, 0, packetData.Length );
		}
		else
		{
			packetID = header.id;
			seperatedData = null;
			return false;
		}

		packetID = header.id;
		seperatedData = packetData;
		return true;
	}

	public void ReceiveJoinRequest( byte[] data )
	{
		// receive packet serialize 
		JoinRequestPacket receivePacket = new JoinRequestPacket( data );
		JoinRequestData joinRequestData = receivePacket.GetData();

		Debug.Log( joinRequestData.id );
		Debug.Log( joinRequestData.password );
	}

}