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
	public void SendItemViewItemUpdate( Item selectedData, Player playerData )
	{
		itemView.UpdateProducingIteamInfo( selectedData );
		int i = 0;
		foreach ( RecipeDisplayItem element in recipeItem )
		{
			try
			{
				element.UpdateComponent( selectedData.Recipe[i], selectedData.RecipeCount[i], playerData );
			}
			catch ( Exception e )
			{
				Debug.Log( e.StackTrace );
				Debug.Log( e.Message );
				element.ClearComponent();
			}
			finally
			{
				i++;
			}
		}
	}




}
