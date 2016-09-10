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
	[SerializeField] ItemView[] soldItem;
	[SerializeField] UIManager mainUI;

	// Use this for initializationpublic 

	void Start ()
	{
		Application.targetFrameRate = 80;
		cameraDistance = new Vector3 (0f, 7.5f, -8f);
		matHit = false;
		mat = GameObject.FindGameObjectWithTag ("Mat");
		mainUI = GameObject.FindGameObjectWithTag ("MainUI").GetComponent<UIManager> ();
		mainUI.LinkElement ();
	
		mainUI.ChangeUIMode (UIManager.Mode.SelectStore);
	}
	// Update is called once per frame
	void Update ()
	{

		if (!EventSystem.current.IsPointerOverGameObject ())
		{
			if (Input.GetButtonDown("Move"))
			{
				point = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (Physics.Raycast (point, out hitPoint, Mathf.Infinity))//terrain 이외 다른 걸 무시, 없으면 얘 무시
				{            
					if (hitPoint.transform.tag == "Terrain")
					{   
						InTerrainRay ();
					}
					else if (hitPoint.transform.tag == "Mat" && !matHit)
					{
						InsertMatRay ();
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
		Vector3 matSize;
		//summonposition chec
			
			if (Test)
			{
					matSize = new Vector3 (mat.transform.localPosition.x - 5, 
					mat.transform.localPosition.y,
					mat.transform.localPosition.z);

				Instantiate (makeItem [0], matSize, transform.rotation);
				Test = false;

			}
			else
			{
				matSize = new Vector3 (mat.transform.localPosition.x +5, 
					mat.transform.localPosition.y,
					mat.transform.localPosition.z);

				Instantiate (makeItem [0], matSize, transform.rotation);
			}
	}
}