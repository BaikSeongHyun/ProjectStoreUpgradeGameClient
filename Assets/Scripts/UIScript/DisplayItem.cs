using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayItem : MonoBehaviour
{
	[SerializeField] protected Text itemText;
	[SerializeField] protected Image itemImage;
	[SerializeField] protected Image selectedImage;
	[SerializeField] protected bool isSelected;

	public void LinkComponentElement()
	{
		itemText = GetComponentInChildren<Text>();
		itemImage = transform.Find( "Image" ).GetComponent<Image>();
		selectedImage = transform.Find( "NameBackImage" ).GetComponent<Image>();
		isSelected = false;
	}

	public void UpdateComponentElement( Item data )
	{
		itemText.text = data.Name;
		itemImage.sprite = Resources.Load<Sprite>( "ItemIcon/" + data.Name );

		if( isSelected )
			selectedImage.sprite = Resources.Load<Sprite>( "UIGameViewFirstStep/SelectedItemName" );
		else
			selectedImage.sprite = Resources.Load<Sprite>( "UIGameViewFirstStep/UnselectedItemName" );
	}
}
