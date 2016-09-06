using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class StepViewLogic : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler 
{
	Text stepTextField;
	// Use this for initialization

	//stepTextField.text = ("Step " + ???.step.ToString() +" (" + ???.presentExp.ToString() + " / " + ???.requireExp.ToString() + ") ");

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		//테두리강화
	}

	public void OnPointerExit (PointerEventData eventDate)
	{
		//테두리강화삭제
	}




}
