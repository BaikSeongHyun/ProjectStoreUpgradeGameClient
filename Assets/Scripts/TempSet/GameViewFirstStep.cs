using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// step, game stage
public class GameViewFirstStep : MonoBehaviour
{

	//[SerializeField] GameManager manager;
	[SerializeField] ProduceMain produceMain;
	[SerializeField] SellViewSet sellMain;
	[SerializeField] Image backGround;

	// link component element
	public void Awake()
	{
		produceMain.LinkComponentElement();
		sellMain.LinkComponentElement ();
		backGround = transform.Find ("BackGround").GetComponent<Image> ();
	}


}
