using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SellViewSet : MonoBehaviour, IPointerDownHandler
{

	[SerializeField]ProducedItem producedItem;
	[SerializeField]Item selectItem;

	public Item GetSellSelectItem(){
		return selectItem;
	}

	public void SellSelectItem(){
		//iteminfomationgetting from ProducedItem;
		//selectItem = eventdata.pointerCurrentRaycast.gameObject.GetComponent<Item> ();
		Debug.Log ("this infomation get from ProduceAbleItem and send to Itemview");
		//sellButton.SellSelctItemGet(selectItem);
	}

	//sellbuttonobject -> button -> 
	public void SellButtonClick()
	{
		Debug.Log ("this infomation get from sellbutton and send to ASD");
	}

	// link component element
	public void LinkComponentElement()
	{
		producedItem.LinkComponentElement ();
		//sellButton.LinkComponentElement ();
	}

	// update component element
	public void UpdateComponentElement( Player data )
	{

	}

	public void SellProcess(Player data)
	{
		
	}

	public void OnPointerDown(PointerEventData eventdata)
	{
		
	}



}
