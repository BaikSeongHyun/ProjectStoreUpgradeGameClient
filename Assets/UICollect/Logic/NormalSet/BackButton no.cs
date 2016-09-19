using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class BackButton : MonoBehaviour,IPointerDownHandler {

	private GameObject backButton;


	// Use this for initialization
	void Start () {
		backButton = GameObject.Find ("BackButton");
	}


	public void OnPointerDown(PointerEventData eventDate)
	{
		//popup ?? login back??
	}
}
