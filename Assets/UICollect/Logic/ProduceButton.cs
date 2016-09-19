using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ProduceButton : ProduceViewSet  , IPointerDownHandler{
	[SerializeField]private GameObject produceButton;
	[SerializeField]private Image produceGauge;
	[SerializeField]bool isAbleProducing;


	public void LinkComponentElement()
	{
		produceButton = this.gameObject;
		produceGauge = GameObject.Find ("ProduceButton").GetComponent<Image> ();
		isAbleProducing = false;
	}

	public void RevitalizeProduce()
	{
		isAbleProducing = true;
	}

	public void UnRevitalizeProduce()
	{
		isAbleProducing = false;
	}

	public void OnPointerDown(PointerEventData eventdata){
		if (eventdata.pointerCurrentRaycast.gameObject == produceButton) {
			if (isAbleProducing) {
				//class ProduceViewSet 상속후 연결되는지 확인;
				SetProduceItem ();
			}
		}
	}
}
