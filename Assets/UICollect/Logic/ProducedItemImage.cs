using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ProducedItemImage : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler{
	public Image producedItemImage;
	[SerializeField] private Item[] playerHaveItemData;
	public Text popUpText;

	void Link()
	{
		producedItemImage = this.gameObject.GetComponent<Image>();
		popUpText = GameObject.Find ("PopUpText").GetComponent<Text> ();
		playerHaveItemData = GameObject.Find ("GameManager").GetComponent<GameManager> ().PlayerData.HaveItem;
	
		if(playerHaveItemData.Length+1 < 10){
		for (int i = 1; i < playerHaveItemData.Length+1; i++) {
				Debug.Log ("a");
			//playerHaveItemData[i]
			string producedItemImageSearch = "ProducedItemImage" + (i + 1).ToString ();

				if (producedItemImageSearch.LastIndexOf(producedItemImageSearch) == i) {
					
				}

//			if (producedItemImageSearch) == i) {
//				producedItemImageSearch=playerHaveItemData[i];
//			}
//		
			}

			if (playerHaveItemData.Length + 1 >= 10) {
			
			}
		}
	}

	//("slot"+n)

	void Start () {
		Link ();

	}
	
	public void OnPointerEnter(PointerEventData eventdata)
	{
		popUpText.text = producedItemImage.name;
		//popUpText.text = playerdata.HaveItem
	}

	public void OnPointerExit(PointerEventData eventdata)
	{
		popUpText.text = "";
	}

}
