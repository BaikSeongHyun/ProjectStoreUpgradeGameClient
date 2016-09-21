using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class SellButton : MonoBehaviour,IPointerDownHandler 
{	
	
	[SerializeField] GameObject sellButton;
	[SerializeField] Item selectItem;
	[SerializeField] bool isSellingAble;
	//test
	[SerializeField] SellViewSet sell;


	public void SellSelctItemGet(Item item)
	{
		selectItem = sell.GetSellSelectItem();
		if (selectItem.Count != 0) {
			isSellingAble = true;
		} else
			isSellingAble = false;
	}

	public void LinkComponentElement()
	{
		sell = GameObject.Find ("Sell").GetComponent<SellViewSet> ();
		sellButton = this.gameObject;
		//isSellingAble = false;
		//test
		isSellingAble = true;
	}




	public void OnPointerDown(PointerEventData eventdate){
//		if (isSellingAble) {
			if (eventdate.pointerCurrentRaycast.gameObject.name == "SellButton") {
				//sellItem;

				//sell.SellItem (eventdate);
				//selltest;
				Debug.Log("click");
			}
//		}
	}

}

