using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ProducedItemList : MonoBehaviour ,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler {

	//[SerializeField] private Player playerinfo;

	public Text[] producedItemName;
	public Image[] producedItemImage;

	public GameObject[] producedItemNameObject;
	public GameObject[] producedItemImageObject;
	[SerializeField] private Player playerdata;

	public GameObject selectObject;

	void Link()
	{
		producedItemName = new Text[5];
		producedItemImage = new Image[5];
		producedItemNameObject = new GameObject [5];
		producedItemImageObject = new GameObject[5];

		for (int count = 0; count < producedItemName.Length; count++) {
			string producedItemNameSearch = "ProducedItemName" + ( count + 1 ).ToString();
			producedItemName [count] = GameObject.Find (producedItemNameSearch).GetComponent<Text> ();
			producedItemNameObject [count] = GameObject.Find (producedItemNameSearch);

			string producedItemImageSearch = "ProducedItemImage" + (count + 1).ToString ();
			producedItemImage [count] = GameObject.Find (producedItemImageSearch).GetComponent<Image> ();
			producedItemImageObject [count] = GameObject.Find (producedItemImageSearch);

		}

		playerdata = GameObject.Find ("GameManager").GetComponent<GameManager> ().PlayerData;

	}

	public void HaveItemUpdate(Player playerdate){
		for(int i = 0; i < playerdate.HaveItem.Length; i++)
		{
			if (playerdate.HaveItem [i].Name == null) {
				break;
			}
			producedItemImage [i].sprite = Resources.Load<Sprite> ("ItemIcon/" + playerdate.HaveItem [i].Name);
		}
		Debug.Log (playerdate.HaveItem [0].Name);
	}







	// Use this for initialization
	void Start () {
		Link ();
		HaveItemUpdate(playerdata);
	}
	
	// Update is called once per frame





	public void OnPointerDown(PointerEventData eventdata){
		for (int count = 0; count < producedItemName.Length; count++) {
			string producedItemNameSearch = "ProducedItemImage" + (count).ToString (); 
			if (eventdata.pointerCurrentRaycast.gameObject.name == producedItemNameSearch) {
				selectObject = eventdata.pointerCurrentRaycast.gameObject;

			}
		}
	}
	public void OnPointerEnter(PointerEventData eventdata){
		for (int count = 0; count < producedItemName.Length; count++) {
			string producedItemImageSearch = "ProducedItemImage" + (count).ToString (); 
			if (eventdata.pointerCurrentRaycast.gameObject.name == producedItemImageSearch) {
			//	popUpText.text = producedItemNameSearch.ToString ();
				//popUpText.text = producedItemImageSearch;
				Debug.Log (producedItemImageSearch);
			}


			}
		}

	public void OnPointerExit(PointerEventData eventdate){
		Debug.Log ("aa");
	}

}
