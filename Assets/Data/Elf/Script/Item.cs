using System;
using UnityEngine;

public class Item
{
	[SerializeField] int id;
	[SerializeField] string name;
	[SerializeField] int price;
	[SerializeField] float makeTime;
	[SerializeField] Item[] recipe;
	[SerializeField] int[] recipeCount;
	[SerializeField] Store.StoreType Type;

	public Item()
	{
		
	}
}