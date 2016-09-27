using System;


[System.Serializable]
public class Store
{
    // primary key
    string storeID;

    // elements
    string name;
    StoreType type;
    int step;
    float presentEXP;
    float requireEXP;
    Item[] createItem;
    DecorateObject allocatedObject;

    // property
    public string StoreName { get { return name; } }

    public int Step { get { return step; } }

    public float PresentEXP { get { return presentEXP; } }

    public float RequireEXP { get { return requireEXP; } }

    public float FillEXP { get { return (presentEXP / requireEXP); } }

    public Item[] CreateItemSet { get { return createItem; } }


    public enum StoreType : int
    {
        Bakery = 1,
        Cafe = 2,
        FastFoodRestaurant = 3,
        Bar
    }
;
    public Store()
    {
    }

    public Store(string _name, StoreType _type)
    {
        name = _name;
        type = _type;
    }
}


