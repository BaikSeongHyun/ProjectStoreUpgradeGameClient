using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInterfaceController : MonoBehaviour
{
	[SerializeField] GameObject upsideBar;
	[SerializeField] UIUpsideBar upsideBarLogic;
	[SerializeField] GameObject selectView;
	[SerializeField] StoreSelectView selectViewLogic;
	[SerializeField] GameObject firstView;
	[SerializeField] GameViewFirstStep firstViewLogic;
	[SerializeField] GameObject secondView;
	[SerializeField] GameViewSecondStep secondViewLogic;

	void Awake()
	{
		LinkComponentElement();
	}

	void Start()
	{
		AllComponentShift();
	}

	public void LinkComponentElement()
	{
		upsideBar = transform.Find( "UpsideBar" ).gameObject;
		upsideBarLogic = upsideBar.GetComponent<UIUpsideBar>();

		selectView = transform.Find( "StoreSelectUI" ).gameObject;
		selectViewLogic = selectView.GetComponent<StoreSelectView>();

		firstView = transform.Find( "FirstStepUI" ).gameObject;
		firstViewLogic = firstView.GetComponent<GameViewFirstStep>();

		secondView = transform.Find( "SecondStepUI" ).gameObject;
		secondViewLogic = secondView.GetComponent<GameViewSecondStep>();
	}

	public void AllComponentShift()
	{
		upsideBar.transform.localPosition = new Vector3( 2000f, 0f, 0f );
		selectView.transform.localPosition = new Vector3( 2000f, 0f, 0f );
		firstView.transform.localPosition = new Vector3( 2000f, 0f, 0f );
		secondView.transform.localPosition = new Vector3( 2000f, 0f, 0f );
	}

	public void MakeGameStep( int presentStep )
	{		
		AllComponentShift();

		switch ( presentStep )
		{
			case 0:
				selectView.transform.localPosition = new Vector3( 0f, 0f, 0f );
				break;
			case 1:
				upsideBar.transform.localPosition = new Vector3( 0f, 0f, 0f );
				firstView.transform.localPosition = new Vector3( 0f, 0f, 0f );
				break;
			case 2:
				upsideBar.transform.localPosition = new Vector3( 0f, 0f, 0f );
				secondView.transform.localPosition = new Vector3( 0f, 0f, 0f );
				break;
		}
	}

	public void UIUpdate( Player playerData, Store presentStore )
	{
		if( upsideBar.activeSelf )
			upsideBarLogic.UpdateUpsideBar( playerData, presentStore );
		if( selectView.activeSelf )
			selectViewLogic.UpdateUIComponent();
		if( firstView.activeSelf )
			firstViewLogic.UpdateUIComponent();
		if( secondView.activeSelf )
			secondViewLogic.UpdateUIComponent();
	}
}
