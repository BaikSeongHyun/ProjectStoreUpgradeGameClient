using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class UIM : MonoBehaviour {

	public Mode presentMode;
	public Mode PresentMode{
		get { return presentMode;}
	}
	public GameObject StepView;
	//public stepView stepViewLogic;

	public GameObject Gold;

	public GameObject BackButton;

	public GameObject ExitGameButton;

	public GameObject MakingItemList;

	public GameObject ItemView;

	public GameObject Sell;

	public GameObject Make;

	public GameObject Acttion;

	public GameObject NeedItemList;



	public void UpdateGold(){}

	public enum Mode
	{
		IdleMode,
		BuyMode,
		SellMode,

	}

	public void IdleMode(){
	
		StepView.SetActive (true);
		Gold.SetActive (true);
		BackButton.SetActive (true);
		ExitGameButton.SetActive (true);
		ItemView.SetActive (true);
		Sell.SetActive (true);
		Make.SetActive (true);
		Acttion.SetActive (true);
		NeedItemList.SetActive (true);


	}

	public void SwichMode(Mode uiMode){
		switch (uiMode) {
		case Mode.BuyMode: 
			break;
		case Mode.IdleMode: 
			break;
		case Mode.SellMode:
			break;


		}
	}

	public void Link()
	{
		StepView= GameObject.Find("StepView");
		Gold = GameObject.Find("Gold");
		BackButton= GameObject.Find("BackButton");
		ExitGameButton= GameObject.Find("ExitGameButton");
		MakingItemList= GameObject.Find("MakingItemList");
		ItemView = GameObject.Find ("ItemView");
		Sell= GameObject.Find("Sell");
		Make= GameObject.Find("Make");
		Acttion= GameObject.Find("Acttion");
		NeedItemList= GameObject.Find("NeedItemList");
	}

	public void nonIdleMode(){

		StepView.SetActive (false);
		Gold.SetActive (false);
		BackButton.SetActive (false);
		ExitGameButton.SetActive (false);
		MakingItemList.SetActive (false);
		ItemView.SetActive (false);
		Sell.SetActive (false);
		Make.SetActive (false);
		Acttion.SetActive (false);
		NeedItemList.SetActive (false);


	}





	// Use this for initialization
	void Start () {
		Link ();
		IdleMode ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			nonIdleMode ();
		}
	}
}
