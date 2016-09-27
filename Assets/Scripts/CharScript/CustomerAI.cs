using UnityEngine;
using System;
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
	[SerializeField] GameObject mat;

	[SerializeField] public Collider[] Items;
	[SerializeField] GameObject wantItem;
	[SerializeField] bool sellItem;
	[SerializeField] CustomerStep customerStep;
	[SerializeField] public float makeWaitTime;

	public enum ElfCustomerPatternName
	{
		Idle = 1,
		Run,
		Motion}
;

	public enum CustomerStep : int
	{
		GoStore = 1,
		RotatePlayer,
		WaitingTime,
		Bargin,
		GoAway}
;
	// Use this for initialization
	void Start()
	{
		elfCustomerAnimator = GetComponent<Animator>();
		buyItem = false;
		AIMoveNav = GetComponent<NavMeshAgent>();
		elfPlayer = GameObject.FindGameObjectWithTag( "Player" );
		wantItem = null;
		mat = GameObject.FindGameObjectWithTag( "Mat" );
		customerStep = CustomerStep.GoStore;
		makeWaitTime = 0;

	}

	void PetActiveFalse()
	{
		
		Pet.SetActive( false );

		if( buyItem )
		{
			AIMoveNav.ResetPath();
			elfCustomerPattern( ElfCustomerPatternName.Motion );
			transform.LookAt( elfPlayer.transform.position );

//			transform.rotation = Quaternion.Lerp (transform.rotation, 
//			Quaternion.LookRotation (elfPlayer.transform.position - transform.position, Vector3.up), Time.deltaTime * 5.0f);
		}

	}

	void GoAway()
	{
		Vector3 goAwayVector = new Vector3( -20, 0, -20 );
		elfCustomerPattern( ElfCustomerPatternName.Run );
		if( AniInfo.IsName( "Run" ) )
		{
			Pet.SetActive( true );

			transform.position = new Vector3( transform.position.x, transform.position.y + 0.55f, transform.position.z );
		}

		AIMoveNav.SetDestination( goAwayVector );

		Destroy( this.gameObject, 10.0f );
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = new Vector3( transform.position.x, 0, transform.position.z );
		AniInfo = this.elfCustomerAnimator.GetCurrentAnimatorStateInfo( 0 );
	
		Vector3 buyPos = new Vector3( 0.13f, -0.9166f, -11.66f );

		float insertPos = Vector3.Distance( transform.position, buyPos );

		Items = Physics.OverlapSphere( transform.position, 100, 1 << LayerMask.NameToLayer( "Item" ) );


		int randomItemNum = UnityEngine.Random.Range( 0, Items.Length - 1 );

		try
		{
			wantItem = Items[randomItemNum].gameObject;

		}
		catch ( IndexOutOfRangeException e )
		{
			Debug.Log( e.StackTrace );
			Debug.Log( e.Message );
		}
		finally
		{

			if( customerStep == CustomerStep.GoStore )
			{
				AIMoveNav.SetDestination( buyPos );
				elfCustomerPattern( ElfCustomerPatternName.Run );
				if( AniInfo.IsName( "Run" ) )
				{
					Pet.SetActive( true );
					transform.position = new Vector3( transform.position.x, transform.position.y + 0.55f, transform.position.z );
				}
				if( insertPos < 1.1f )
				{
					buyItem = true;
					customerStep = CustomerStep.RotatePlayer;
				}

			}
			else if( customerStep == CustomerStep.RotatePlayer )
			{
				PetActiveFalse();

				if( wantItem == null )
				{
					customerStep = CustomerStep.WaitingTime;
			
				}
				else if( wantItem != null )
				{

					customerStep = CustomerStep.Bargin;
				}

			}
			else if( customerStep == CustomerStep.WaitingTime )
			{
			
				makeWaitTime += Time.deltaTime;

				if( makeWaitTime >= 5.0f )
				{
					customerStep = CustomerStep.GoAway;
					makeWaitTime = 0;
				}
				else if( makeWaitTime <= 5.0f )
				{
					PetActiveFalse();	
					customerStep = CustomerStep.Bargin;
				}
	
			}
			else if( customerStep == CustomerStep.Bargin )
			{
				PetActiveFalse();
				makeWaitTime += Time.deltaTime;

				if( makeWaitTime >= 6.0f )
				{
					if( wantItem == null )
					{
						customerStep = CustomerStep.GoAway;				
					}
					else
					{
						Destroy( wantItem, 1f );

						customerStep = CustomerStep.GoAway;
					}
				}

			}
			else if( customerStep == CustomerStep.GoAway )
			{
				GoAway();
			}
		}
	}

	public void elfCustomerPattern( ElfCustomerPatternName Status )
	{

		switch ( Status )
		{
			case ElfCustomerPatternName.Idle:
				elfCustomerAnimator.SetInteger( "state", 1 );
				break;

			case ElfCustomerPatternName.Run:
				elfCustomerAnimator.SetInteger( "state", 2 );
				break;

			case ElfCustomerPatternName.Motion:
				elfCustomerAnimator.SetInteger( "state", 3 );
				break;
		}

	}

	public void MakeTime( bool state )
	{
		if( state )
		{
			buyItem = true;
		}
		else
		{
			buyItem = false;
		}
	}
}
