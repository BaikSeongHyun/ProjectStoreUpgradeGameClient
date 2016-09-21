using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class DisplayItem : MonoBehaviour
{
	[SerializeField] protected Text itemText;
	[SerializeField] protected Image itemImage;
	[SerializeField] protected Image selectedImage;
	[SerializeField] protected bool isSelected;
	[SerializeField] protected Item thisItem;

	public void LinkComponentElement()
	{
		itemText = GetComponentInChildren<Text>();
		itemImage = transform.Find( "Image" ).GetComponent<Image>();
		selectedImage = transform.Find( "NameBackImage" ).GetComponent<Image>();
		isSelected = false;
	}

	public void UpdateComponentElement( Item data )
	{
		thisItem = data;
		itemText.text = data.Name;
		itemImage.sprite = Resources.Load<Sprite>( "ItemIcon/" + data.Name );

		if( isSelected )
			selectedImage.sprite = Resources.Load<Sprite>( "UIGameViewFirstStep/SelectedItemName" );
		else
			selectedImage.sprite = Resources.Load<Sprite>( "UIGameViewFirstStep/UnselectedItemName" );
	}

	public Text Itemtext
	{
		get { return itemText;}
	}

	public bool IsSelected
	{
		get { return isSelected;}
		set { isSelected = value;}
	}

	public Item ThisItem
	{
		get{ return thisItem;}
	}

	//click Button, this method play a part produceMain method coll;
	public void ClickDisPlayItemSelect()
	{
		ProduceMain produceMain = gameObject.GetComponentInParent<ProduceMain>();
		produceMain.ProduceItemListClick (thisItem);
	}



}
