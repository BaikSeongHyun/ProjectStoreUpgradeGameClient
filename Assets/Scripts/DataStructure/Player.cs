using System;

public class Player
{
	//key value
	string playerID;

	//dependant value
	string password;
	int availableMoney;
	Store[] haveStore;
	Item[] haveItem;
	DecorateObject[] haveDecorateObject;

	//constructor -> 
	public Player(string _playerID, string _password)
	{
		playerID = _playerID;
		password = _password;
	}

	public void CreatePlayerStore(string name)
	{
		switch (name)
		{
			case "Bakery":
				
				break; 

			case "Bar":
			
				break;

			case "FastFood":
				
				break;

			case "Cafe":
				
				break;
			
		}
		
	}
}


