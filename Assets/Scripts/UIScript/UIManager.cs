using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public Mode presentMode;

	public GameObject storeCreate;
	public StoreCreate storeCreateLogic;

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
	}

	public void ChangeUIMode(Mode UIMode)
	{
		switch (UIMode)
		{
			case Mode.CreateStore:
				presentMode = Mode.CreateStore;
				break;

			case Mode.SelectStore:
				presentMode = Mode.SelectStore;
				break;		
		}
	}

	public void InitializeModeCreateStore()
	{
				
	}

}
