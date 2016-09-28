using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

	Vector3 cameraDistance;
	[SerializeField] ElfCharacter elf;
	[SerializeField] public int Lv;
	[SerializeField] bool matHit;
	[SerializeField] RaycastHit hitPoint;
	[SerializeField] Ray point;
	[SerializeField] GameObject mat;
	bool Test = true;
	[SerializeField] List <GameObject> makeItem = new List<GameObject>();
//	[SerializeField] ItemViewLogic[] soldItem;
	[SerializeField] UIManager CreateOrSelect;
	[SerializeField] SecondStepUI secondStepUI;
	[SerializeField] int layer;
	[SerializeField] HouseManager house;
	[SerializeField] GameObject[] ItemList;
	[SerializeField] GameObject[] itemCheck;

	// Use this for initializationpublic 
	void Start ()
	{
		Application.targetFrameRate = 80;
		cameraDistance = new Vector3 (0f, 7.5f, -8f);
		matHit = false;
		mat = GameObject.FindGameObjectWithTag ("Mat");
		secondStepUI = GameObject.Find ("SecondStepUI").GetComponent<SecondStepUI> ();
		secondStepUI.ChangeSecondUIMode (SecondStepUI.SecondStepMode.NormalStep);
//		house = GameObject.Find("House").GetComponent<HouseManager> ();
	}
	// Update is called once per frame
	void Update ()
	{
		
		itemCheck = GameObject.FindGameObjectsWithTag ("Item");

		if (!EventSystem.current.IsPointerOverGameObject ())
		{
			if (Input.GetButtonDown("Move"))
			{
				point = Camera.main.ScreenPointToRay (Input.mousePosition);
				layer = 1 << LayerMask.NameToLayer ("Terrain");
				layer |= 1 << LayerMask.NameToLayer ("Mat");

				if (Physics.Raycast (point, out hitPoint, Mathf.Infinity,layer ))//terrain 이외 다른 걸 무시, 없으면 얘 무시
				{            
					if (hitPoint.transform.tag == "Terrain")
					{   
						InTerrainRay ();
						secondStepUI.ChangeSecondUIMode (SecondStepUI.SecondStepMode.NormalStep);
					}
					else if (hitPoint.transform.tag == "Mat" && !matHit )
					{
						InsertMatRay ();
						secondStepUI.ChangeSecondUIMode (SecondStepUI.SecondStepMode.AuctionStep);

					}
					else if (hitPoint.transform.tag == "Mat" && elf.makeTime && matHit)
					{
						MakeItemRay ();
					}
				}
			}
		}
	}
	public void InTerrainRay()
	{
		elf.Destination = hitPoint.point;
		Debug.Log (elf.Destination);
		elf.isStopMat = false;
		matHit = false;
		elf.MakeTime(false);
	}
	public void InsertMatRay()
	{
		matHit = true;
		hitPoint.point = new Vector3 (0.3f, 0.0f, -2.4f);
		elf.Destination = hitPoint.point;
		elf.transform.rotation = new Quaternion (transform.rotation.x, 180, transform.rotation.z, 0);                                 
		elf.isStopMat = true;		
	}
	public void MakeItemRay()
	{
		Vector3 destination;
		destination = hitPoint.point;
		//summonposition chec
		//popup itemprice
		SummonItem ();
	}
	public void SummonItem()
	{

		ItemList = GameObject.FindGameObjectsWithTag ("Slot");
		Debug.Log (ItemList.Length);
			if (true)
			{
				var Item =(GameObject)Instantiate (makeItem [0], ItemList[0].transform.position, transform.rotation);		
				itemCheck [0] = Item;
			}
			else
			{
				var Item =(GameObject)Instantiate (makeItem [0], ItemList[1].transform.position, transform.rotation);		
				itemCheck [1] = Item;			
			}

			secondStepUI.ItemSettingExit ();

//		if()
//		{
//			Debug.Log ("err");
//			secondStepUI.ItemSettingExit ();
//		}
	}

}