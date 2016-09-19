using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ItemView : MonoBehaviour {
	[SerializeField]Item SelectItem;

	[SerializeField]Text itemName;
	[SerializeField]Image itemImage;




	public void LinkComponentElement()
	{
//		itemName = GetComponent<Text> ();
//		itemImage = transform.Find ("ItemImage").GetComponent<Image> ();

		//SelectItem = GameObject.Find ("Produce").GetComponent<ProduceViewSet> ().GetProduceSelectItem ();
	}

	public void UpdateProducingIteamInfo(Item selectedData)
	{
		itemName.text = selectedData.Name;
		//path ItemImage/Wheat
		itemImage.sprite = Resources.Load<Sprite> ("ItemImage/" + selectedData.Name);
	}



}
