using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInterfaceController : MonoBehaviour
{
	[SerializeField] GameObject upsideBar;
	[SerializeField] UIUpsideBar upsideBarLogic;
	[SerializeField] GameObject stepUIObject;

	void Start()
	{
		MakeGameStep( Step.First );
	}

	public enum Step : int
	{
		First = 1,
		Second = 2}
;

	public void MakeSelectUI()
	{

	}


	public void MakeGameStep( Step presentStep )
	{
		Destroy( stepUIObject );

		switch ( presentStep )
		{
			case Step.First:
				stepUIObject = (GameObject) Instantiate( Resources.Load<GameObject>( "UIObject/MainUI" ), transform.position, transform.rotation );
				break;

			case Step.Second:
				stepUIObject = (GameObject) Instantiate( Resources.Load<GameObject>( "UIObject/GameViewFirstStep" ), transform.position, transform.rotation );
				break;
		}
	}

	public void UIUpdate( Player playerData, Store presentStore )
	{
		if( upsideBar.activeSelf )
			upsideBarLogic.UpdateUpsideBar( playerData, presentStore );
	}
}
