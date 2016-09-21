﻿using UnityEngine;
using System.Collections;

public class HouseManager : MonoBehaviour
{

	public GameObject myHouse;
	public Renderer rend;
	public float mat;
	public GameObject playerElf;
	public BoxCollider[] HouseBox;
	public BoxCollider box;

	// Use this for initialization
	void Start ()
	{
		myHouse = GameObject.FindGameObjectWithTag ("House");
		//rend = GetComponent<Renderer> ();
		rend = GameObject.FindGameObjectWithTag("House").GetComponent<Renderer>();//GetComponent<Renderer> ();
		playerElf = GameObject.FindGameObjectWithTag ("Player");



	}

	// Update is called once per frame
	void Update ()
	{

		float searchRange = Vector3.Distance (playerElf.transform.position, myHouse.transform.position);

		mat = searchRange - 18;


		if (mat >= 1)
		{
			rend.material.color = new Color (1, 1, 1, 1);
		}
		else if (mat < 1)
		{
			if (mat < 0)
			{
				myHouse.SetActive (false);
				mat = 0;
			}
			else
			{

				myHouse.SetActive (true);
				rend.material.color = new Color (1, 1, 1, mat);
			}



		}
	}


	public void HouseActiveTrue(bool state)
	{
		if (state)
		{
			myHouse.SetActive (true);
		}
		else
		{
			myHouse.SetActive (false);    
		}
	}





}