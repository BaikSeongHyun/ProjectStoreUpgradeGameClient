using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ProduceAbleItemList : MonoBehaviour, IPointerDownHandler {
//	public GameObject MakingItemText1;
//	public GameObject ItemView;

//	[SerializeField]Item itemName;
//	[SerializeField]Image itemImage;

	public Text[] produceAbleItemName;
	public Image[] produceAbleItemImage;

	public GameObject[] produceAbleItemNameObject;

//	public GameObject MakingItemName1;
//	public GameObject MakingItemName2;
//	public GameObject MakingItemName3;
//	public GameObject MakingItemName4;
//	public GameObject MakingItemName5;
//	public GameObject ItemImage1;
//	public GameObject ItemImage2;
//	public GameObject ItemImage3;
//	public GameObject ItemImage4;
//	public GameObject ItemImage5;

	void Link()
	{
		produceAbleItemName = new Text[5];


		produceAbleItemNameObject = new GameObject[5];



		for(int i = 0; i < produceAbleItemName.Length; i++)
		{
			string name = "ProduceAbleItemName" + (i + 1).ToString ();
			produceAbleItemName [i] = GameObject.Find (name).GetComponent<Text>();
			////produceAbleItemNameObject [i] = GameObject.Find (name).GetComponent<GameObject> ();
			produceAbleItemNameObject[i] = GameObject.Find(name);
		
		}
		//MakingItemName1 = GameObject.Find ("MakingItemName1");
//		MakingItemName2 = GameObject.Find ("MakingItemName2");
//		MakingItemName3 = GameObject.Find ("MakingItemName3");
//		MakingItemName4 = GameObject.Find ("MakingItemName4");
//		MakingItemName5 = GameObject.Find ("MakingItemName5");
//		ItemImage1 = GameObject.Find ("ItemImage1");
//		ItemImage2 = GameObject.Find ("ItemImage2");
//		ItemImage3 = GameObject.Find ("ItemImage3");
//		ItemImage4 = GameObject.Find ("ItemImage4");
//		ItemImage5 = GameObject.Find ("ItemImage5");

	

	}

	void ShowView()
	{
//MakingItemName1.text = Database.Instance.FindItemUseID (0001).Name;
	}



	// Use this for initialization
	void Start () {
		//MakingItemName1.text = Database.Instance.FindItemUseID (0001);
		//itemName = GetComponent<Text> ();
		Link ();
	}


	public void OnPointerDown(PointerEventData eventdate){
		
//			if (eventdate.pointerCurrentRaycast.gameObject == produceAbleItemNameObject []) {
				Debug.Log ("aa");
//			}

//		if (eventdate.pointerCurrentRaycast.gameObject == produceAbleItemNameObject) {
			
//		}

				
	}



}
