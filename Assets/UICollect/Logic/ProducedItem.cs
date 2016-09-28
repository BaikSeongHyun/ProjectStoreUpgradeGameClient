using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ProducedItem : MonoBehaviour
{

	//[SerializeField] private Player playerinfo;


	[SerializeField] PlayerDisplayItem[] producedItemList;
	[SerializeField] private Player playerdata;

	public Item selectItem;
//sellectItem coll;

	public void PlayerHaveItemUpdata( Player data )
	{
		producedItemList = new PlayerDisplayItem[data.HaveItem.Count];
		for ( int i = 0; i < playerdata.HaveItem.Count; i++ )
		{
			producedItemList[i].LinkComponentElement();
			producedItemList[i].UpdateComponentElement( data.HaveItem[i] );
		}
	}

	public void LinkComponentElement()
	{
		selectItem = transform.GetComponentInParent<SellViewSet>().GetSellSelectItem();
		//selectItem = GameObject.Find ("Sell").GetComponent<SellViewSet> ();

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
		





	//	public void OnPointerDown(PointerEventData eventdata){
	//selectItem.SellSelectItem (eventdata);

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

//}