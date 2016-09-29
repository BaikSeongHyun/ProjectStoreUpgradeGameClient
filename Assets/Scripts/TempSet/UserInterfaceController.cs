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
		AllComponentShutDown();
	}

	void Start()
	{
		upsideBar.SetActive( false );
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

	public void AllComponentShutDown()
	{
		upsideBar.SetActive( false );
		selectView.SetActive( false );
		firstView.SetActive( false );
		secondView.SetActive( false );
	}

	public void MakeGameStep( int presentStep )
	{		
		AllComponentShutDown();

		switch ( presentStep )
		{
			case 0:
				selectView.SetActive( true );
				break;
			case 1:
				upsideBar.SetActive( true );
				firstView.SetActive( true );
				break;
			case 2:
				upsideBar.SetActive( true );
				secondView.SetActive( true );
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
