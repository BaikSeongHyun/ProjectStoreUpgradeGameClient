﻿using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public Mode presentMode;

	public GameObject storeCreate;
	public StoreCreate storeCreateLogic;

	public GameObject storeSelect;
	public StoreSelect storeSelectLogic;

	public enum Mode
	{
		CreateStore,
		SelectStore
	};

	public Mode PresentMode
	{
		get { return presentMode;}
	}

	public bool OnStoreCreate
	{
		get{return storeCreate.activeSelf; }
	}

	public void LinkElement()
	{
		storeCreate = GameObject.Find ("StoreCreate");
		storeCreateLogic = storeCreate.GetComponent<StoreCreate> ();

		storeSelect = GameObject.Find ("MainStatus");
		storeSelectLogic = storeSelect.GetComponent<StoreSelect> ();
	}

	public void ChangeUIMode(Mode UIMode)
	{
		switch (UIMode)
		{
		case Mode.CreateStore:
			presentMode = Mode.CreateStore;
			InitializeModeSelectStore ();
			break;

		case Mode.SelectStore:
			presentMode = Mode.SelectStore;
			InitializeModeCreateStore ();
			break;		
		}
	}

	public void InitializeModeCreateStore()
	{
		storeCreate.SetActive (false);
	}
	public void InitializeModeSelectStore()
	{
		storeSelect.SetActive (false);
		storeCreate.SetActive (true);
	}

}
