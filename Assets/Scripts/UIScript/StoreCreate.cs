using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreCreate : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
	public UIManager mainUI;
	public GameObject bakery;
	public Image bakeryCheck;

	public GameObject bar;
	public Image barCheck;
	[SerializeField] GameObject selectStore;
	public GameObject fastFood;
	public GameObject cafe;
	// Use this for initialization
	void Start () 
	{
		mainUI = GameObject.FindGameObjectWithTag ("MainUI").GetComponent<UIManager> ();

		bakery = GameObject.Find ("BakeryCreate");
		bakeryCheck = transform.Find ("BakeryCreate").Find ("BakeryCheck").GetComponent<Image> ();

		bar = GameObject.Find ("BarCreate");
		barCheck = transform.Find ("BarCreate").Find ("BarCheck").GetComponent<Image> ();

		fastFood = GameObject.Find ("FastFoodCreate");
		cafe = GameObject.Find ("CafeCreate");

		CreateBakeryCheck (false);
		barCheck.enabled = false;
	}
		
	public void OnCreateStore()
	{
		mainUI.ChangeUIMode (UIManager.Mode.CreateStore);
	}

	public void CreateBakeryCheck(bool state)
	{
		bakeryCheck.enabled = state;	
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		//string name = eventData.pointerEnter.gameObject.

		if (name == "Bakery")
		{
			CreateBakeryCheck (true);
		}
	}
	public void OnPointerExit(PointerEventData eventData)
	{

	}

}
