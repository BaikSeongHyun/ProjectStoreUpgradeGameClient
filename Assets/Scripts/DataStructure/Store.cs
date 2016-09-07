using System;

public class Store
{
	string name;
	StoreType type;
	int step;
	DecorateObject allocatedObject;


	public enum StoreType
	{
		Bakery,
		Cafe,
		FastFoodRestaurant,
		Bar}
;

	public Store ( string _name, StoreType _type)
	{
		name = _name;
		type = _type;
	}
}


