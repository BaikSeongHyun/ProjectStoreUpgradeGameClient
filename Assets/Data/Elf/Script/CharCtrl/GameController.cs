using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	
	Vector3 cameraDistance;
	[SerializeField] ElfCharacter elf;

	// Use this for initialization
	void Start ()
	{
		Application.targetFrameRate = 80;
		cameraDistance = new Vector3 (0f, 7.5f, -8f);
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

				if (Physics.Raycast (point, out hitPoint, Mathf.Infinity, 1 << LayerMask.NameToLayer ("Terrain")))
				{
					elf.Destination = hitPoint.point;
				}
			}
		}		
	}
}
