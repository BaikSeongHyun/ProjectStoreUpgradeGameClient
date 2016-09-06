using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class TCPClient
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

	Socket myClientSocket;
	AsyncCallback receiveAsyncCallback;
	string serverIP;
	int serverPort;

	public Socket ClientSocket { get { return myClientSocket; } }

	public TCPClient()
	{
		receiveAsyncCallback = new AsyncCallback( ReceiveAsyncCallback );
	}

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
	public int Send( byte[] data, int size )
	{
		// send message to client
		try
		{
			return myClientSocket.Send( data, size, SocketFlags.None );
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

}