using System;

[System.Serializable]
public class Item
{
    // primary key
    string id;

    // elements
    string name;
    int price;
    float makeTime;
    Item[] recipe;
    int[] recipeCount;
    bool onSell;
    int sellPrice;
    int sellCount;
    int count;
    float storeExp;
    Store.StoreType type;

    // property
    public string ID { get { return id; } }
    public string Name { get { return name; } }
    public int Price { get { return price; } }
    public float MakeTime { get { return makeTime; } }
    public Item[] Recipe { get { return recipe; } }
    public int[] RecipeCount { get { return recipeCount; } }
    public bool OnSell { get { return onSell; } }
    public int SellPrice { get { return sellPrice; } set { sellPrice = value; } }
    public int SellCount { get { return sellCount; } set { SellCount = value; } }
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
        recipe = null;
        onSell = false;
        storeExp = 0;
        type = Store.StoreType.Bakery;
    }

    // constructor = all item parameter
    public Item(string _id, string _name, int _price, float _makeTime, Item[] _recipe, int[] _recipeCount, bool _onDisplay, float _storeExp, Store.StoreType _type)
    {
        id = _id;
        name = _name;
        price = _price;
        makeTime = _makeTime;
        recipe = _recipe;
        recipeCount = _recipeCount;
        onSell = _onDisplay;
        storeExp = _storeExp;
        type = _type;
    }

    public Item(Item data)
    {
        id = data.id;
        name = data.name;
        price = data.price;
        makeTime = data.makeTime;
        recipe = data.recipe;
        recipeCount = data.recipeCount;
        onSell = data.onSell;
        storeExp = data.storeExp;
        type = data.type;
    }
}

