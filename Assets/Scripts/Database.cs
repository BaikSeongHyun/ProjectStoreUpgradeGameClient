using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Database
{
	private Dictionary<string , Item> itemInformation;
	private Dictionary<string , Store> storeInformation;
	private static Database databaseInstance = null;

	static Database()
	{
		databaseInstance = new Database();
	}

	private Database()
	{
		itemInformation = new Dictionary<string, Item>();
		storeInformation = new Dictionary<string, Store>();
		InputItemData();
		InputStoreData();
	}

	public static Database Instance { get { return databaseInstance; } }

	void InputItemData()
	{
		string[] recipe;
		int[] recipeCount;

		// set field 1 set
		itemInformation.Add( "pro0001", new Item( "pro0001", "hamBread", 500, 0, null, null, false, 0, Store.StoreType.Bakery ) );

		// set field 2 set
		recipe = new string[1];
		recipe[0] = "pro0001";
		recipeCount = new int[1];
		recipeCount[0] = 3;
		itemInformation.Add( "pro0002", new Item( "pro0002", "bambooBread", 1000, 10f, recipe, recipeCount, false, 100, Store.StoreType.Bakery ) );
	}

	void InputStoreData()
	{
		Store temp;
		// store0001
		temp = new Store( "store0001", "Bakery", Store.StoreType.Bakery, 1, 0, 2000f );
		storeInformation.Add( "store0001", temp ); 

		// store0002
		temp = new Store( "store0002", "Coolcafe", Store.StoreType.Cafe, 1, 0, 2000f );
		storeInformation.Add( "store0002", temp );

		temp = new Store( "store0003", "Hotbar", Store.StoreType.Bar, 1, 0, 2000f );
		storeInformation.Add( "store0003", temp );
	}

	public Item FindItemUseID( string id )
	{
		// set item data
		Item result = new Item();
		itemInformation.TryGetValue( id, out result );

		return result;
	}

	public Store FindStoreUseID( string id )
	{
		// set store data
		Store result = new Store();
		storeInformation.TryGetValue( id, out result );

		return result;
	}
}