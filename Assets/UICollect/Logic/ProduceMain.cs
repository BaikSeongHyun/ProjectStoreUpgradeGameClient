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

	[SerializeField] public UserInterfaceController UIController;
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
		 //manager.UpdateItem(itemdata);
		Debug.Log ("produceItemButtonClick");

		UIController = GameObject.Find( "MainUI" ).GetComponent<UserInterfaceController>();

		UIController.MakeGameStep( UserInterfaceController.Step.Third );
		Destroy( GameObject.Find( "FirstStepUI" ), 0.5f );








		//++
	}
	//Mothod tree : produceButtonObject -> Buttonevent ->produceItemButtonClick-> Renewadditem

//	public void RenewAddItem(Player playerData, Item item)
//	{
//		//middleprocess need;
//		playerData.AddItem (item);
//	}

	//produceableitemMatiral -> button ->DisplayItem.clickdisplayitemselect
	public void ProduceItemListClick(Item selectedData)
	{
		selectItem = selectedData;
		produceItemList.ProduceItemFindClick (selectedData);
		recipeItemList.SendItemViewItemUpdate (selectedData, playerData);
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

