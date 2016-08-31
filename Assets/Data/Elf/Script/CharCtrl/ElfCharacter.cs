using UnityEngine;
using System.Collections;

public class ElfCharacter : MonoBehaviour 
{
	Vector3 destination;

	Animator elfAnimator;
	state presentState;
	AnimatorStateInfo AniInfo;

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
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log (destination);
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		AniInfo = this.elfAnimator.GetCurrentAnimatorStateInfo(0);

		if (Vector3.Distance (destination,transform.position) <= 0.1f)
		{
			elfAnimator.Play ("Idle");	
	
		}
		else
		{
			Debug.Log ("Runin");
			elfPattern ("Run");

				if(AniInfo.IsName("Run"))
				{
					Vector3 direction = destination - this.transform.position;
					this.transform.LookAt (destination);
					direction.Normalize ();
					transform.Translate (direction * Time.deltaTime * 1, Space.World);

				}
			
		}
	
	}

	public void elfPattern(string Status)
	{

		switch (Status)
		{
			case "Idle":
				presentState = state.Idle;
				elfAnimator.SetBool ("Idle", true);
				break;

			case "Run":
				presentState = state.Run;
				elfAnimator.SetBool ("Run", true);
				break;

		}

	}
}
