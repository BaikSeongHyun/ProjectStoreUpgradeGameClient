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

	private Text[] produceAbleItemName;
	private Image[] produceAbleItemImage;

	private GameObject[] produceAbleItemNameObject;
	private GameObject[] produceAbleItemImageObject;

	private ItemView itemView;
	private NeedItemList needItemList; 

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
		produceAbleItemImage = new Image[5];

		produceAbleItemNameObject = new GameObject[5];
		produceAbleItemImageObject = new GameObject[5];


		for(int count = 0; count < produceAbleItemName.Length; count++)
		{
			string produceAbleItemNameSearch = "ProduceAbleItemName" + (count + 1).ToString ();
			produceAbleItemName [count] = GameObject.Find (produceAbleItemNameSearch).GetComponent<Text>();
			produceAbleItemNameObject[count] = GameObject.Find(produceAbleItemNameSearch);

			string produceAbleItemImageSearch = "ProduceAbleItemImage" + (count + 1).ToString ();
			produceAbleItemImage [count] = GameObject.Find (produceAbleItemImageSearch).GetComponent<Image>();
			produceAbleItemImageObject[count] = GameObject.Find(produceAbleItemImageSearch);
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

		//send to variable for gameobject
		itemView = GameObject.Find("ItemView").GetComponent<ItemView> ();
		needItemList = GameObject.Find ("NeedItemList").GetComponent<NeedItemList> ();
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


	public void OnPointerDown(PointerEventData eventdata){
		



		for(int count= 0; count < produceAbleItemName.Length; count++){
			string produceAbleItemNameSearch = "ProduceAbleItemName" + (count).ToString(); 

		if (eventdata.pointerCurrentRaycast.gameObject.name == name) {
				//select iteminfo send to Itemview,  needitem;
				itemView.TestCollMe(name,count);

				
				needItemList.TestCollMe (name);

					}
				}
			}


//			if (eventdate.pointerCurrentRaycast.gameObject == produceAbleItemNameObject []) {
				
//			}

//		if (eventdate.pointerCurrentRaycast.gameObject == produceAbleItemNameObject) {
			
//		}

				




}
