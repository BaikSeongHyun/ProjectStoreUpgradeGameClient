using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RecipeItemSet: MonoBehaviour
{
	[SerializeField] RecipeDisplayItem[] recipeItem; // item recipe maxlength ^
	[SerializeField] ItemView itemView;

	private GameObject[] recipeItemCountObject;

	public void LinkComponentElement()
	{
		recipeItem = GetComponentsInChildren<RecipeDisplayItem>();
		itemView.LinkComponentElement();

	}

	//middle bridge part method;
	public void SendItemViewItemUpdate( Item selectedData, Player playerData )
	{
		Debug.Log( "this infomation get form ProduceItemListClick -> produceViewSet and Send to Itemview" );
		itemView.UpdateProducingIteamInfo( selectedData );
		int i;
		for(i = 0; i < selectedData.Recipe.Length; i++) {
			recipeItem [i].UpdateComponent (selectedData.Recipe [i], selectedData.RecipeCount[i], playerData);
		}
		//need test
		for (int j = i; j < recipeItem.Length; j++) {
			recipeItem [j].ClearComponent ();
		}
	}




}
