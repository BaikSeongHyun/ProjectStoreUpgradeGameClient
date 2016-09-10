using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// step, game stage
public class GameViewFirstStep : MonoBehaviour
{

	[SerializeField] GameManager manager;
	[SerializeField] CreateViewSet makeItem;
	[SerializeField] SellViewSet sellItem;

	// link component element
	public void Awake()
	{
		makeItem.LinkComponentElement();
	}

	void Update()
	{
		makeItem.CreateItem( manager.PlayerData );
	}

}
