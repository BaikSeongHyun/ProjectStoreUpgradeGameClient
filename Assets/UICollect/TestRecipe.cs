using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestRecipe : MonoBehaviour{

	//storetypename, price, storeExp, makeTime, recipeCount, recipe, onDisplay

	public int storeTypeName;
	public int price;
	public float storeExp;
	public float makeTime;
	public int recipeCount;
	public Text[,] recipe;
	public int onDisplay;

	public string[] needItemName;

	public TestRecipe()
	{
		storeTypeName = 0;
		price = 0;
		storeExp = 0;
		makeTime = 0f;
		recipeCount = 0;
		//recipe[0,0] = new Text[, ]; 
		onDisplay = 0;
	
	}





//	public TestRecipe(int _storeTypeName, int _price, float _storeExp, float _makeTime, int _recipeCount, int[] _recipe, int _onDisplay)
//	{
//		storeTypeName = _storeTypeName;
//		price = _price;
//		storeExp = _storeExp;
//		makeTime = _makeTime;
//		recipeCount = _recipeCount;
//		recipe [0] = _recipe [0];
//		recipe [1] = _recipe [1];
//		recipe [2] = _recipe [2];
//		recipe [3] = _recipe [3];
//		recipe [4] = _recipe [4];
//		recipe [5] = _recipe [5];
//		recipe [6] = _recipe [6];
//		recipe [7] = _recipe [7];
//		onDisplay = 0;
//
//	}
//
//	public TestRecipe(TestRecipe _date)
//	{
//		storeTypeName = _date.storeTypeName;
//		price = _date.price;
//		storeExp = _date.storeExp;
//		makeTime = _date.makeTime;
//		recipeCount = _date.recipeCount;
//		recipe [0] = _date.recipe [0];
//		recipe [1] = _date.recipe [1];
//		recipe [2] = _date.recipe [2];
//		recipe [3] = _date.recipe [3];
//		recipe [4] = _date.recipe [4];
//		recipe [5] = _date.recipe [5];
//		recipe [6] = _date.recipe [6];
//		recipe [7] = _date.recipe [7];
//		onDisplay = 0;
//	}


//	public TestRecipe(){
//	}




}

//
//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//
//[System.Serializable]
//public class Item
//{
//	//id
//	public int id;
//
//	//name
//	public string name;
//
//	//icon
//	public Sprite icon;
//
//	//data
//	public int price;
//	public int coreRank;
//	public int weaponAtk;
//	public int weaponDef;
//	public int weaponStr;
//	public int weaponDex;
//	public int weaponInt;
//	public int weaponLuck;
//	public int weaponCri;
//	public Section section;
//	public Rarity rareRank;
//
//	//property
//	public int Id
//	{
//		get { return id; }
//	}
//
//	public string Name
//	{
//		get { return name; }
//	}
//
//	public Sprite Icon
//	{
//		get { return icon; }
//	}
//
//	public int Price
//	{
//		get { return price; }
//	}
//
//	public int CoreRank
//	{
//		get { return coreRank; }
//	}
//
//	public int WeaponAtk
//	{
//		get { return weaponAtk; }
//	}
//
//	public int WeaponDef
//	{
//		get { return weaponDef; }
//	}
//
//	public int WeaponStr
//	{
//		get { return weaponStr; }
//	}
//
//	public int WeaponDex
//	{
//		get { return weaponDex; }
//	}
//
//	public int WeaponInt
//	{
//		get { return weaponInt; }
//	}
//
//	public int WeaponLuck
//	{
//		get { return weaponLuck; }
//	}
//
//	public int WeaponCri
//	{
//		get { return weaponCri; }
//	}
//
//	public Section InstallSection
//	{
//		get { return section; }
//	}
//
//	public Rarity RareRank
//	{
//		get { return rareRank; }
//	}
//
//	public enum Rarity{
//		Default,
//		Normal,
//		Rare,
//		Unique,
//		Legendary}
//	;
//
//	public enum Section
//	{
//		Top,
//		Bottom,
//		Blade,
//		Handle,
//		Consume,
//		Default}
//
//	;
//
//	//constructor - no parameter
//	public Item ()
//	{
//		id = 0;
//		name = "Default";
//		price = 0;
//		coreRank = 0;
//		weaponAtk = 0;
//		weaponDef = 0;
//		weaponStr = 0;
//		weaponDex = 0;
//		weaponInt = 0;
//		weaponLuck = 0;
//		weaponCri = 0;
//		section = Section.Default;
//		rareRank = Rarity.Default;
//	}
//
//	//constructor - all parameter
//	public Item (int _id, string _name, int _price, int _coreRank, int _weaponAtk, int _weaponDef, int _weaponStr, int _weaponDex, int _weaponInt, int _weaponLuck, int _weaponCri, Section _section, Rarity _rareRank)
//	{
//		id = _id;
//		name = _name;
//		price = _price;
//		coreRank = _coreRank;
//		weaponAtk = _weaponAtk;
//		weaponDef = _weaponDef;
//		weaponStr = _weaponStr;
//		weaponDex = _weaponDex;
//		weaponInt = _weaponInt;
//		weaponLuck = _weaponLuck;
//		weaponCri = _weaponCri;
//		section = _section;
//		rareRank = _rareRank;
//	}
//
//
//	//constructor - self parameter
//	public Item (Item data)
//	{
//		id = data.id;
//		name = data.name;
//		price = data.price;
//		coreRank = data.coreRank;
//		weaponAtk = data.weaponAtk;
//		weaponDef = data.weaponDef;
//		weaponStr = data.weaponStr;
//		weaponDex = data.weaponDex;
//		weaponInt = data.weaponInt;
//		weaponLuck = data.weaponLuck;
//		weaponCri = data.weaponCri;
//		section = data.section;
//		rareRank = data.rareRank;
//		icon = data.icon;
//	}
//
//	//another method
//
//	//set icon
//	public void SetSpriteIcon()
//	{
//		string path = "Item/Item" + name;
//		Sprite temp = Resources.Load<Sprite>( path );
//		icon = temp;
//	}
//
//	public Color SetTextColor()
//	{
//		switch (rareRank)
//		{
//		case Rarity.Legendary:
//			return new Color ( 1f, 0.5f, 0.0f, 1f );
//		case Rarity.Unique:
//			return Color.magenta;
//		case Rarity.Rare:
//			return Color.yellow;
//		case Rarity.Normal:
//			return Color.white;
//		}
//
//		return Color.clear;
//	}
//
//	public string SetRarityText()
//	{
//		switch (rareRank)
//		{
//		case Rarity.Legendary:
//			return "[Legendary]";
//		case Rarity.Unique:
//			return "[Unique]";
//		case Rarity.Rare:
//			return "[Rare]";
//		case Rarity.Normal:
//			return"[Normal]";
//		}
//
//		return null;
//	}
//
//	public void SetDefault()
//	{
//		id = 0;
//		name = "Default";
//		price = 0;
//		coreRank = 0;
//		weaponAtk = 0;
//		weaponDef = 0;
//		weaponStr = 0;
//		weaponDex = 0;
//		weaponInt = 0;
//		weaponLuck = 0;
//		weaponCri = 0;
//		section = Section.Default;
//	}
//
//}