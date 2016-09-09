using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Database
{
	private Dictionary<int , Item> itemInformation;
	private static Database databaseInstance = null;

	static Database() 
	{
		databaseInstance = new Database ();
	}

	private Database ()
	{
		itemInformation = new Dictionary<int, Item> ();
		InputItemData ();
	}

	public static Database Instance { get { return databaseInstance; } }

	void InputItemData()
	{
		Item[] recipe;
		int[] recipeCount;
		itemInformation.Add (0001, new Item (0001, "소보로빵", 0, 0, null, null, false, 0, Store.StoreType.Bakery));

		recipe = new Item[1];
		recipe [0] = FindItemUseID (0001);
		recipeCount = new int[1];
		recipeCount[0] = 3;
		itemInformation.Add (0002, new Item(0002, "죽빵", 1000, 10f, recipe, recipeCount, false, 100, Store.StoreType.Bakery));
		recipe [0] = FindItemUseID (0002);
		recipeCount = new int[1]; 
		recipeCount[0] = 3;

	}

	public Item FindItemUseID(int id)
	{
		Item result = new Item ();
		itemInformation.TryGetValue (id, out result);

		return result;
	}

}