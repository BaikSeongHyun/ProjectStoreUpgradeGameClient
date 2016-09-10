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
	int changename = 0;

	public GameObject[] selectStoreLine = new GameObject[3];
	public Image[] selectStoreChange = new Image[3];

	// Use this for initialization
	void Start ()
	{
		mainUI = GameObject.FindGameObjectWithTag ("MainUI").GetComponent<UIManager> ();
		selectUI = this.gameObject;
		selectStoreLine [0] =GameObject.Find ("FirstStore");
		selectStoreChange[0] = transform.Find("FirstStore").GetComponent<Image> ();

		selectStoreLine [1] =GameObject.Find ("SecondStore");
		selectStoreChange[1] = transform.Find("SecondStore").GetComponent<Image> ();

		selectStoreLine [2] =GameObject.Find ("ThirdStore");
		selectStoreChange[2] = transform.Find("ThirdStore").GetComponent<Image> ();



	}

	public void OnPointerDown (PointerEventData eventData)
	{
		string name = eventData.pointerEnter.gameObject.name;
		selectStore = eventData.pointerEnter.gameObject; 

	}

	public void CreateStore(string name)
	{
		if(changename >=3)
		{
			Debug.Log ("slot full");
			changename = 3;
		}
		else
		{
			Debug.Log (changename);

			switch(name)
			{
			case "Bakery":
				selectStoreChange [changename].sprite = Resources.Load<Sprite> ("UIImage\\빵집버튼");
				break;
			
			case "Bar":
				selectStoreChange [changename].sprite = Resources.Load<Sprite> ("UIImage\\바버튼");
				break;

			case "FastFood":
				selectStoreChange [changename].sprite = Resources.Load<Sprite> ("UIImage\\패스트푸드점버튼");
				break;

			case "Cafe":
				selectStoreChange [changename].sprite = Resources.Load<Sprite> ("UIImage\\카페버튼");
				break;
		
			}
			changename++;
		}
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
		//CreateStore parameterstoreinfo input
		StartGame ();
	}

}
