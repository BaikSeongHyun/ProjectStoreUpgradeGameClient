using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class NeedItemList : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler  {
	private Text[] needItemCount;
	private Image[] needItemImage;

	private GameObject[] needItemCountObject;

	void Link(){
		needItemCount = new Text[5];
		needItemImage = new Image[5];

		needItemCountObject = new GameObject[5];

		for (int count = 0; count < needItemCount.Length; count++) {
			string name = "NeedItemCount"+ (count+1).ToString();
			needItemCount [count] = GameObject.Find (name).GetComponent<Text> ();
			//needItemImage [count] = GameObject.Find ()
			needItemCountObject [count] = GameObject.Find (name);
		}



	}

	// Use this for initialization
	void Start () {
		Link ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerDown(PointerEventData eventDate){

		//
	}




	public void OnPointerEnter(PointerEventData eventDate){
		//image change;
	}

	public void OnPointerExit(PointerEventData eventDate){
		//image change;
	}



//	public void TestCollMe(string count, Image image){
	public void TestCollMe(string name){
		Debug.Log ("aa");
	}
}
