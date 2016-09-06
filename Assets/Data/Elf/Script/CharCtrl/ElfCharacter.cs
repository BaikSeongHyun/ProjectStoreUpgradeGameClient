using UnityEngine;
using System.Collections;

public class ElfCharacter : MonoBehaviour 
{
	[SerializeField] Vector3 destination;

	[SerializeField] Animator elfAnimator;
	[SerializeField] state presentState;
	[SerializeField] AnimatorStateInfo AniInfo;
	[SerializeField] Quaternion des;
	[SerializeField] GameObject Pet;
	[SerializeField] NavMeshAgent moveAgent;

	public enum state
	{
		Idle,
		Run
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
	}

	void PetActiveFalse()
	{
		Pet.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//Debug.Log (destination);
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		AniInfo = this.elfAnimator.GetCurrentAnimatorStateInfo(0);

		if (Vector3.Distance (destination,transform.position) <= 1.1f)
		{
			
			elfPattern ("Idle");	
			moveAgent.ResetPath ();
			transform.position = new Vector3 (transform.position.x, transform.position.y , transform.position.z);
		}
		else if(Vector3.Distance (destination,transform.position) >= 1.1f)
		{
			
			elfPattern ("Run");

			if (AniInfo.IsName ("Run"))
			{
				Pet.SetActive (true);
				moveAgent.SetDestination (Destination);
				transform.position = new Vector3 (transform.position.x, transform.position.y+0.55f , transform.position.z);

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
			elfAnimator.SetBool ("Idle", true);
			break;

		case "Run":
			presentState = state.Run;
			elfAnimator.SetBool ("Idle", false);
			elfAnimator.SetBool ("Run", true);
			break;

		}

	}
}
