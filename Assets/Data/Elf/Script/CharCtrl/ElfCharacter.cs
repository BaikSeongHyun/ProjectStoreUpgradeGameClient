using UnityEngine;
using System.Collections;

public class ElfCharacter : MonoBehaviour 
{
	[SerializeField] Vector3 destination;

	[SerializeField] Animator elfAnimator;
	[SerializeField] AnimatorStateInfo AniInfo;
	[SerializeField] GameObject Pet;
	[SerializeField] NavMeshAgent moveAgent;
	[SerializeField] public bool makeTime;
	[SerializeField] public bool isStopMat = false;
	[SerializeField] public int Lv;

	public enum ElfPatternName
	{
		Idle =1,
		Run,
		Motion
	};

	public Vector3 Destination
	{
		get{return destination;}
		set{ destination = value; }
	}


	// Use this for initialization
	void Start () 
	{
		destination = transform.position;
		elfAnimator = GetComponent<Animator> ();
		moveAgent = GetComponent<NavMeshAgent> ();
	}
	void PetActiveFalse()
	{
		Pet.SetActive (false);

		if (isStopMat)
		{
			transform.rotation = new Quaternion (transform.rotation.x, 180, transform.rotation.z, 0);
			if (Vector3.Distance (destination, transform.position) <= 1.1f)
			{
				makeTime = true;
			}
		}
		if (isStopMat && makeTime)
		{
			elfPattern (ElfPatternName.Motion);
		}
	}
	// Update is called once per frame
	void Update () 
	{

		if (!makeTime)
		{
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
			AniInfo = this.elfAnimator.GetCurrentAnimatorStateInfo (0);

			if (Vector3.Distance (destination, transform.position) <= 1.1f)
			{

				elfPattern (ElfPatternName.Idle);
				moveAgent.ResetPath ();
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			}
			else if (Vector3.Distance (destination, transform.position) >= 1.1f)
			{
				elfPattern (ElfPatternName.Run);
				if (AniInfo.IsName ("Run"))
				{
					
					Pet.SetActive (true);
					moveAgent.SetDestination (Destination);
					transform.position = new Vector3 (transform.position.x, transform.position.y + 0.55f, transform.position.z);
				}

			}
		}
		else
		{
			elfPattern (ElfPatternName.Motion);
		}

	
	}

	public void elfPattern(ElfPatternName Status)
	{

		switch (Status)
		{
			case ElfPatternName.Idle:
			elfAnimator.SetInteger ("state",1);
			break;

			case ElfPatternName.Run:
			elfAnimator.SetInteger ("state",2);
			break;

			case ElfPatternName.Motion:
			elfAnimator.SetInteger ("state",3);
			break;
		}

	}
	public void MakeTime(bool state)
	{
		if(state)
		{
			makeTime = true;
		}
		else
		{
			makeTime = false;
		}
		
	}



}