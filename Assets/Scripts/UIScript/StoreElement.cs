using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoreElement : MonoBehaviour
{
	[SerializeField] Image elementStoreImage;
	[SerializeField] Store elementData;
	[SerializeField] StoreSelectView motherUnit;

	void Awake()
	{
		LinkComponentElement();
	}

	public void LinkComponentElement()
	{
		elementStoreImage = GetComponentInChildren<Image>();
		motherUnit = GetComponentInParent<StoreSelectView>();
	}

	// update use storedata
	public void UpdateStoreElement( Store data )
	{
		elementData = data;
		elementStoreImage.sprite = Resources.Load<Sprite>( "StoreImage/" + data.ID );
	}

	// clear component for null data
	public void ClearComponent()
	{
		elementData = null;
		elementStoreImage.sprite = Resources.Load<Sprite>( "StoreImage/DefaultStoreImage" );
	}
	// on click method -> store select;
	public void OnClickStoreSelect()
	{
		motherUnit.SetPresentStore( elementData );
	}
}
