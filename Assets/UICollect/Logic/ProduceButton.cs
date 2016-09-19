using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ProduceButton : MonoBehaviour  , IPointerDownHandler{
	[SerializeField]private GameObject produceButton;
	[SerializeField]private Image produceGauge;
	[SerializeField]bool isAbleProducing;
	[SerializeField]Item selectItem;

	public bool GetSetIsAbleProducing{
		get{	return isAbleProducing;}
		set{ isAbleProducing = value;}
	}

	public void LinkComponentElement()
	{
		produceButton = this.gameObject;
		produceGauge = GameObject.Find ("ProduceGauge").GetComponent<Image> ();
		selectItem = GameObject.Find("Produce").GetComponent<ProduceViewSet>().GetProduceSelectItem ();

		// 임시로 설정
		isAbleProducing = true;
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
					//class ProduceViewSet 상속후 선택한 아이템 불러와 연결되는지 확인;//clear
					Debug.Log (selectItem.ID);




				}
			}

	}
		
}
