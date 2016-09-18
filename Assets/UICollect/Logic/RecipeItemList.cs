using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RecipeItemList : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler  {
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


	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
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



//	public void TestCollMe(string count, Image image){
	public void TestCollMe(string name){
		Debug.Log ("aa");
	}
}
