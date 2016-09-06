using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class MakeLogic : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler 
	{	
	private UIM MainUI;

		void Start(){
		MainUI = GameObject.Find ("MainUI").GetComponent<UIM> ();
		}

		public void OnPointerDown(PointerEventData eventDate){
			if(MainUI.presentMode == UIM.Mode.IdleMode)MainUI.SendMessage ("MakeMode");
		}

		public void OnPointerEnter(PointerEventData eventDate){
		//image change;
		}

		public void OnPointerExit(PointerEventData eventDate){
		//image change;
		}
	}

