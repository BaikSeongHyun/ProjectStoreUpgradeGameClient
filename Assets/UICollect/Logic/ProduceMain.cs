using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProduceMain : MonoBehaviour
{	
	//this class control;
	[SerializeField] ProduceItemList produceItemList;
	[SerializeField] RecipeItemSet recipeItemList;

	//feature variable, this variable effected producebutton,itemview;
	[SerializeField] Item selectItem;

	//link
	public void LinkComponentElement()
	{
		produceItemList.LinkComponentElement();
		recipeItemList.LinkComponentElement();
	}


	//Mothod tree : produceItemButtonClick-> Renewadditem
	public void ProduceItemButtonClick()
	{
		Player playerData;
		playerData = GameObject.Find ("GameManager").GetComponent<GameManager> ().PlayerData;
		RenewAddItem(playerData, selectItem);
	}
	public void RenewAddItem(Player playerData, Item item)
	{
		playerData.AddItem (item);
	}




	//produceableitemMatiral -> button ->DisplayItem.clickdisplayitemselect
	public void ProduceItemListClick(string itemName)
	{
		//아이템 선택해서 이름추출후 아이템정보에서 검색해 셀렉해야함???;;

		//selectItem.Name = itemName;
	}



	public Item GetProduceSelectItem()
	{
		return selectItem;
	}


	public void ProduceAbleItemListSend( Store data )
	{
		
	}

	// update component element
	public void UpdateSelectedItemSend( Player data )
	{
		
	}

	//button click method
	public void SetProduceItem( Item item )
	{
		// count recipe

//		produceTime = 0.0f;
//		produceItem = selectedItem;

		Debug.Log( "b" );
	}


	public void ProduceProcess( Player data )
	{
		
//		if( produceItem != null )
//		{
//			produceTime += Time.deltaTime;
//			stateGauge.fillAmount = produceTime / produceItem.MakeTime;
//
//			if( produceTime >= produceItem.MakeTime )
//			{
//				data.AddItem( produceItem );
//				produceItem = null;
//			}
//		}
	}




}

