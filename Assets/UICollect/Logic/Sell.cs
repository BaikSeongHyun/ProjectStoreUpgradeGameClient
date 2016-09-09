using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class Sell : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler 
{	
	private FirstStep firstStep;

	void Start(){
		firstStep = GameObject.Find ("FirstStep").GetComponent<FirstStep> ();
	}

	public void OnPointerDown(PointerEventData eventDate){
//		if(firstStep.presentMode == FirstStep.Mode.IdleMode)firstStep.SendMessage ("SellMode");
	}

	public void OnPointerEnter(PointerEventData eventDate){
		//image change;
	}

	public void OnPointerExit(PointerEventData eventDate){
		//image change;
	}
}

