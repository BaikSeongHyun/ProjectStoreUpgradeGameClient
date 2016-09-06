using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	
	Vector3 cameraDistance;
	[SerializeField] ElfCharacter elf;

	[SerializeField] bool matHit;
	// Use this for initialization
	void Start ()
	{
		Application.targetFrameRate = 80;
		cameraDistance = new Vector3 (0f, 7.5f, -8f);
		matHit = false;
	
	}
	// Update is called once per frame
	void Update ()
	{
		
		if (!EventSystem.current.IsPointerOverGameObject ())
		{
			if (Input.GetButtonDown("Move"))
			{
				Ray point = Camera.main.ScreenPointToRay (Input.mousePosition);

				RaycastHit hitPoint;

				if (Physics.Raycast (point, out hitPoint, Mathf.Infinity))//terrain 이외 다른 걸 무시, 없으면 얘 무시
				{				
					if (hitPoint.transform.tag == "Terrain")
					{	
						elf.Destination = hitPoint.point;
						elf.isStopMat = false;
						matHit = false;
						elf.MakeTime (false);
					}
					else if (hitPoint.transform.tag == "Mat" && !matHit)
					{
						Debug.Log ("matin");
						matHit = true;
						hitPoint.point = new Vector3 (0.3f, 0.0f, -2.4f);
						elf.Destination = hitPoint.point;
						elf.transform.rotation = new Quaternion (transform.rotation.x, 180, transform.rotation.z, 0);											
						elf.isStopMat = true;
					}
					else if (hitPoint.transform.tag == "Mat" && elf.makeTime && matHit)
					{
						elf.Destination = hitPoint.point;
					}
				}
			}
		}		
	}
}
