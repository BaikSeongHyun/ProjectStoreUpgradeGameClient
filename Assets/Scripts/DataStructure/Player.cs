using UnityEngine;
using System;

[System.Serializable]
public class Player
{
	//key value
	[SerializeField] string playerID;

	//dependant value
	string password;
	int availableMoney;
	Store[] haveStore;
	Item[] haveItem;
	DecorateObject[] haveDecorateObject;

	// property
	public Item[] HaveItem { get { return haveItem; } }

	//constructor ->
	public Player( string _playerID, string _password )
	{
		playerID = _playerID;
		password = _password;
	}

	public Item FindItemByID( int id )
	{
		foreach ( Item element in haveItem )
			if( element.ID == id )
				return element;
	
		return null;	
	}

	public bool AddItem( Item data )
	{
		// add haveItem
		for ( int i = 0; i < haveItem.Length; i++ )
		{
			if( haveItem[i] == null )
			{
				haveItem[i] = new Item( data );
				return true;
			}			   
		}

		return false;
	}



}


