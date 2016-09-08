using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ActLogic : MonoBehaviour,IPointerDownHandler 
{	
	public GameObject StateGauge;
	public GameObject Check;
	public GameObject SellAction;
	public GameObject MakeAction;

	private FirstStep firstStep;

	void Link()
	{
		StateGauge = GameObject.Find ("StateGauge");
		Check = GameObject.Find ("Check");
		SellAction = GameObject.Find ("SellAction");
		MakeAction = GameObject.Find ("MakeAction");
		firstStep = GameObject.Find ("MainUI").GetComponent<FirstStep> ();
	}

	void StartSetting()
	{
		StateGauge.SetActive (false);
		Check.SetActive (false);
		SellAction.SetActive (false);
		MakeAction.SetActive (false);
	}




	void ModeSelect(){
		if (firstStep.presentMode == FirstStep.Mode.SellMode) {
			SellAction.SetActive (true);
			MakeAction.SetActive (false);
		}
		if (firstStep.presentMode == FirstStep.Mode.produceMode) {
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
