using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ProducedItem : MonoBehaviour,IPointerDownHandler {

	//[SerializeField] private Player playerinfo;


	[SerializeField] DisplayItem[] producedItemList;
	[SerializeField] private Player playerdata;

	public SellViewSet selectItem;//sellectItem coll;

	public void PlayerHaveItemUpdata(Player data){
		producedItemList = new DisplayItem[data.HaveItem.Length];
		for (int i = 0; i < playerdata.HaveItem.Length; i++) {
			producedItemList [i].LinkComponentElement ();
			producedItemList [i].UpdateComponentElement (data.HaveItem[i]);
		}
	}

	public void LinkComponentElement()
	{
		selectItem = GameObject.Find ("Sell").GetComponent<SellViewSet> ();
		
//
//		for (int count = 0; count < producedItemName.Length; count++) {
//			string producedItemNameSearch = "ProducedItemName" + ( count + 1 ).ToString();
//			producedItemName [count] = GameObject.Find (producedItemNameSearch).GetComponent<Text> ();
//			producedItemNameObject [count] = GameObject.Find (producedItemNameSearch);
//
//			string producedItemImageSearch = "ProducedItemImage" + (count + 1).ToString ();
//			producedItemImage [count] = GameObject.Find (producedItemImageSearch).GetComponent<Image> ();
//			producedItemImageObject [count] = GameObject.Find (producedItemImageSearch);
//
	}

		//playerdata = GameObject.Find ("GameManager").GetComponent<GameManager> ().PlayerData;



	//public void HaveItemUpdate(Player playerdate){
//		for(int i = 0; i < playerdate.HaveItem.Length; i++)
//		{	
//			if (playerdate.HaveItem [i].Name == null) {
//				break;
//			}
//			producedItemImage [i].sprite = Resources.Load<Sprite> ("ItemIcon/" + playerdate.HaveItem [i].Name);
//			}
//			Debug.Log (playerdate.HaveItem [0].Name);
		





	public void OnPointerDown(PointerEventData eventdata){
		selectItem.SellSelectItem (eventdata);

		//Debug.Log("a"); clear;



		//for (int count = 0; count < producedItemName.Length; count++) {
			//string producedItemNameSearch = "ProducedItemImage" + (count).ToString (); 
//			if (eventdata.pointerCurrentRaycast.gameObject.name == producedItemNameSearch) {
//				selectObject = eventdata.pointerCurrentRaycast.gameObject;
//
//			}
		}

//	public void OnPointerEnter(PointerEventData eventdata){
//		//for (int count = 0; count < producedItemName.Length; count++) {
//			string producedItemImageSearch = "ProducedItemImage" + (count).ToString (); 
//			if (eventdata.pointerCurrentRaycast.gameObject.name == producedItemImageSearch) {
//			//	popUpText.text = producedItemNameSearch.ToString ();
//				//popUpText.text = producedItemImageSearch;
//				Debug.Log (producedItemImageSearch);
//			}
//
//
//			}
//		}
//
//	public void OnPointerExit(PointerEventData eventdate){
//		Debug.Log ("aa");
//	}

}