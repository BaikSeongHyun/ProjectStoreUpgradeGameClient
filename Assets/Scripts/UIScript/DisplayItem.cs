using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayItem : MonoBehaviour
{
	[SerializeField] protected Text itemText;
	[SerializeField] protected Image itemImage;
	[SerializeField] protected bool isSelected;

	public void LinkComponentElement()
	{
		itemText = GetComponent<Text>();
		itemImage = GetComponent<Image>();
		isSelected = false;
	}

	public void UpdateComponentElement( Item data )
	{
		itemText.text = data.Name;
		itemImage.sprite = Resources.Load<Sprite>( "ItemIcon/" + data.Name );		                                   
	}
}
