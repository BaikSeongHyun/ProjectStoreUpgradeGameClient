using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ProduceItemList : MonoBehaviour
{

	[SerializeField]DisplayItem[] produceItemList;

	public void LinkComponentElement()
	{
		produceItemList = GetComponentsInChildren<DisplayItem>();
	}

	public void SelectItemFind(int i){
		
		//produceItemList [i].Itemtext;


	}


//	public void OnPointerDown( PointerEventData eventdata )
//	{
		
		//selectItem.ProduceSelectItem (eventdata);
			



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
			
//	}

			





}
