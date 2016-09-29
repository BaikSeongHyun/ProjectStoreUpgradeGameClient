using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIUpsideBar : MonoBehaviour
{
	[SerializeField] UserInterfaceController uiManager;

	[SerializeField] Text storeName;
	[SerializeField] Text storeStepInfo;
	[SerializeField] Image storeStepInfoGauge;
	[SerializeField] Text money;

	void Start()
	{
		
	}

	// update this object -> update location : mainUI -> game manager
	public void UpdateUpsideBar( Player player, Store presentStore )
	{
		storeName.text = presentStore.StoreName;
		storeStepInfo.text = "Step." + presentStore.Step.ToString() + " (" + presentStore.PresentEXP.ToString() + "/" + presentStore.RequireEXP + ")";
		storeStepInfoGauge.fillAmount = presentStore.FillEXP;
		money.text = "$ " + player.Money.ToString();
	}

	// on click method -> go to select
	public void OnClickGotoSelect()
	{			
		// go to select store UI
		Debug.Log( "Go to Select" );
	}

	// on click method -> exit button
	public void OnClickExitButton()
	{
		Debug.Log( "Exit game Popup" );
	}

	//On Click method -> exit button
	public void ExitGameClose()
	{
	}

	// on Click method -> exit button - > reconfirmClick
	public void ExitGameReconfirm()
	{
		Application.Quit();
		Debug.Log( "Exit Gameover" );
	}

}
