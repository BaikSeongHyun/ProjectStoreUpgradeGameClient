using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameViewSecondStep : MonoBehaviour
{
	public SecondStepMode presentMode;
	public GameObject createPopUp;
	public GameObject inventoryPopUp;
	public Image settingImage;
	public Image scrollBarItemImage;
	public GameObject itemSetting;
	public ElfCharacter elf;
	public Text moneyText;
	public int sellPrice = 0;

	public enum SecondStepMode
	{
		NormalStep,
		AuctionStep}
;
	// property
	public ElfCharacter Elf { get { return this.elf; } set { elf = value; } }

	public Text MoneyText { get { return this.moneyText; } set { moneyText = value; } }

	public SecondStepMode PresentMode {	get { return presentMode; } }

	public int SellPrice { get { return this.sellPrice; } set { sellPrice = value; } }

	void Start()
	{
		Instantiate( Resources.Load<GameObject>( "UIObject/CharcterManager" ), transform.position, transform.rotation );
		LinkElementComponent();	
	}

	public void LinkElementComponent()
	{		
		createPopUp = GameObject.Find( "SecondStepCreatePopUp" );
		inventoryPopUp = GameObject.Find( "SellInventory" );
		settingImage = transform.Find( "SellItemSetting" ).Find( "ItemImage" ).GetComponent<Image>();
		scrollBarItemImage = createPopUp.transform.Find( "CreateItemImage" ).GetComponent<Image>();

		createPopUp.SetActive( false );
		inventoryPopUp.SetActive( false );
		itemSetting.SetActive( false );

		moneyText = transform.Find( "SellItemSetting" ).Find( "PriceText" ).GetComponent<Text>();
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
		inventoryPopUp.SetActive( true );
	}

	public void InitializeModeNormalStep()
	{
		inventoryPopUp.SetActive( false );
		itemSetting.SetActive( false );
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

	public void OnClickCreatePopUp()
	{		
		createPopUp.SetActive( !createPopUp.activeSelf );
	}

	public void OnClickInventoryPopUp()
	{
		inventoryPopUp.SetActive( !inventoryPopUp.activeSelf );
	}
}