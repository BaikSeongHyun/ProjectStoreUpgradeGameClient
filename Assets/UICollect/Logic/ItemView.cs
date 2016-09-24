using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemView : MonoBehaviour {
	//[SerializeField]Item selectItem;

	[SerializeField]Text itemName;
	[SerializeField]Image itemImage;




	public void LinkComponentElement()
	{
		itemName = GetComponentInChildren<Text> ();
		itemImage = transform.Find ("SelectItemImage").GetComponent<Image> ();
		//SelectItem = GameObject.Find ("Produce").GetComponent<ProduceViewSet> ().GetProduceSelectItem ();
	}

	public void UpdateProducingIteamInfo(Item selectedData)
	{
		itemName.text = selectedData.Name;
		//path ItemImage/Wheat
		itemImage.sprite = Resources.Load<Sprite> ("ItemImage/" + selectedData.Name);

		Debug.Log( "this infomation get form ProduceItemListClick -> produceViewSet and Send to Itemview -> ItemView Update" );

	}



}
