using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecipeDisplayItem : DisplayItem
{
	public void UpdateComponent( Item itemData, int count, Player playerData )
	{
		string result = null;
		if( playerData.FindItemByID( itemData.ID ) == null )
			result += "0";
		else
			result += playerData.FindItemByID( itemData.ID ).Count.ToString();
			
		itemText.text = result + " / " + count.ToString();
		itemImage.sprite = Resources.Load<Sprite>( "ItemIcon/" + itemData.Name );		                                   
	}


}
