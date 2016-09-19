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


	//selectItem need Method;
	public void ProduceSelectItem()
	{
		//iteminfomationgetting from ProduceAbleItem;
		//selectItem = eventdata.pointerCurrentRaycast.gameObject.GetComponent<Item> ();
		Debug.Log( "this infomation get from ProduceAbleItem and send to Itemview" );
		recipeItemList.SendItemViewItemUpdate( selectItem );
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

