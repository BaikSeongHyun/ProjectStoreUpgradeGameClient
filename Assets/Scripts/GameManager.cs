using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class GameManager : MonoBehaviour
{
	[SerializeField] NetworkController networkProcessor;
	[SerializeField] Player playerData;
	[SerializeField] Store presentStore;
	[SerializeField] bool isLogin;
	[SerializeField] string serverIP;
	[SerializeField] int serverPort;
	[SerializeField] string id;
	[SerializeField] string password;
	[SerializeField] UserInterfaceController mainUI;
	[SerializeField] LoginForm loginForm;

	// property
	public Player PlayerData { get { return playerData; } }

	// unity method
	// awake -> active this script
	void Awake()
	{
		// create player data
		playerData = new Player();

		// set network data
		networkProcessor = GetComponent<NetworkController>();	

		// set receive notifier
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.JoinResult, ReceiveJoinResult );
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.LoginResult, ReceiveLoginResult );
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.MoneyData, ReceiveMoneyData );
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.StoreData, ReceiveStoreData );
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.ItemData, ReceiveItemData );
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.StoreCreateResult, ReceiveStoreCreateResult );
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.ItemCreateResult, ReceiveItemCreateResult );
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.ItemAcquireResult, ReceiveItemAcquireResult );
		networkProcessor.RegisterServerReceivePacket( (int) ServerToClientPacket.ItemSellResult, ReceiveItemSellResult );

		isLogin = false;
		presentStore = null;
	}

	// update
	void Update()
	{
		if( isLogin )
		{			
			id = playerData.ID;
			password = playerData.Password;
		}
		else
		{
			serverIP = loginForm.IP;
			serverPort = loginForm.Port;
			id = loginForm.ID;
			password = loginForm.Password;
		}

		mainUI.UIUpdate( playerData, presentStore );
	}

	// public method
	// send data section
	// send join requset
	public void SendJoinRequest()
	{
		// connection start
		networkProcessor.ConnectToServer( serverIP, serverPort );

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
		// connection start
		networkProcessor.ConnectToServer( serverIP, serverPort );

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
		Debug.Log( "GameLoading start" );
		GameDataRequestData sendData = new GameDataRequestData();
		sendData.playerID = id;

		GameDataRequestPacket sendPacket = new GameDataRequestPacket( sendData );

		networkProcessor.Send( sendPacket );
	}

	// send create store
	public void SendCreateStore( Store createStore )
	{
		StoreCreateRequestData sendData = new StoreCreateRequestData();

		sendData.playerID = id;
		sendData.storeID = createStore.ID;
		sendData.storeName = createStore.StoreName;
		sendData.storeType = (byte) ( (int) createStore.Type );

		StoreCreateRequestPacket sendPacket = new StoreCreateRequestPacket( sendData );

		networkProcessor.Send( sendPacket );
	}

	public void SendCreateStore()
	{
		StoreCreateRequestData sendData = new StoreCreateRequestData();

		sendData.playerID = id;
		sendData.storeID = "store0003";
		sendData.storeName = "hotbar";
		sendData.storeType = 3;

		StoreCreateRequestPacket sendPacket = new StoreCreateRequestPacket( sendData );

		networkProcessor.Send( sendPacket );
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
		Debug.Log( data.Length );
		// receive packet serialize
		LoginResultPacket receivePacket = new LoginResultPacket( data );
		LoginResultData loginResultData = receivePacket.GetData();

		isLogin = loginResultData.loginResult;
		// login success
		if( loginResultData.loginResult )
		{
			SendGameDataRequest();
			GameLoading();
			Debug.Log( loginResultData.message );
		}
		else
			Debug.Log( loginResultData.message );
	}

	// receive money data
	public void ReceiveMoneyData( byte[] data )
	{
		// receive packet data serialize
		MoneyDataPacket receivePacket = new MoneyDataPacket( data );
		MoneyData moneyData = receivePacket.GetData();

		// set data
		playerData.Money = moneyData.money;
	}

	// receive store data
	public void ReceiveStoreData( byte[] data )
	{
		// receive packet data serialize
		StoreDataPacket receivePacket = new StoreDataPacket( data );
		StoreData storeData = receivePacket.GetData();

		// set data
		playerData.UpdateStore( storeData );
	}

	// receive item data
	public void ReceiveItemData( byte[] data )
	{
		// receive packet data serialize
		ItemDataPacket receivePacket = new ItemDataPacket( data );
		ItemData itemData = receivePacket.GetData();

		// set data
		playerData.UpdateItem( itemData );
	}

	// receive store create result
	public void ReceiveStoreCreateResult( byte[] data )
	{
		// receive packet data serialize
		StoreCreateResultPacket receivePacket = new StoreCreateResultPacket( data );
		StoreCreateResultData resultData = receivePacket.GetData();

		// popup & result print

	}

	// receive item create result
	public void ReceiveItemCreateResult( byte[] data )
	{
		// receive packet data serialize 
		ItemCreateResultPacket receivePacket = new ItemCreateResultPacket( data );
		ItemCreateResultData resultData = receivePacket.GetData();

		// popup & result print
	}

	// receive item acquire result
	public void ReceiveItemAcquireResult( byte[] data )
	{
		// receive packet data serialize 
		ItemAcquireResultPacket receivePacket = new ItemAcquireResultPacket( data );
		ItemAcquireResultData resultData = receivePacket.GetData();

		// popup & result print
	}

	// receive item sell result
	public void ReceiveItemSellResult( byte[] data )
	{
		// receive packet data serialize 
		ItemSellResultPacket receivePacket = new ItemSellResultPacket( data );
		ItemSellResultData resultData = receivePacket.GetData();

		// popup & result print
	}

	// non network method
	public void GameStart()
	{
		if( presentStore != null )
			mainUI.MakeGameStep( presentStore.Step );
	}

	public void SetPresentStore( Store data )
	{
		presentStore = playerData.FindStoreByID( data.ID );
	}


	// coroutine section
	// game loading routine
	public void GameLoading()
	{
		loginForm.gameObject.SetActive( false );

		// set select ui
		mainUI.MakeGameStep( 0 );
	}
}