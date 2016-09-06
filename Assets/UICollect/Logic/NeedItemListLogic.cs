using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class NeedItemListLogic : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler  {
	public GameObject NeedItemList;
	public GameObject Item1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerDown(PointerEventData eventDate){
		
	}

	public void OnPointerEnter(PointerEventData eventDate){
		//image change;
	}

	public void OnPointerExit(PointerEventData eventDate){
		//image change;
	}
}
