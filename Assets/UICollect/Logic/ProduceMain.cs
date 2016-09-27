using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProduceMain : MonoBehaviour
{	
	//this class control;
	[SerializeField] ProduceItemList produceItemList;
	[SerializeField] RecipeItemSet recipeItemList;
	[SerializeField] GameManager manager;
	//feature variable, this variable effected producebutton,itemview;
	[SerializeField] Item selectItem;
	[SerializeField] Player playerData;
	//link
	public void LinkComponentElement()
	{
		manager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		playerData = manager.PlayerData;
		produceItemList.LinkComponentElement();
		recipeItemList.LinkComponentElement();
		Debug.Log ("ProduceMainLink");
	}


	//Mothod tree : produceButtonObject -> Buttonevent ->produceItemButtonClick-> Renewadditem
	public void ProduceItemButtonClick()
	{
		//RenewAddItem(playerData, selectItem);
		// manager.UpdateItem(itemdata);
		Debug.Log ("produceItemButtonClick");
		//++
	}
	//Mothod tree : produceButtonObject -> Buttonevent ->produceItemButtonClick-> Renewadditem

//	public void RenewAddItem(Player playerData, Item item)
//	{
//		//middleprocess need;
//		playerData.AddItem (item);
//	}

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
		Debug.Log ("produceItemListClick");
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

