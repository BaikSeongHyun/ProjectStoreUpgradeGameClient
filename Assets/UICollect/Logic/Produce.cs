using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class Produce : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler 
	{	
	private GameObject stateGauge;
	private GameObject ProduceButton;
	private FirstStep firstStep;

		void Start(){
		firstStep = GameObject.Find ("FirstStep").GetComponent<FirstStep> ();
		ProduceButton = GameObject.Find ("ProduceButton");
		stateGauge = GameObject.Find ("StateGauge");
	}

		public void OnPointerDown(PointerEventData eventDate){
		{
			
			if (eventDate.pointerCurrentRaycast.gameObject == ProduceButton) {
//				if (firstStep.presentMode == FirstStep.Mode.IdleMode)
//					firstStep.SendMessage ("produceMode");
			
			}
		}
	}

		public void OnPointerEnter(PointerEventData eventDate){
		//image change;
		}

		public void OnPointerExit(PointerEventData eventDate){
		//image change;
		}
	}

