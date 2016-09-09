using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;
using System;


public class StoreSelect : MonoBehaviour, IPointerDownHandler
{
	

	[SerializeField] GameObject selectStore;
	[SerializeField] GameObject selectUI;
	public UIManager mainUI;

	// Use this for initialization
	void Start ()
	{

		mainUI = GameObject.FindGameObjectWithTag ("MainUI").GetComponent<UIManager> ();
		selectUI = this.gameObject;
	
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		string name = eventData.pointerEnter.gameObject.name;
		selectStore = eventData.pointerEnter.gameObject; 

	}

	public void StartGame()
	{
		selectUI.SetActive (false);		
	}

	public void StartCreateStore()
	{
		selectUI.SetActive (false);	

	}

	void OnMouseDown()
	{
		StartGame ();
	}		
}
