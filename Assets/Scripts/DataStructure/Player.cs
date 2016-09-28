using System;
using System.Collections.Generic;

[System.Serializable]
public class Player
{
	//key value
	string playerID;

	//dependant value
	string password;
	string name;
	int money;
	List<Store> haveStore;
	List<Item> haveItem;
	DecorateObject haveDecorateObject;

	// property
	public string ID { get { return playerID; } set { playerID = value; } }

	public string Password { get { return password; } set { password = value; } }

	public string Name { get { return name; } set { name = value; } }

	public int Money { get { return money; } set { money = value; } }

	public List<Item> HaveItem { get { return haveItem; } }

	public Player()
	{		
		haveStore = new List<Store>();
		haveItem = new List<Item>();
	}
    
	//constructor -> id, password parameter
	public Player( string _playerID, string _password )
	{
		playerID = _playerID;
		password = _password;

		haveStore = new List<Store>();
		haveItem = new List<Item>();
	}

	// find store - use update
	public bool FindStoreByID( string id, ref Store data )
	{
		foreach ( Store element in haveStore )
		{
			if( element.ID == id )
			{
				data = element;
				return true;
			}
		}
		data = null;
		return false;
	}

	// set store
	public void UpdateStore( StoreData data )
	{
		Store tempData = new Store();
		if( FindStoreByID( data.storeID, ref tempData ) )
		{
			tempData.Step = data.step;
			tempData.PresentEXP = data.presentEXP;
			tempData.RequireEXP = data.requireEXP;
		}
		else
		{
			tempData = new Store( data );
			haveStore.Add( tempData );
		}
	}

	// find item - use ui
	public Item FindItemByID( string id )
	{
		foreach ( Item element in haveItem )
			if( element.ID == id )
				return element;

		return null;
	}

	// find item - use update
	public bool FindItemByID( string id, ref Item data )
	{
		foreach ( Item element in haveItem )
		{
			if( element.ID == id )
			{
				data = element;
				return true;
			}
		}
		data = null;
		return false;
	}

	// set item
	public void UpdateItem( ItemData data )
	{
		Item tempData = new Item();
		if( FindItemByID( data.itemID, ref tempData ) )
		{
			tempData.Count = data.count;
			tempData.OnSell = data.isSell;
			tempData.SellPrice = data.sellPrice;
			tempData.SellCount = data.sellCount;	
		}
		else
		{
			tempData = new Item( data );
			haveItem.Add( tempData );
		}
	}



}


