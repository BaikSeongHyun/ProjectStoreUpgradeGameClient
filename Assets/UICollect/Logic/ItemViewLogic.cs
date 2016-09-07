using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemViewLogic : MonoBehaviour {

	[SerializeField]Text itemName;
	[SerializeField]Image itemImage;

	// Use this for initialization
	void Start () {
		itemName = GetComponent<Text> ();
		itemImage = transform.Find ("ItemImage").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateMakingIteamInfo(Item selectedData)
	{
		itemName.text = selectedData.Name;
		//path ItemImage/Wheat
		itemImage.sprite = Resources.Load<Sprite> ("ItemImage/" + selectedData.Name);

	}
}
