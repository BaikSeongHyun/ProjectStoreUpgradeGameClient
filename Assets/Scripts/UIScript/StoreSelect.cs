using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using System.Collections;
using System;


public class StoreSelect : MonoBehaviour, IPointerDownHandler
{
	[SerializeField] GameObject[] selectImage;
	[SerializeField] GameObject selectStore;
	[SerializeField] GameObject selectUI;

	public UIManager mainUI;

	// Use this for initialization
	void Start ()
	{
		selectImage = new GameObject[3];

		selectImage [0] = transform.Find ("FirstStore").gameObject;
		selectImage [1] = transform.Find ("SecondStore").gameObject;
		selectImage [2] = transform.Find ("ThirdStore").gameObject;

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

	void OnMouseDown()
	{
		StartGame ();
	}
		
}
