using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ProducedItemImage : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler	{
	[SerializeField] private Item[] playerHaveItemData;
	public Image producedItemImage;
	public Text popUpText;
	public GameObject popUpMove;
	public Item viewItem;

	void Link()
	{
		producedItemImage = this.gameObject.GetComponent<Image>();
		popUpText = GameObject.Find ("PopUpText").GetComponent<Text> ();
		popUpMove = GameObject.Find ("PopUpText").GetComponent<GameObject> ();
		SlotItemSuchIn ();
	}

	void SlotItemSuchIn()
	{
		playerHaveItemData = GameObject.Find ("GameManager").GetComponent<GameManager> ().PlayerData.HaveItem;
		if(playerHaveItemData.Length+1 < 10){
			for (int i = 1; i < playerHaveItemData.Length+1; i++) {
				Debug.Log ("a");
				//playerHaveItemData[i]
				string producedItemImageSearch = "ProducedItemImage" + (i + 1).ToString ();

				if (producedItemImageSearch.LastIndexOf(producedItemImageSearch) == i) {
					viewItem = playerHaveItemData [i];
				}
			}
		}

		if (playerHaveItemData.Length + 1 >= 10 && playerHaveItemData.Length +1 <20) {
			for (int i = 9; i < playerHaveItemData.Length+1; i++) {
				Debug.Log ("a");
				//playerHaveItemData[i]
				string producedItemImageSearch = "ProducedItemImage" + (i + 1).ToString ();

				if (producedItemImageSearch.LastIndexOf(producedItemImageSearch) == i) {
					viewItem = playerHaveItemData [i];
				}

			}
		}

		if (playerHaveItemData.Length + 1 >= 20 && playerHaveItemData.Length +1 <30) {
			for (int i = 9; i < playerHaveItemData.Length+1; i++) {
				Debug.Log ("a");
				//playerHaveItemData[i]
				string producedItemImageSearch = "ProducedItemImage" + (i + 1).ToString ();

				if (producedItemImageSearch.LastIndexOf(producedItemImageSearch) == i) {
					viewItem = playerHaveItemData [i];
				}

			}
		}
	}


	//("slot"+n)

	void Start () {
		Link ();

	}

	void Update(){

	}

	public void OnPointerEnter(PointerEventData eventdata)
	{
		popUpText.text = producedItemImage.name;
//		popUpText.text = viewItem.Name;
	}

	public void OnPointerExit(PointerEventData eventdata)
	{
		popUpText.text = "";
	}

	public void OnPointerStay(PointerEventData eventdata){

	}
}
