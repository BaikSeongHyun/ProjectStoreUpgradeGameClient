using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ProduceAbleItem : MonoBehaviour, IPointerDownHandler {

	[SerializeField]DisplayItem[] produceAbleList;


	[SerializeField] ItemView itemView;
	[SerializeField] RecipeItemList recipeItemList; 
	[SerializeField] RecipeDisplayItem[] selectedItemRecipeList;

//	[SerializeField] Image selectedImage;
//	[SerializeField] Item selectedItem;

//	

	public void ProduceAbleItemList( Store data )
	{
		//create s
		produceAbleList = new DisplayItem[data.CreateItemSet.Length];

		for ( int i = 0; i < produceAbleList.Length; i++ )
		{
			produceAbleList[i].LinkComponentElement();
			produceAbleList[i].UpdateComponentElement( data.CreateItemSet[i] );
		}
	}



	public void UpdateSelectedItem( Player data )
	{
//		selectedImage.sprite = Resources.Load<Sprite>( "ItemIcon/" + selectedItem.Name );
//
//		selectedItemRecipeList = new RecipeDisplayItem[selectedItem.Recipe.Length];
//		for ( int i = 0; i < selectedItemRecipeList.Length; i++ )
//		{
//			selectedItemRecipeList[i].UpdateComponent( selectedItem, selectedItem.RecipeCount[i], data );
//		}

	}

	public void LinkComponentElement()
	{
//		produceAbleItemName = new Text[5];
//		produceAbleItemImage = new Image[5];
//
//		produceAbleItemNameObject = new GameObject[5];
//		produceAbleItemImageObject = new GameObject[5];
//
//
//		for(int count = 0; count < produceAbleItemName.Length; count++)
//		{
//			string produceAbleItemNameSearch = "ProduceAbleItemName" + (count + 1).ToString ();
//			produceAbleItemName [count] = GameObject.Find (produceAbleItemNameSearch).GetComponent<Text>();
//			produceAbleItemNameObject[count] = GameObject.Find(produceAbleItemNameSearch);
//
//			string produceAbleItemImageSearch = "ProduceAbleItemImage" + (count + 1).ToString ();
//			produceAbleItemImage [count] = GameObject.Find (produceAbleItemImageSearch).GetComponent<Image>();
//			produceAbleItemImageObject[count] = GameObject.Find(produceAbleItemImageSearch);
//		}
		//MakingItemName1 = GameObject.Find ("MakingItemName1");
//		MakingItemName2 = GameObject.Find ("MakingItemName2");
//		MakingItemName3 = GameObject.Find ("MakingItemName3");
//		MakingItemName4 = GameObject.Find ("MakingItemName4");
//		MakingItemName5 = GameObject.Find ("MakingItemName5");
//		ItemImage1 = GameObject.Find ("ItemImage1");
//		ItemImage2 = GameObject.Find ("ItemImage2");
//		ItemImage3 = GameObject.Find ("ItemImage3");
//		ItemImage4 = GameObject.Find ("ItemImage4");
//		ItemImage5 = GameObject.Find ("ItemImage5");

		//send to variable for gameobject
		//itemView = GameObject.Find("ProduceAlbeItemView").GetComponent<ItemView> ();
		//recipeItemList = GameObject.Find ("NeedItemList").GetComponent<RecipeItemList> ();
	}

	void ShowView()
	{
//MakingItemName1.text = Database.Instance.FindItemUseID (0001).Name;
	}



	// Use this for initialization
	void Start () {
		//MakingItemName1.text = Database.Instance.FindItemUseID (0001);
		//itemName = GetComponent<Text> ();

	}


	public void OnPointerDown(PointerEventData eventdata){
		



//		for(int count= 0; count < produceAbleItemName.Length; count++){
//			string produceAbleItemNameSearch = "ProduceAbleItemName" + (count).ToString(); 
//
//		if (eventdata.pointerCurrentRaycast.gameObject.name == name) {
//				//select iteminfo send to Itemview,  needitem;
//				itemView.TestCollMe(name,count);
//
//				
//				recipeItemList.TestCollMe (name);
//
//					}
//				}
//			}


//			if (eventdate.pointerCurrentRaycast.gameObject == produceAbleItemNameObject []) {
				
//			}

//		if (eventdate.pointerCurrentRaycast.gameObject == produceAbleItemNameObject) {
			
		}

			





}
