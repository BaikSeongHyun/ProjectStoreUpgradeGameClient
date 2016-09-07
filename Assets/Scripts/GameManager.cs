using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	[SerializeField] NetworkController network;


	// unity method
	void Awake()
	{
		network = GetComponent<NetworkController>();
		network.ConnectToServer();
	}



	// private method



	// public method
}