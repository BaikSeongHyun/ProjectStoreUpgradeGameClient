using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class Produce : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler 
	{	
	private Image stateGauge;
	private GameObject ProduceButton;
	private FirstStep firstStep;
	public float filltime;

		void Start(){
		firstStep = GameObject.Find ("FirstStep").GetComponent<FirstStep> ();
		ProduceButton = GameObject.Find ("ProduceButton");
		stateGauge = GameObject.Find ("StateGauge").GetComponent<Image>();
		filltime = 1;
	}

		public void OnPointerDown(PointerEventData eventDate){
		{
			
			if (eventDate.pointerCurrentRaycast.gameObject == ProduceButton) {
				if(filltime >=1){GaugeReSet ();}
			}
		}
	}

		void Update()
		{
			stateGauge.fillAmount = filltime;
			
		ProduceProcess ();
			
			

		}	

		public void OnPointerEnter(PointerEventData eventDate){
		//image change;
		}

		public void OnPointerExit(PointerEventData eventDate){
		//image change;
		}

	void GaugeReSet(){
		filltime = 0;
	}

	void GaugeChange(){
	
	}

	void ProduceProcess(){
		if(filltime <= 1)
		{
			filltime += Time.deltaTime;
		}
	}



	}

