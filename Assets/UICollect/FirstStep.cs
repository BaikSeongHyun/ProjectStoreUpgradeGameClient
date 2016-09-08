using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class FirstStep : MonoBehaviour {

	public Mode presentMode;
	public Mode PresentMode{
		get { return presentMode;}
	}


	public GameObject stepView;
	public StepView stepViewLogic;
	//public stepView stepViewLogic;

	public GameObject gold;
	public Gold goldLogic;

	public GameObject backButton;
	public BackButton backButtonLogic;

	public GameObject exitGameButton;
	public ExitGameButton exitGameButtonLogic;

	public GameObject produceAbleItemList;
	public ProduceAbleItemList produceAbleItemListLogic;

	public GameObject itemView;
	public ItemView itemviewLogic;

	public GameObject sell;
	public Sell sellLogic;

	public GameObject produce;
	public Produce produceLogic;

	[SerializeField] Item test;


	public void UpdateGold(){}

	public enum Mode
	{
		IdleMode,
		produceMode,
		SellMode,

	}

	public void IdleMode(){
		presentMode = Mode.SellMode;
		stepView.SetActive (true);
		gold.SetActive (true);
		backButton.SetActive (true);
		exitGameButton.SetActive (true);
		itemView.SetActive (true);
		sell.SetActive (true);
		produce.SetActive (true);
		//acttion is setactive if making item or selling item;
	


	}



	public void SwichMode(Mode uiMode){
		switch (uiMode) {
		case Mode.produceMode:
			produceMode ();

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
		stepView= GameObject.Find("StepView");
		gold = GameObject.Find("Gold");
		backButton= GameObject.Find("BackButton");
		exitGameButton= GameObject.Find("ExitGameButton");
		produceAbleItemList= GameObject.Find("ProduceAbleItemList");
		itemView = GameObject.Find ("ItemView");
		sell= GameObject.Find("SellButton");
		produce= GameObject.Find("Produce");

	}

	//test
	public void nonIdleMode(){

		stepView.SetActive (false);
		gold.SetActive (false);
		backButton.SetActive (false);
		exitGameButton.SetActive (false);
		produceAbleItemList.SetActive (false);
		itemView.SetActive (false);
		sell.SetActive (false);
		produce.SetActive (false);

	}

	public void SellMode()
	{
		presentMode = Mode.SellMode;

		backButton.SetActive (false);
		exitGameButton.SetActive (false);
		produceAbleItemList.SetActive (false);
		itemView.SetActive (false);
		sell.SetActive (false);
		produce.SetActive (false);

	}

	public void produceMode()
	{
		presentMode = Mode.produceMode;

		backButton.SetActive (false);
		exitGameButton.SetActive (false);
		produceAbleItemList.SetActive (false);
		itemView.SetActive (false);
		sell.SetActive (false);
		produce.SetActive (false);

	}


	// Use this for initialization
	void Start () {
		Link ();
		SwichMode (Mode.IdleMode);

		test = Database.Instance.FindItemUseID (0001);
		itemviewLogic.UpdateMakingIteamInfo (test);

	}

	// Update is called once per frame
	void Update () {
	}
}
