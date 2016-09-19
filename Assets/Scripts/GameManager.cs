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
	[SerializeField] UserInterfaceController mainUI;

	// property
	public Player PlayerData { get { return playerData; } }
	// unity method
	void Awake()
	{
		// create player data
		// playerData = new Player();

		// set network data
		networkProcessor = GetComponent<NetworkController>();
		networkProcessor.ConnectToServer();

		// set receive notifier
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.JoinResult, ReceiveJoinResult );
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.LoginResult, ReceiveLoginResult );
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

		Debug.Log( sendData.id + " / " + sendData.password );
		JoinRequestPacket sendPacket = new JoinRequestPacket( sendData );

		networkProcessor.Send( sendPacket );
	}

	// send login request
	public void SendLoginRequest()
	{
		// set data
		LoginRequestData sendData = new LoginRequestData();
		sendData.id = id;
		sendData.password = password;

		Debug.Log( sendData.id + " / " + sendData.password );
		LoginRequestPacket sendPacket = new LoginRequestPacket( sendData );

		networkProcessor.Send( sendPacket );
	}

	// send game data request
	public void SendGameDataRequest()
	{
		//StartCoroutine( GameLoading() );
	}

	// send create store
	public void CreateStore( Store createStore )
	{
		
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
		// receive packet serialize
		LoginResultPacket receivePacket = new LoginResultPacket( data );
		LoginResultData loginResultData = receivePacket.GetData();

		// login success
		if( loginResultData.loginResult )
		{
			SendGameDataRequest();
			Debug.Log( loginResultData.message );
		}
		else
			Debug.Log( loginResultData.message );
	}

	// receive game data
	public void ReceiveGameData( byte[] data )
	{
		// data deserialize

		// data set -> check parameter

	}

	// receive store create result
	public void ReceiveStoreCreateData( byte[] data )
	{
		// success -> data update

		// success -> ui (create -> select)

		// fail -> pop up ( result string )
	}

	// coroutine section
	IEnumerator GameLoading()
	{
		// check parameter -> active value

		// set select ui
		mainUI.MakeSelectUI();

		yield return new WaitForSeconds( 0f );
	}
}