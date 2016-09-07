using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ProduceAbleItemList : MonoBehaviour {
//	public GameObject MakingItemText1;
//	public GameObject ItemView;

//	[SerializeField]Item itemName;
//	[SerializeField]Image itemImage;

	public Text[] produceAbleItemName;
	public Image[] produceAbleItemImage;
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
		for(int i = 0; i < produceAbleItemName.Length; i++)
		{
			string name = "MakingItemName" + (i + 1).ToString ();
			produceAbleItemName [i] = GameObject.Find (name).GetComponent<Text>();
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
