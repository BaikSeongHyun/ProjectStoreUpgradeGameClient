using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreCreate : MonoBehaviour
{
	public UIManager mainUI;

	public GameObject bakery;
	public Image bakeryCheck;
	public Image bakeryImage;
	public Image bakeryAccount;


	public GameObject bar;
	public Image barCheck;
	public Image barImage;
	public Image barAccount;


	public GameObject fastFood;
	public Image fastFoodCheck;
	public Image fastFoodImage;
	public Image fastFoodAccount;

	public GameObject cafe;
	public Image cafeCheck;
	public Image cafeImage;
	public Image cafeAccount;

	public GameObject createStoreButton;

	// Use this for initialization
	void Start () 
	{
		mainUI = GameObject.FindGameObjectWithTag ("MainUI").GetComponent<UIManager> ();

		bakery = GameObject.Find ("BakeryCreate");
		bakeryCheck = transform.Find ("BakeryCreate").Find ("BakeryCheck").GetComponent<Image> ();
		bakeryImage = transform.Find ("BakeryCreate").Find ("BakeryImage").GetComponent<Image> ();
		barAccount = transform.Find ("BakeryCreate").Find ("BakeryAccount").GetComponent<Image> ();

		bar = GameObject.Find ("BarCreate");
		barCheck = transform.Find ("BarCreate").Find ("BarCheck").GetComponent<Image> ();
		barImage = transform.Find ("BarCreate").Find ("BarImage").GetComponent<Image> ();
		barAccount = transform.Find ("BarCreate").Find ("BarAccount").GetComponent<Image> ();

		fastFood = GameObject.Find ("FastFoodCreate");
		fastFoodCheck = transform.Find ("FastFoodCreate").Find ("FastFoodCheck").GetComponent<Image> ();
		fastFoodImage = transform.Find ("FastFoodCreate").Find ("FastFoodImage").GetComponent<Image> ();
		fastFoodAccount = transform.Find ("FastFoodCreate").Find ("FastFoodAccount").GetComponent<Image> ();

		cafe = GameObject.Find ("CafeCreate");
		cafeCheck = transform.Find ("CafeCreate").Find ("CafeCheck").GetComponent<Image> ();
		cafeImage = transform.Find ("CafeCreate").Find ("CafeImage").GetComponent<Image> ();
		cafeAccount = transform.Find ("CafeCreate").Find ("CafeAccount").GetComponent<Image> ();

		createStoreButton = GameObject.Find ("CreateStore");

//		CreateBakeryCheck (false);
//		barCheck.enabled = false;

		AllBlinkStore ();
	}
		
	public void OnCreateStore()
	{
		mainUI.ChangeUIMode (UIManager.Mode.CreateStore);
	}

	public void AllBlinkStore()
	{
		bakeryCheck.enabled = false;
		bakeryImage.enabled = false;
		bakeryAccount.enabled = false;

		barCheck.enabled = false;
		barImage.enabled = false;
		barAccount.enabled = false;

		fastFoodCheck.enabled = false;
		fastFoodImage.enabled = false;
		fastFoodAccount.enabled = false;

		cafeCheck.enabled = false;
		cafeImage.enabled = false;
		cafeAccount.enabled = false;	
	}

	public void CreateBakeryCheck(bool state)
	{
		bakeryCheck.enabled = state;	
		bakeryImage.enabled = state;
		bakeryAccount.enabled = state;
	}

	public void CreateBarCheck(bool state)
	{
		barCheck.enabled = state;
		barImage.enabled = state;
		barAccount.enabled = state;
	}

	public void CreateFastFoodCheck(bool state)
	{
		fastFoodCheck.enabled = state;
		fastFoodImage.enabled = state;
		fastFoodAccount.enabled = state;
	}

	public void CreateCafeCheck(bool state)
	{
		cafeCheck.enabled = state;
		cafeImage.enabled = state;
		cafeAccount.enabled = state;
	}

	public void StoreSelectButtonEvent(string name)
	{
		AllBlinkStore ();

		switch (name)
		{
		case "Bakery":
			CreateBakeryCheck (true);

			break; 
		
		case "Bar":
			CreateBarCheck (true);
			break;

		case "FastFood":
			CreateFastFoodCheck (true);
			break;

		case "Cafe":
			CreateCafeCheck (true);
			break;
			

		}
	}
		
	public void BackSelectStore()
	{
		mainUI.ChangeUIMode (UIManager.Mode.SelectStore);
	}

	public void SelectStoreCreateEvent(string name)
	{
		if (name == "Bakery")
		{
			Debug.Log ("i`m bakery");

		}
		else if (name == "Bar")
		{
			Debug.Log ("i`m bar");
		}
				
	}

}
