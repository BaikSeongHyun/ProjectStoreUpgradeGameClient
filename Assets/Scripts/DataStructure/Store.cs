using System;
using UnityEngine;

[System.Serializable]
public class Store
{
	// field
	[SerializeField] string name;
	[SerializeField] StoreType type;
	[SerializeField] int step;
	[SerializeField] float presentEXP;
	[SerializeField] float requireEXP;
	Item[] createItem;
	DecorateObject allocatedObject;

	// property
	public string StoreName { get { return name; } }

	public int Step { get { return step; } }

	public float PresentEXP { get { return presentEXP; } }

	public float RequireEXP { get { return requireEXP; } }

	public float FillEXP { get { return ( presentEXP / requireEXP ); } }

	public Item[] CreateItemSet { get { return createItem; } }


	public enum StoreType
	{
		Bakery,
		Cafe,
		FastFoodRestaurant,
		Bar}
;

	public Store( string _name, StoreType _type )
	{
		name = _name;
		type = _type;
	}
}


