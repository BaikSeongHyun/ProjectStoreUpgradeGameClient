using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class GameManager : MonoBehaviour
{
	[SerializeField] NetworkController networkProcessor;

	[SerializeField] string id;
	[SerializeField] string password;
	// unity method
	void Awake()
	{
		networkProcessor = GetComponent<NetworkController>();
		networkProcessor.ConnectToServer();

		// set receive notifier
		networkProcessor.RegisterServerReceivePacket( (int) ClientToServerPacket.JoinRequest, ReceiveJoinResult );
	}



	// private method



	// public method
	public void SendJoinRequest()
	{
		// set data
		JoinRequestData sendData = new JoinRequestData();
		sendData.id = id;
		sendData.password = password;

		JoinRequestPakcet sendPacket = new JoinRequestPakcet( sendData );

		networkProcessor.Send( sendPacket );
	}

	// receive data section
	// receive joi result
	public void ReceiveJoinResult( byte[] data )
	{
		// receive packet serialize 
		JoinResultPacket receivePacket = new JoinResultPacket( data );
		JoinResultData joinResultData = receivePacket.GetData();

		//process - join success
		Debug.Log( joinResultData.message );
	}
}