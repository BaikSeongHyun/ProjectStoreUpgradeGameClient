using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ElfCharacter : MonoBehaviour 
{
	[SerializeField] Vector3 destination;

	[SerializeField] Animator elfAnimator;
	[SerializeField] state presentState;
	[SerializeField] AnimatorStateInfo AniInfo;
	[SerializeField] Quaternion des;
	[SerializeField] GameObject Pet;
	[SerializeField] NavMeshAgent moveAgent;
	[SerializeField] public bool makeTime;
	[SerializeField] BoxCollider charBoxcollider;
	[SerializeField] public bool isStopMat = false;
	[SerializeField] List <GameObject> makeItem = new List<GameObject>();


	public enum state
	{
		Idle,
		Run,
		Motion
	};

	public Vector3 Destination
	{
		get{return destination;}
		set{ destination = value; }
	}

	public state State
	{
		get { return presentState;}		
	}

	// Use this for initialization
	void Start () 
	{
		destination = transform.position;
		elfAnimator = GetComponent<Animator> ();
		moveAgent = GetComponent<NavMeshAgent> ();
		charBoxcollider = transform.GetComponent<BoxCollider> ();
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
			elfPattern ("Motion");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (!makeTime)
		{
			charBoxcollider.enabled = true;

			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
			AniInfo = this.elfAnimator.GetCurrentAnimatorStateInfo (0);

			if (Vector3.Distance (destination, transform.position) <= 1.1f)
			{
				
				elfPattern ("Idle");	
				moveAgent.ResetPath ();
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			}
			else if (Vector3.Distance (destination, transform.position) >= 1.1f)
			{
				
				elfPattern ("Run");

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
			elfPattern ("Motion");
			charBoxcollider.enabled = false;
		}

		if (makeTime)
		{

			if (!EventSystem.current.IsPointerOverGameObject ())
			{
				if (Input.GetButtonDown ("Move"))
				{
					Instantiate (makeItem [0], Destination, transform.rotation);
				}
			}	
		}
	}

	public void elfPattern(string Status)
	{

		switch (Status)
		{
		case "Idle":
			presentState = state.Idle;
			elfAnimator.SetBool ("Run", false);
			elfAnimator.SetBool ("Motion", false);
			elfAnimator.SetBool ("Idle", true);
			break;

		case "Run":
			presentState = state.Run;
			elfAnimator.SetBool ("Idle", false);
			elfAnimator.SetBool ("Motion", false);
			elfAnimator.SetBool ("Run", true);
			break;
		case "Motion":
			presentState = state.Motion;
			elfAnimator.SetBool ("Idle", false);
			elfAnimator.SetBool ("Run", false);
			elfAnimator.SetBool ("Motion", true);
			break;
		}

	}

	public void MakeTime(bool state)
	{
		if (state)
		{
			makeTime = true;
		}
		else
		{
			makeTime = false;
		}
	}
}
