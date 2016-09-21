using UnityEngine;
using System.Collections;

public class SummonItem : MonoBehaviour 
{

	public GameObject TempObject;
	public Vector3 Transformvec;
	// Use this for initialization

	public Vector3 itemSummonDestination;


	public Vector3 ItemSummonDestination
	{
		get{return itemSummonDestination;}
		set{ itemSummonDestination = value; }
	}

	void Start ()
	{
		Transformvec =	transform.localPosition = new Vector3 (transform.position.x,transform.position.y,transform.position.z);

	}
	
	// Update is called once per frame
	void Update () 
	{
		Instantiate (TempObject, Transformvec, transform.rotation);		
	}
}
