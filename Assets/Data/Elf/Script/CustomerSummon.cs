using UnityEngine;
using System.Collections;

public class CustomerSummon : MonoBehaviour 
{

	public GameObject Customer;
	public float interval;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine ( CustomerSummonCoroutine() );	
	}
	
	// Update is called once per frame

	IEnumerator CustomerSummonCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds (interval);

			var CustomerName = Instantiate (Customer, transform.position, transform.rotation);
			CustomerName.name = "Customer";
		

		}
		
	}

}
