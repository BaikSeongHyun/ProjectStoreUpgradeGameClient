using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RecipeItemList : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler  {
	[SerializeField] ItemView itemView;

	public RecipeDisplayItem[] recipeItem;

	public Text[] recipeItemCount;
	public Image[] recipeItemImage;




	private GameObject[] recipeItemCountObject;

	public void LinkComponentElement(){
		recipeItemCount = new Text[5];
		recipeItemImage = new Image[5];

		recipeItemCountObject = new GameObject[5];

//		for (int count = 0; count < needItemCount.Length; count++) {
//			string name = "NeedItemCount"+ (count+1).ToString();
//			needItemCount [count] = GameObject.Find (name).GetComponent<Text> ();
//			//needItemImage [count] = GameObject.Find ()
//			needItemCountObject [count] = GameObject.Find (name);
//		}
//
		itemView.LinkComponentElement();

	}

	public void OnPointerDown(PointerEventData eventDate){

		//
	}
	public void OnPointerEnter(PointerEventData eventDate){
		//image change;
	}

	public void OnPointerExit(PointerEventData eventDate){
		//image change;
	}




	//middle bridge part method;
	public void SendItemViewItemUpdate(Item data){
		Debug.Log ("this infomation get form produceableitem -> produceViewSet and Send to Itemview");
		itemView.UpdateProducingIteamInfo (data);
	}


}
