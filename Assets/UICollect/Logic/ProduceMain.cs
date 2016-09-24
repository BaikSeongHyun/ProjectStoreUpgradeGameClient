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


	//Mothod tree : produceButtonObject -> Buttonevent ->produceItemButtonClick-> Renewadditem
	public void ProduceItemButtonClick()
	{
		Player playerData;
		playerData = GameObject.Find ("GameManager").GetComponent<GameManager> ().PlayerData;
		RenewAddItem(playerData, selectItem);
	}
	//Mothod tree : produceButtonObject -> Buttonevent ->produceItemButtonClick-> Renewadditem
	public void RenewAddItem(Player playerData, Item item)
	{
		//middleprocess need;
		playerData.AddItem (item);
	}

	public void ProduceProcess( Player data )
	{
		
//				if( produceItem != null )
//				{
//					produceTime += Time.deltaTime;
//					stateGauge.fillAmount = produceTime / produceItem.MakeTime;
//		
//					if( produceTime >= produceItem.MakeTime )
//					{
//						data.AddItem( produceItem );
//						produceItem = null;
//					}
//				}
	}



	//produceableitemMatiral -> button ->DisplayItem.clickdisplayitemselect
	public void ProduceItemListClick(Item selectedData)
	{
		selectItem = selectedData;
		produceItemList.ProduceItemFindClick (selectedData);
		recipeItemList.SendItemViewItemUpdate (selectedData);
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







}

