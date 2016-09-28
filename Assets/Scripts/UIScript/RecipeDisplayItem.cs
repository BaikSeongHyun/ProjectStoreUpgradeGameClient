using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecipeDisplayItem : DisplayItem
{
	public void UpdateComponent( string itemID, int count, Player playerData )
	{
		// set image
		itemImage.sprite = Resources.Load<Sprite>( "ItemIcon/" + Database.Instance.FindItemUseID(itemID).Name );	

		// set item text
		string result = null;
		if( playerData.FindItemByID( itemID ) == null )
			result += "0";
		else
			result += playerData.FindItemByID( itemID ).Count.ToString();

		result += " / " + count.ToString ();
		itemText.text = result;
	}

	public void ClearComponent()
	{
		string path = "???";
		itemImage.sprite = null;
		//itemImage.sprite = Resources.Load<Sprite> (path);//set default
		itemText.text = null;
	}
}
