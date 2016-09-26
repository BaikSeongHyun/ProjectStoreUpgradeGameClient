using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SellViewSet : MonoBehaviour, IPointerDownHandler
{

	[SerializeField]ProducedItem producedItem;
	[SerializeField]Item selectItem;

	// link component element
	public void LinkComponentElement()
	{
		producedItem.LinkComponentElement ();
		//sellButton.LinkComponentElement ();
	}

	//playerDisplayItem -> button -> sellSelectedItem; 
	public void SellSelectedItem(Item selectedData)
	{
		selectItem = selectedData;
		producedItem.LinkComponentElement ();
		Debug.Log ("this infomation get from PlayerDisplayItem");
	}


	public Item GetSellSelectItem(){
		return selectItem;
	}

	//sellButton click
	public void SellButtonClick(){
		Player playerdata;
		//playerdata.HaveItem // 아이템 빼기;
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
