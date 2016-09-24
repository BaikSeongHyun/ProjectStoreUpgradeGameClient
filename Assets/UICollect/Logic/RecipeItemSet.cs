using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RecipeItemSet: MonoBehaviour
{
	[SerializeField] RecipeDisplayItem[] recipeItem;
	[SerializeField] ItemView itemView;

	private GameObject[] recipeItemCountObject;

	public void LinkComponentElement()
	{
		recipeItem = GetComponentsInChildren<RecipeDisplayItem>();
		itemView.LinkComponentElement();

	}

	//middle bridge part method;
	public void SendItemViewItemUpdate( Item selectedData )
	{
		Debug.Log( "this infomation get form ProduceItemListClick -> produceViewSet and Send to Itemview" );
		itemView.UpdateProducingIteamInfo( selectedData );
	}


}
