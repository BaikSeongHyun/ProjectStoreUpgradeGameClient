using UnityEngine;
using System.Collections;

public class HouseManager : MonoBehaviour
{

	public GameObject myHouse;
	public Renderer rend;
	public float mat;
	public GameObject playerElf;
	public BoxCollider[] HouseBox;
	public BoxCollider box;

	public float Mat 
	{
		get {
			return this.mat;
		}
		set {
			mat = value;
		}
	}
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

		mat = searchRange - 9;


		if (mat >= 1)
		{
			rend.material.color = new Color (1, 1, 1, 1);

		}
		else if (mat < 1)
		{
			if (mat < 0.2f)
			{

				mat = 0.2f;

			}
			else
			{

				rend.enabled = true;
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