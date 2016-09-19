using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class Sell : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler 
{	
	//private FirstStep firstStep;
	public ProducedItemList producedItemList;

	void Start(){
//		firstStep = GameObject.Find ("FirstStep").GetComponent<FirstStep> ();
		producedItemList = GameObject.Find ("ProducedItemList").GetComponent<ProducedItemList> ();
	}

	public void OnPointerDown(PointerEventData eventDate){
		if (producedItemList.selectObject != null) {
			
		}


	}

	public void OnPointerEnter(PointerEventData eventDate){
		//image change;
	}

	public void OnPointerExit(PointerEventData eventDate){
		//image change;
	}
}

