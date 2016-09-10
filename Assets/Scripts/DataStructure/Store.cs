using System;

public class Store
{
	string name;
	StoreType type;
	int step;
	Item[] createItem;
	DecorateObject allocatedObject;

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


