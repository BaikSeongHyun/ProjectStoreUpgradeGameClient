using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
	[SerializeField] public Image boardQuest;
	[SerializeField] 	public GameObject playerElf;
	[SerializeField] public GameObject table;
	[SerializeField] float searchRange;

	public ElfCharacter Elfchar;

	public bool makeTime;

	public bool MakeTime 
	{
		get {return this.makeTime;}
		set {makeTime = value;}
	}
	

	// Use this for initialization
	void Start ()
	{
		boardQuest = transform.Find ("RecipeCheckEvent").Find ("RecipeImage").GetComponent<Image>();
		playerElf = GameObject.FindGameObjectWithTag ("Player");
		ControlBoardImage (false);

	}
	
	// Update is called once per frame
	void Update () 
	{
		searchRange = Vector3.Distance (playerElf.transform.position, table.transform.position);

//		Debug.Log (searchRange);
	}

	public void ControlBoardImage(bool state)
	{
		boardQuest.enabled = state;
	}

	void OnMouseEnter()
	{
		if (searchRange < 3.5)
		{
			ControlBoardImage (true);
		}
	}

	void OnMouseExit()
	{
		ControlBoardImage (false);
	}

	void OnMouseDown()
	{
		ControlBoardImage (false);
		Elfchar.MakeTime(true);
		// if UI Exit == Elfchar.MakeTime (false);
		Debug.Log ("UI RecipeImage On and breadmaking");

	}


}
