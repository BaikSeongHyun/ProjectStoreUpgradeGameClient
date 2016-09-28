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
		producedItem.LinkComponentElement();
		//sellButton.LinkComponentElement ();
	}

	//playerDisplayItem -> button -> sellSelectedItem;
	public void SellSelectedItem( Item selectedData )
	{
		selectItem = selectedData;
		//producedItem.LinkComponentElement();
		producedItem.SelectItem(selectedData);
		Debug.Log( "this infomation get from PlayerDisplayItem and send producedItem.SelectItem" );
	}


	public Item GetSellSelectItem()
	{
		return selectItem;
	}

	//sellButton click
	public void SellButtonClick()
	{
		//playerdata.HaveItem // 아이템 빼기;
	}

	// update component element
	public void UpdateComponentElement( Player data )
	{

	}

	public void SellProcess( Player data )
	{
		
	}



	public void OnPointerDown( PointerEventData eventdata )
	{
		
	}



}
