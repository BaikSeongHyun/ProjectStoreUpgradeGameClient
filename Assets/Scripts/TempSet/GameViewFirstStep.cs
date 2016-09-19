using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// step, game stage
public class GameViewFirstStep : MonoBehaviour
{

	//[SerializeField] GameManager manager;
	[SerializeField] ProduceMain produceMain;
	[SerializeField] SellViewSet sellItem;

	// link component element
	public void Awake()
	{
		produceMain.LinkComponentElement();
		sellItem.LinkComponentElement ();
	}

	void Update()
	{
//		produceItem.ProduceProcess( manager.PlayerData );
//		sellItem.SellProcess (manager.PlayerData);

	}

}
