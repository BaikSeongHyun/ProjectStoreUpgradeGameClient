using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RecipeItemSet: MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
	[SerializeField] ItemView itemView;

	[SerializeField] RecipeDisplayItem[] recipeItem;

//	public Text[] recipeItemCount;
//	public Image[] recipeItemImage;


	private GameObject[] recipeItemCountObject;





	public void LinkComponentElement()
	{
		recipeItem = GetComponentsInChildren<RecipeDisplayItem>();


		recipeItemCountObject = new GameObject[5];

		itemView.LinkComponentElement();

	}



	public void OnPointerDown( PointerEventData eventDate )
	{

		//
	}

	public void OnPointerEnter( PointerEventData eventDate )
	{
		//image change;
	}

	public void OnPointerExit( PointerEventData eventDate )
	{
		//image change;
	}




	//middle bridge part method;
	public void SendItemViewItemUpdate( Item data )
	{
		Debug.Log( "this infomation get form produceableitem -> produceViewSet and Send to Itemview" );
		itemView.UpdateProducingIteamInfo( data );
	}


}
