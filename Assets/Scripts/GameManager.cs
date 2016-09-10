using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class GameManager : MonoBehaviour
{
	[SerializeField] NetworkController networkProcessor;
	[SerializeField] Player playerData;
	[SerializeField] string id;
	[SerializeField] string password;
	// unity method
	void Awake()
	{
		// create player data
		// playerData = new Player();

		// set network data
		networkProcessor = GetComponent<NetworkController>();
		networkProcessor.ConnectToServer();

		// set receive notifier
		networkProcessor.RegisterServerReceivePacket( (int) ClientToServerPacket.JoinRequest, ReceiveJoinResult );
	}

	// private method



	// public method
	// send data section
	// send join requset
	public void SendJoinRequest()
	{
		// set data
		JoinRequestData sendData = new JoinRequestData();
		sendData.id = id;
		sendData.password = password;

		JoinRequestPakcet sendPacket = new JoinRequestPakcet( sendData );

		networkProcessor.Send( sendPacket );
	}

	// send login request
	public void SendLoginRequest()
	{

	}

	// send game data request
	public void SendGameDataRequest()
	{
		StartCoroutine( GameLoading() );
	}


	// receive data section
	// receive join result
	public void ReceiveJoinResult( byte[] data )
	{
		// receive packet serialize 
		JoinResultPacket receivePacket = new JoinResultPacket( data );
		JoinResultData joinResultData = receivePacket.GetData();

		//process - join success
		Debug.Log( joinResultData.message );
	}

	// receive login result
	public void ReceiveLoginResult( byte[] data )
	{


		// login success
		SendGameDataRequest();
	}

	// receive game data
	public void ReceiveGameData( byte[] data )
	{
		// data deserialize

		// data set -> check parameter

	}

	// coroutine section
	IEnumerator GameLoading()
	{
		// check parameter -> active value

		// set select ui

		yield return new WaitForSeconds( 0f );
	}
}