using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoreElement : MonoBehaviour
{
	[SerializeField] Image elementStoreImage;
	[SerializeField] bool isDataLoad;
	[SerializeField] bool isSelected;

	void Awake()
	{
		LinkComponentElement();
	}

	public void LinkComponentElement()
	{
		elementStoreImage = GetComponentInChildren<Image>();
	}

	// update use storedata
	public void UpdateStoreElement( Store data )
	{

	}

	// clear component for null data
	public void ClearComponent()
	{

	}
	// on click method -> store select;
	public void OnClickStoreSelect()
	{
	}
}
