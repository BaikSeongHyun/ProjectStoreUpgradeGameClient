using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameViewSecondStep : MonoBehaviour
{
	public SecondStepMode presentMode;
	public GameObject recipeInventory;
	public bool inventoryButton = false;
	public bool needItemButton = false;
	public Image settingImage;
	public Image scrollBarItemImage;

	public GameObject auctionUI;
	public GameObject itemSetting;

	public ElfCharacter elf;

	public Text moneyText;

	public int sellPrice = 0;

	// Use this for initialization
	public enum SecondStepMode
	{
		NormalStep,
		AuctionStep}
;

	public ElfCharacter Elf {
		get {
			return this.elf;
		}
		set { elf = value; }
	}

	public Text MoneyText {
		get {
			return this.moneyText;
		}
		set { moneyText = value; }
	}

	public SecondStepMode PresentMode
	{
		get{ return presentMode; }
	}

	void Start()
	{
		Instantiate( Resources.Load<GameObject>( "UIObject/CharcterManager" ), transform.position, transform.rotation );

		LinkElement();	
	}
		
	// Update is called once per frame

	void LinkElement()
	{
		
		recipeInventory = GameObject.Find( "RecipeUI" );
		recipeInventory.SetActive( inventoryButton );
		//elf = GameObject.Find ("PlayerElf").GetComponent<ElfCharacter> ();
		settingImage = transform.Find( "ItemSetting" ).Find( "ItemImage" ).GetComponent<Image>();
		scrollBarItemImage = transform.Find( "RecipeUI" ).Find( "ItemImage" ).GetComponent<Image>();
		auctionUI.SetActive( false );
		itemSetting.SetActive( false );


		moneyText = transform.Find( "ItemSetting" ).Find( "PriceText" ).GetComponent<Text>();

	}

	public void ChangeSecondUIMode( SecondStepMode UIMode )
	{
		switch ( UIMode )
		{
			case SecondStepMode.AuctionStep:
				InitializeModeAuctionStep();
				break;

			case SecondStepMode.NormalStep:
				InitializeModeNormalStep();
		
				break;
		}
	}

	public void InitializeModeAuctionStep()
	{
		//CashModeOn ();
		auctionUI.SetActive( true );
	}

	public void InitializeModeNormalStep()
	{
		auctionUI.SetActive( false );
		itemSetting.SetActive( false );
	}

	public void RecipeModeOn()
	{		
		if( !inventoryButton )
		{
			inventoryButton = true;
			recipeInventory.SetActive( inventoryButton );
		}
		else if( inventoryButton )
		{
			inventoryButton = false;
			recipeInventory.SetActive( inventoryButton );
		}
	}

	public void ItemPrice( string ItemImage )
	{
		itemSetting.SetActive( true );

		switch ( ItemImage )
		{
			case "FirstImage":
				settingImage.sprite = Resources.Load<Sprite>( "ItemImage\\ItemIconBreadBagaete" );
				break;
			case "SecondImage":
				settingImage.sprite = Resources.Load<Sprite>( "ItemImage\\ItemIconBreadBear" );
				break;
		}
	}

	public int SellPrice {
		get {
			return this.sellPrice;
		}
		set { sellPrice = value; }
	}

	public void ItemPricePlus()
	{
		
		sellPrice += 100;
		moneyText.text = sellPrice + "원";
	}

	public void ItemPriceMinus()
	{
		if( sellPrice <= 0 )
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
		itemSetting.SetActive( false );
	}

	public void ScrollBarItemImageChange( string name )
	{
		switch ( name )
		{

			case "BreadBagaete":
				scrollBarItemImage.sprite = Resources.Load<Sprite>( "ItemImage\\ItemIconBreadBagaete" );
				break;

			case "BreadBear":
				scrollBarItemImage.sprite = Resources.Load<Sprite>( "ItemImage\\ItemIconBreadBear" );
				break;

			case "BreadBream":
				scrollBarItemImage.sprite = Resources.Load<Sprite>( "ItemImage\\ItemIconBreadBream" );
				break;

			case "BreadCastela":
				scrollBarItemImage.sprite = Resources.Load<Sprite>( "ItemImage\\ItemIconBreadCastela" );
				break;

			case "BreadHarbang":
				scrollBarItemImage.sprite = Resources.Load<Sprite>( "ItemImage\\ItemIconBreadHarbang" );
				break;

			case "BreadMoka":
				scrollBarItemImage.sprite = Resources.Load<Sprite>( "ItemImage\\ItemIconBreadMoka" );
				break;

		}
		
	}

	public void UpdateUIComponent()
	{

	}
}