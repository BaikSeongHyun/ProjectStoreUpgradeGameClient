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

	public GameObject Act;
	public ActLogic act;

	public GameObject NeedItemList;
	public NeedItemListLogic needItemList;



	public void UpdateGold(){}

	public enum Mode
	{
		IdleMode,
		MakeMode,
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
		//acttion is setactive if making item or selling item;
		Act.SetActive (false);
		NeedItemList.SetActive (true);


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
		Act= GameObject.Find("Act");
		NeedItemList= GameObject.Find("NeedItemList");
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
		Act.SetActive (false);
		NeedItemList.SetActive (false);
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
		Act.SetActive (true);
		NeedItemList.SetActive (false);
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
		Act.SetActive (true);
		NeedItemList.SetActive (false);
	}





	// Use this for initialization
	void Start () {
		Link ();
		IdleMode ();
		SwichMode (Mode.IdleMode);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
