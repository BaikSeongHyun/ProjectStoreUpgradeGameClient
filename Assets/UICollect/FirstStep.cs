using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class FirstStep : MonoBehaviour {

	public Mode presentMode;
	public Mode PresentMode{
		get { return presentMode;}
	}


	public GameObject StepView;
	public StepViewLogic stepView;
	//public stepView stepViewLogic;

	public GameObject Gold;
	public GoldLogic gold;

	public GameObject BackButton;
	public BackButtonLogic backButton;

	public GameObject ExitGameButton;
	public ExitGameButtonLogic exitGameButton;

	public GameObject MakingItemList;
	public MakingItemListLogic makingItemList;

	public GameObject ItemView;
	public ItemViewLogic itemview;

	public GameObject Sell;
	public SellLogic sell;

	public GameObject Make;
	public MakeLogic make;

	[SerializeField] Item test;


	public void UpdateGold(){}

	public enum Mode
	{
		IdleMode,
		MakeMode,
		SellMode,

	}

	public void IdleMode(){
		presentMode = Mode.SellMode;
		StepView.SetActive (true);
		Gold.SetActive (true);
		BackButton.SetActive (true);
		ExitGameButton.SetActive (true);
		ItemView.SetActive (true);
		Sell.SetActive (true);
		Make.SetActive (true);
		//acttion is setactive if making item or selling item;
	


	}



	public void SwichMode(Mode uiMode){
		switch (uiMode) {
		case Mode.MakeMode:
			MakeMode ();

			break;
		case Mode.IdleMode: 
			IdleMode ();
			break;
		case Mode.SellMode:
			SellMode ();
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
		Sell= GameObject.Find("SellButton");
		Make= GameObject.Find("MakeButton");

	}

	//test
	public void nonIdleMode(){

		StepView.SetActive (false);
		Gold.SetActive (false);
		BackButton.SetActive (false);
		ExitGameButton.SetActive (false);
		MakingItemList.SetActive (false);
		ItemView.SetActive (false);
		Sell.SetActive (false);
		Make.SetActive (false);

	}

	public void SellMode()
	{
		presentMode = Mode.SellMode;

		BackButton.SetActive (false);
		ExitGameButton.SetActive (false);
		MakingItemList.SetActive (false);
		ItemView.SetActive (false);
		Sell.SetActive (false);
		Make.SetActive (false);

	}

	public void MakeMode()
	{
		presentMode = Mode.MakeMode;

		BackButton.SetActive (false);
		ExitGameButton.SetActive (false);
		MakingItemList.SetActive (false);
		ItemView.SetActive (false);
		Sell.SetActive (false);
		Make.SetActive (false);

	}


	// Use this for initialization
	void Start () {
		Link ();
		SwichMode (Mode.IdleMode);

		test = Database.Instance.FindItemUseID (0001);
		itemview.UpdateMakingIteamInfo (test);

	}

	// Update is called once per frame
	void Update () {
	}
}
