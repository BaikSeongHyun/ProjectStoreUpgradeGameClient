using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ProducedItemList : MonoBehaviour ,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler {

	public Text[] producedItemName;
	public Image[] producedItemImage;

	public GameObject[] producedItemNameObject;
	public GameObject[] producedItemImageObject;

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



	}

	//void Item

	// Use this for initialization
	void Start () {
		Link ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerDown(PointerEventData eventdata){
		for (int count = 0; count < producedItemName.Length; count++) {
			string producedItemNameSearch = "ProducedItemName" + (count).ToString (); 
			if (eventdata.pointerCurrentRaycast.gameObject.name == producedItemNameSearch) {
				selectObject = eventdata.pointerCurrentRaycast.gameObject;

			}
					
			

		}
	}
	public void OnPointerEnter(PointerEventData eventdate){
	}

	public void OnPointerExit(PointerEventData eventdate){
	}

}
