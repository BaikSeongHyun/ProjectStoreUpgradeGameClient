using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ActLogic : MonoBehaviour,IPointerDownHandler 
{	
	public GameObject StateGauge;
	public GameObject Check;
	public GameObject SellAction;
	public GameObject MakeAction;

	private UIM uIM;

	void Link()
	{
		StateGauge = GameObject.Find ("StateGauge");
		Check = GameObject.Find ("Check");
		SellAction = GameObject.Find ("SellAction");
		MakeAction = GameObject.Find ("MakeAction");
		uIM = GameObject.Find ("MainUI").GetComponent<UIM> ();
	}

	void StartSetting()
	{
		StateGauge.SetActive (false);
		Check.SetActive (false);
		SellAction.SetActive (false);
		MakeAction.SetActive (false);
	}




	void ModeSelect(){
		if (uIM.presentMode == UIM.Mode.SellMode) {
			SellAction.SetActive (true);
			MakeAction.SetActive (false);
		}
		if (uIM.presentMode == UIM.Mode.BuyMode) {
			SellAction.SetActive (false);
			MakeAction.SetActive (true);
		}
	}



	void Start(){
		Link ();
		StartSetting ();

		//Mode = M
		 
	}


	// Update is called once per frame
	void Update () {
		
		ModeSelect ();

	}




	public void OnPointerDown(PointerEventData eventDate){
		
	}

}
