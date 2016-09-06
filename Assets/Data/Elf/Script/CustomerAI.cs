using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CustomerAI : MonoBehaviour 
{
	[SerializeField] Animator elfCustomerAnimator;
	[SerializeField] AnimatorStateInfo AniInfo;
	[SerializeField] GameObject Pet;
	[SerializeField] public bool buyItem;
	[SerializeField] public bool isStopMat = false;
	[SerializeField] List<GameObject> searchItemList = new List<GameObject>();
	[SerializeField] NavMeshAgent AIMoveNav;
	[SerializeField] GameObject elfPlayer;

	public enum ElfCustomerPatternName
	{
		Idle =1,
		Run,
		Motion
	};

	// Use this for initialization
	void Start () 
	{
		elfCustomerAnimator = GetComponent<Animator>();
		buyItem = false;
		AIMoveNav = GetComponent<NavMeshAgent> ();
		elfPlayer = GameObject.FindGameObjectWithTag ("Player");
	}

	void PetActiveFalse()
	{
		Pet.SetActive (false);

		if (buyItem)
		{
			AIMoveNav.ResetPath ();
			elfCustomerPattern(ElfCustomerPatternName.Motion);

			transform.rotation = Quaternion.Lerp (transform.rotation, 
				Quaternion.LookRotation (elfPlayer.transform.position - transform.position, Vector3.up), Time.deltaTime * 5.0f);



			//transform.LookAt (elfPlayer.transform.position);
		}
		else
		{
			elfCustomerPattern (ElfCustomerPatternName.Idle);
		}
		
		
	}
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		AniInfo = this.elfCustomerAnimator.GetCurrentAnimatorStateInfo (0);

		Vector3 buyPos = new Vector3 (0.13f,-0.9166f,-11.66f);

		float insertPos = Vector3.Distance (transform.position,buyPos);

		if (insertPos <= 1.1f)
		{
			buyItem = true;
		}

		if(!buyItem)
		{
			Debug.Log ("NotBuyitem");
			AIMoveNav.SetDestination (buyPos);
			elfCustomerPattern (ElfCustomerPatternName.Run);
			if (AniInfo.IsName ("Run"))
			{
				Pet.SetActive (true);
				transform.position = new Vector3 (transform.position.x, transform.position.y + 0.55f, transform.position.z);

			}
		}
		else
		{
			PetActiveFalse ();
		}


	}

	public void elfCustomerPattern(ElfCustomerPatternName Status)
	{

		switch (Status)
		{
			case ElfCustomerPatternName.Idle:
			elfCustomerAnimator.SetInteger ("state",1);
			break;

			case ElfCustomerPatternName.Run:
			elfCustomerAnimator.SetInteger ("state",2);
			break;

			case ElfCustomerPatternName.Motion:
			elfCustomerAnimator.SetInteger ("state",3);
			break;
		}

	}

	public void MakeTime(bool state)
	{
		if (state)
		{
			buyItem = true;
		}
		else
		{
			buyItem = false;
		}
	}

	public void BuyItem()
	{
				
	}


}
