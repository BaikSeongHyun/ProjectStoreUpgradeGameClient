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

	//produceableitemMatiral -> button ->DisplayItem.clickdisplayitemselect-> produceitemlist -> findclickitem;
	//and check isSelected;
	public void ProduceItemFindClick( Item selectedData )
	{
		for ( int i = 0; i < produceItemList.Length; i++ )
		{
			if( produceItemList[i].ThisItem == selectedData )
			{
				produceItemList[i].IsSelected = true;
				Debug.Log( "this infomation get form ProduceItemListClick -> ProduceItemList and Send to DisplayItem[i] sellect check;" );
			}
			else
				produceItemList[i].IsSelected = false;
		}
	}
}
