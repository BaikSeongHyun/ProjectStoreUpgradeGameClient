using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// step, game stage
public class GameViewFirstStep : MonoBehaviour
{

	[SerializeField] GameManager manager;
	[SerializeField] ProduceViewSet produceItem;
	[SerializeField] SellViewSet sellItem;

	// link component element
	public void Awake()
	{
		produceItem.Link();
	}

	void Update()
	{
		produceItem.ProduceProcess( manager.PlayerData );
	}

}
