using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Store
{
	// primary key
	[SerializeField] string storeID;

	// elements
	[SerializeField] string name;
	[SerializeField] StoreType type;
	[SerializeField] int step;
	[SerializeField] float presentEXP;
	[SerializeField] float requireEXP;
	[SerializeField] List<Item> createItem;
	[SerializeField] DecorateObject allocatedObject;

	// property
	public string ID { get { return storeID; } }

	public string StoreName { get { return name; } }

	public int Step { get { return step; } set { step = value; } }

	public float PresentEXP { get { return presentEXP; } set { presentEXP = value; } }

	public float RequireEXP { get { return requireEXP; } set { requireEXP = value; } }

	public float FillEXP { get { return ( presentEXP / requireEXP ); } }

	public List<Item> CreateItemSet { get { return createItem; } }


	public enum StoreType : int
    {
		Default = 0,
		Bakery = 1,
		Cafe = 2,
		FastFoodRestaurant = 3,
		Bar = 4}
;

	public Store()
	{
		createItem = new List<Item>();
	}

	public Store( string _name, StoreType _type )
	{
		name = _name;
		type = _type;
		createItem = new List<Item>();
	}

	public Store( string _id, string _name, StoreType _type, int _step, float _presentEXP, float _requireEXP )
	{
		storeID = _id;
		name = _name;
		type = _type;
		step = _step;
		presentEXP = _presentEXP;
		requireEXP = _requireEXP;

		createItem = new List<Item>();
	}

	public Store( Store data )
	{
		storeID = data.storeID;
		name = data.name;
		type = data.type;
		step = data.step;
		presentEXP = data.presentEXP;
		requireEXP = data.requireEXP;
		createItem = data.createItem;

		createItem = new List<Item>();
	}

	public Store( StoreData data )
	{
		storeID = data.storeID;
		name = data.storeName;
		type = SetStoreType( (int) data.storeType );
		step = data.step;
		presentEXP = data.presentEXP;
		requireEXP = data.requireEXP;

		Store tempDataSet = new Store( Database.Instance.FindStoreUseID( storeID ) );
		createItem = tempDataSet.createItem;
	}

	public static StoreType SetStoreType( int type )
	{
		switch ( type )
		{
			case 1:
				return StoreType.Bakery;
			case 2:
				return StoreType.Cafe;
			case 3:
				return StoreType.FastFoodRestaurant;
			case 4:
				return StoreType.Bar;
		}

		return StoreType.Default;
	}

	public void AddItemList( Item data )
	{
		createItem.Add( data );
	}
}


