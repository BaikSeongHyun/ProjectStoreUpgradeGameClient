using System;
using UnityEngine;

[System.Serializable]
public class Item
{
	// primary key
	[SerializeField] string id;

	// elements
	[SerializeField] string name;
	[SerializeField] int price;
	[SerializeField] float makeTime;
	[SerializeField] String[] recipe;
	[SerializeField] int[] recipeCount;
	[SerializeField] bool onSell;
	[SerializeField] int sellPrice;
	[SerializeField] int sellCount;
	[SerializeField] int count;
	[SerializeField] float storeExp;
	[SerializeField] Store.StoreType type;

	// property
	public string ID { get { return id; } }

	public string Name { get { return name; } }

	public int Price { get { return price; } }

	public float MakeTime { get { return makeTime; } }

	public string[] Recipe { get { return recipe; } }

	public int[] RecipeCount { get { return recipeCount; } }

	public bool OnSell { get { return onSell; } set { onSell = value; } }

	public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }

	public int SellCount { get { return sellCount; } set { sellCount = value; } }

	public int Count { get { return count; } set { count = value; } }

	public Store.StoreType StoreType { get { return type; } set { type = value; } }

	// constructor - no parameter
	public Item()
	{
		id = "0000";
		name = null;
		price = 0;
		makeTime = 0f;
		recipe = null;
		recipeCount = null;
		onSell = false;
		sellPrice = 0;
		sellCount = 0;
		storeExp = 0;
		type = Store.StoreType.Default;
	}

	// constructor = all item parameter
	public Item( string _id, string _name, int _price, float _makeTime, string[] _recipe, int[] _recipeCount, bool _onSell, float _storeExp, Store.StoreType _type )
	{
		id = _id;
		name = _name;
		price = _price;
		makeTime = _makeTime;
		recipe = _recipe;
		recipeCount = _recipeCount;
		onSell = _onSell;
		storeExp = _storeExp;
		type = _type;
	}

	public Item( Item data )
	{
		id = data.id;
		name = data.name;
		price = data.price;
		makeTime = data.makeTime;
		recipe = data.recipe;
		recipeCount = data.recipeCount;
		onSell = data.onSell;
		sellPrice = data.sellPrice;
		sellCount = data.sellCount;
		storeExp = data.storeExp;
		type = data.type;
	}

	public Item( ItemData data )
	{
		id = data.itemID;
		name = data.itemName;
		price = data.price;
		onSell = data.isSell;
		sellPrice = data.sellPrice;
		sellCount = data.sellCount;

		Item tempDataSet = new Item( Database.Instance.FindItemUseID( id ) );

		makeTime = tempDataSet.makeTime;
		recipe = tempDataSet.recipe;
		recipeCount = tempDataSet.recipeCount;
		storeExp = tempDataSet.storeExp;
		type = tempDataSet.type;
	}
}