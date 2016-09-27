using System;
using System.Collections;
using System.Collections.Generic;

public class DataTable
{
	private Dictionary<string , Item> itemInformation;
	private static DataTable dataTableInstance = null;

	static DataTable() 
	{
		dataTableInstance = new DataTable ();
	}

	private DataTable ()
	{
		itemInformation = new Dictionary<string, Item> ();
		InputItemData ();
	}

	public static DataTable Instance { get { return dataTableInstance; } }

	void InputItemData()
	{
		Item[] recipe;
		int[] recipeCount;
		itemInformation.Add ("Pro0001", new Item ("Pro0001", "소보로빵", 0, 0, null, null, false, 0, Store.StoreType.Bakery));

		recipe = new Item[1];
		recipe [0] = FindItemUseID ("Pro0001");
		recipeCount = new int[1];
		recipeCount[0] = 3;
		itemInformation.Add ("Pro0002", new Item("Pro0002", "죽빵", 1000, 10f, recipe, recipeCount, false, 100, Store.StoreType.Bakery));
		recipe [0] = FindItemUseID ("Pro0002");
		recipeCount = new int[1]; 
		recipeCount[0] = 3;

	}

	public Item FindItemUseID(string id)
	{
		Item result = new Item ();
		itemInformation.TryGetValue (id, out result);

		return result;
	}

}