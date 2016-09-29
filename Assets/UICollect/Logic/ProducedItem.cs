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

	[SerializeField] Item selectItem;
//sellectItem coll;

	public void PlayerHaveItemUpdata( Player data )
	{
//		producedItemList = new PlayerDisplayItem[data.HaveItem.Count];
//		for ( int i = 0; i < playerdata.HaveItem.Count; i++ )
//		{
//			producedItemList[i].LinkComponentElement();
//			producedItemList[i].UpdateComponentElement( data.HaveItem[i] );
//		}

		producedItemList = GetComponentsInChildren<PlayerDisplayItem> ();

	}

	public void LinkComponentElement()
	{
		producedItemList = GetComponentsInChildren<PlayerDisplayItem> ();
		selectItem = transform.GetComponentInParent<SellViewSet>().GetSellSelectItem();
		PlayerHaveItemUpdata (playerdata);

	}

	public void SelectItem(Item selectedItemData)
	{	
		selectItem = selectedItemData;
		for (int i = 0; i < producedItemList.Length; i++) 
		{
			if (producedItemList [i].ThisItem == selectItem) {
				producedItemList [i].IsSelected = true;

				Debug.Log ("this infomation get form ProduceItemListClick -> ProduceItemList and Send to DisplayItem[i] sellect check;");
			}
			else if (producedItemList [i].ThisItem != selectItem) 
			{
				producedItemList [i].IsSelected = false;
			}

				Debug.Log (producedItemList [0].IsSelected);



		}


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
