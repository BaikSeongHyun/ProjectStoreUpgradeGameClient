using System;
using UnityEngine;

[System.Serializable]
public class Item
{
	// key value
	[SerializeField] int id;

	// 
	[SerializeField] string name;
	[SerializeField] int price;
	[SerializeField] float makeTime;
	[SerializeField] Item[] recipe;
	[SerializeField] int[] recipeCount;
	[SerializeField] bool onDisplay;
	[SerializeField] float storeExp;
	[SerializeField] Store.StoreType Type;

	// property
	public string Name { get { return name;} }

	// constructor - no parameter
	public Item()
	{		
		id = 0000;
		name = null;
	}

	// constructor = all item parameter
	public Item(int _id, string _name, int _price, float _makeTime, Item[] _recipe, int[] _recipeCount, bool _onDisplay, float _storeExp, Store.StoreType _type)
	{
		id = _id;
		name = _name;
	}

	public Item (Item data)
	{
		id = data.id;
		name = data.name;
	}
}

