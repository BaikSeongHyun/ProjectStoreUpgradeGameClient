using UnityEngine;
using System;

[System.Serializable]
public class Player
{
	//key value
	[SerializeField] string playerID;

	//dependant value
	[SerializeField] string password;
	[SerializeField] int money;
	[SerializeField] Store[] haveStore;
	[SerializeField] Item[] haveItem;
	[SerializeField] DecorateObject[] haveDecorateObject;

	// property
	public int Money { get { return money; } }

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

//	public bool SubtrackItem(Item data){
//		for (int i = 0; i < haveItem.Length; i++) {
//			if (haveItem [i] == data) {
//				haveItem [i].Count -= 1;
//				if (haveItem [i].Count == 0) {
//				
//				}
//			}
//		}
//	}



}


