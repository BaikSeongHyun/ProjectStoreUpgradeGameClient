using System;

[System.Serializable]
public class Player
{
    //key value
    string playerID;

    //dependant value
    string password;
    string name;
    int money;
    Store[] haveStore;
    Item[] haveItem;
    DecorateObject haveDecorateObject;

    // property
    public string ID { get { return playerID; } set { playerID = value; } }
    public string Password {  get { return password; } set { password = value; } }
    public string Name { get { return name; } set { name = value; } }
    public int Money { get { return money; } set { money = value; } }

    public Item[] HaveItem { get { return haveItem; } }

    public Player()
    {
    }
    
    //constructor ->
    public Player(string _playerID, string _password)
    {
        playerID = _playerID;
        password = _password;
    }

    public Item FindItemByID(string id)
    {
        foreach (Item element in haveItem)
            if (element.ID == id)
                return element;

        return null;
    }

    public bool AddItem(Item data)
    {
        // add haveItem
        for (int i = 0; i < haveItem.Length; i++)
        {
            if (haveItem[i] == null)
            {
                haveItem[i] = new Item(data);
                return true;
            }
        }

        return false;
    }



}


