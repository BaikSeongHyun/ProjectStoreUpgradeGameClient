using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ExitGameButton : MonoBehaviour,IPointerClickHandler
{
	private GameObject exitGameButton;
	// Use this for initialization
	void Start () {
		exitGameButton = GameObject.Find ("ExitGameButton");
	}


	public void OnPointerClick (PointerEventData eventDate)
	{
		//popup and exit comfirmation popup;
	}
}
