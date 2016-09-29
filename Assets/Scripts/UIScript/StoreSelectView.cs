using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class StoreSelectView : MonoBehaviour
{
	// field
	[SerializeField] Text selectedStoreName;
	[SerializeField] StoreElement[] storeElementSet;
	[SerializeField] GameManager manager;
	// game object type field
	[SerializeField] GameObject storeCreatePopUp;

	void Awake()
	{
		LinkComponentElement();
	}

	// link component element
	public void LinkComponentElement()
	{
		selectedStoreName = GetComponentInChildren<Text>();
		storeElementSet = GetComponentsInChildren<StoreElement>();
		manager = GameObject.Find( "GameLogic" ).GetComponent<GameManager>();
		storeCreatePopUp = transform.Find( "StoreCreatePopUp" ).gameObject;
		storeCreatePopUp.SetActive( false );
	}

	// update this ui component
	public void UpdateUIComponent()
	{
		int i = 0;
		foreach ( StoreElement element in storeElementSet )
		{
			try
			{
				element.UpdateStoreElement( manager.PlayerData.HaveStore[i] );			
			}
			catch ( ArgumentException e )
			{				
				element.ClearComponent();
			}
			finally
			{
				i++;
			}
		}
	}

	// set present store in game manager
	public void SetPresentStore( Store data )
	{
		manager.SetPresentStore( data );
	}

	// on click method -> pop up create store
	public void OnClickCreateStore()
	{
		storeCreatePopUp.SetActive( true );
	}

	// on click method -> start game
	public void OnClickStartGame()
	{
		manager.GameStart();
	}
}
