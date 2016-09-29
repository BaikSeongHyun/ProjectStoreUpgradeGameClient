using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProduceMain : MonoBehaviour
{	
	//this class control;
	[SerializeField] ProduceItemList produceItemList;
	[SerializeField] RecipeItemSet recipeItemList;
	[SerializeField] GameManager manager;

	[SerializeField] public UserInterfaceController mainUI;
	//link
	public void LinkComponentElement()
	{
		manager = GameObject.Find ("GameLogic").GetComponent<GameManager> ();
		produceItemList.LinkComponentElement();
		recipeItemList.LinkComponentElement();
		Debug.Log ("ProduceMainLink");

	}


	//Mothod tree : produceButtonObject -> Buttonevent ->produceItemButtonClick-> Renewadditem
	public void ProduceItemButtonClick()
	{
		
	}

	public void ProduceItemListClick(Item selectedData)
	{		
		produceItemList.ProduceItemFindClick (selectedData);
		recipeItemList.SendItemViewItemUpdate (selectedData, manager.PlayerData);
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

	}
}

