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

		// set igd item input;
		itemInformation.Add( "igd0001", new Item( "igd0001", "water", 0, 0f, null, null, false, 50, Store.StoreType.Bakery ) );
		itemInformation.Add( "igd0002", new Item( "igd0002", "milk", 0, 0f, null, null, false, 50, Store.StoreType.Bakery ) );
		itemInformation.Add( "igd0003", new Item( "igd0003", "condensedmilk", 0, 0f, null, null, false, 50, Store.StoreType.Bakery ) );
		itemInformation.Add( "igd0004", new Item( "igd0004", "adzuki", 0, 0f, null, null, false, 50, Store.StoreType.Bakery ) );
		itemInformation.Add( "igd0005", new Item( "igd0005", "rye", 0, 0f, null, null, false, 50, Store.StoreType.Bakery ) );
		itemInformation.Add( "igd0006", new Item( "igd0006", "wheat", 0, 0f, null, null, false, 50, Store.StoreType.Bakery ) );
		itemInformation.Add( "igd0007", new Item( "igd0007", "ham", 0, 0f, null, null, false, 50, Store.StoreType.Bakery ) );
		itemInformation.Add( "igd0008", new Item( "igd0008", "sugar", 0, 0f, null, null, false, 50, Store.StoreType.Bakery ) );
		//image - > resource -> itemImage;

		// set field 1 set
		itemInformation.Add( "pro0001", new Item( "pro0001", "hamBread", 500, 0, null, null, false, 0, Store.StoreType.Bakery ) );

		// set field 2 set
		recipe = new string[3];
		recipe[0] = "igd0001";
		recipe[1] = "igd0006";
		recipe[2] = "igd0008";
		recipeCount = new int[3];
		recipeCount[0] = 2;
		recipeCount[1] = 1;
		recipeCount[2] = 1;

		itemInformation.Add( "pro0002", new Item( "pro0002", "bambooBread", 1000, 10f, recipe, recipeCount, false, 100, Store.StoreType.Bakery ) );

		recipe = new string[3];
		recipe[0] = "igd0002";
		recipe[1] = "igd0006";
		recipe[2] = "igd0008";
		recipeCount = new int[3];
		recipeCount[0] = 2;
		recipeCount[1] = 2;
		recipeCount[2] = 1;
		itemInformation.Add( "pro0003", new Item( "pro0003", "bageteBread", 1500, 3f, recipe, recipeCount, false, 50, Store.StoreType.Bakery ) );

		recipe = new string[3];
		recipe[0] = "igd0002";
		recipe[1] = "igd0006";
		recipe[2] = "igd0008";
		recipeCount = new int[3];
		recipeCount[0] = 2;
		recipeCount[1] = 1;
		recipeCount[2] = 3;
		itemInformation.Add( "pro0004", new Item( "pro0004", "adzukiBread", 2000, 6f, recipe, recipeCount, false, 10, Store.StoreType.Bakery ) );
	}

	void InputStoreData()
	{
		Store temp;
		// store0001
		temp = new Store( "store0001", "bakery", Store.StoreType.Bakery, 1, 0, 2000f );
		temp.AddItemList( FindItemUseID( "pro0001" ) );
		temp.AddItemList( FindItemUseID( "pro0002" ) );
		temp.AddItemList( FindItemUseID( "pro0003" ) );
		storeInformation.Add( "store0001", temp ); 

		// store0002
		temp = new Store( "store0002", "coolcafe", Store.StoreType.Cafe, 1, 0, 2000f );
		storeInformation.Add( "store0002", temp );

		temp = new Store( "store0003", "hotbar", Store.StoreType.Bar, 1, 0, 2000f );
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