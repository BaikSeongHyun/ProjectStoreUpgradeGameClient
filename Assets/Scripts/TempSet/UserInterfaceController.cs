using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInterfaceController : MonoBehaviour
{
	[SerializeField] GameObject upsideBar;
	[SerializeField] UIUpsideBar upsideBarLogic;
	[SerializeField] GameObject stepUIObject;


	void Start ()
	{
		MakeGameStep (Step.First);
	}

	public enum Step : int
	{
		First = 1,
		Second = 2,
		Third = 3}
	;




	void Update ()
	{
				
	}

	public void MakeSelectUI ()
	{

	}


	public void MakeGameStep (Step presentStep)
	{
		Destroy (stepUIObject);

		switch (presentStep)
		{
		case Step.First:
			stepUIObject = (GameObject)Instantiate (Resources.Load<GameObject> ("UIObject/CreateOrSelect"), transform.position, transform.rotation);
			break;

		case Step.Second:
			stepUIObject = (GameObject)Instantiate (Resources.Load<GameObject> ("UIObject/FirstStepUI"), transform.position, transform.rotation);
			stepUIObject.name = "FirstStepUI";
			break;
		
		case Step.Third:

			stepUIObject = (GameObject)Instantiate (Resources.Load<GameObject> ("UIObject/CharcterManager"), transform.position, transform.rotation);
			stepUIObject.name = "CharacterManager";
			break;
		}
	}

	public void UIUpdate (Player playerData, Store presentStore)
	{
		if (upsideBar.activeSelf)
			upsideBarLogic.UpdateUpsideBar (playerData, presentStore);
	}
}
