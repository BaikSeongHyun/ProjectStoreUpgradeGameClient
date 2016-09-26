using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SecondStepUI : MonoBehaviour
{
	public SecondStepMode presentMode;
	public GameObject recipeInventory;
	public bool inventoryButton = false;
	public bool needItemButton = false;

	public GameObject auctionUI;
	public GameObject itemSetting;

	public ElfCharacter elf;

	public Text moneyText;

	public int sellPrice = 0;

	// Use this for initialization
	public enum SecondStepMode
	{
		NormalStep,
		AuctionStep
	};

	public SecondStepMode PresentMode
	{
		get{ return presentMode; }
	}

	void Start () 
	{
		LinkElement ();	
	}
		
	// Update is called once per frame

	void LinkElement()
	{
		
		recipeInventory = GameObject.Find ("RecipeUI");
		recipeInventory.SetActive (inventoryButton);
		elf = GameObject.Find ("PlayerElf").GetComponent<ElfCharacter> ();
		auctionUI = GameObject.Find ("PopUpSellItem");
		itemSetting = GameObject.Find ("ItemSetting");
		auctionUI.SetActive (false);
		itemSetting.SetActive (false);


		moneyText = transform.Find ("ItemSetting").Find ("PriceText").GetComponent<Text> ();

	}

	public void ChangeSecondUIMode(SecondStepMode UIMode)
	{
		switch (UIMode)
		{
		case SecondStepMode.AuctionStep:
			InitializeModeAuctionStep ();
			break;

		case SecondStepMode.NormalStep:
			InitializeModeNormalStep ();
			break;
		}
	}
	public void InitializeModeAuctionStep()
	{
		//CashModeOn ();
		auctionUI.SetActive (true);
	}
	public void InitializeModeNormalStep()
	{
		auctionUI.SetActive (false);
	}

	public void RecipeModeOn()
	{		
		if (!inventoryButton)
		{
			inventoryButton = true;
			recipeInventory.SetActive (inventoryButton);
		}
		else if(inventoryButton)
		{
			inventoryButton = false;
			recipeInventory.SetActive (inventoryButton);
		}
	}

	public void ItemPrice()
	{
		itemSetting.SetActive (true);	
	}

	public void ItemPricePlus()
	{
		sellPrice += 100;
		moneyText.text =  sellPrice+ "원";
	}

	public void ItemPriceMinus()
	{
		if (sellPrice <= 0)
		{
			sellPrice = 0;
		}
		else
		{
			sellPrice -= 100;
		}
		moneyText.text = sellPrice + "원";
	}
	public void ItemSettingExit()
	{
		itemSetting.SetActive (false);
	}

//	public void CashModeOn()
//	{
//		if (!needItemButton)
//		{
//			needItemButton = true;
//			needItem.SetActive (needItemButton);
//
//			inventoryButton = true;
//			recipeInventory.SetActive (inventoryButton);
//		}
//		else if (needItemButton)
//		{
//			
//			needItemButton = false;
//			needItem.SetActive (needItemButton);
//
//			inventoryButton = false;
//			recipeInventory.SetActive (inventoryButton);
//		}
//	}
}