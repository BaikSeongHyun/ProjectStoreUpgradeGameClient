using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateViewSet : MonoBehaviour
{
	// create list
	[SerializeField] DisplayItem[] createList;

	// select item
	[SerializeField] Item selectedItem;
	[SerializeField] Image selectedImage;
	[SerializeField] RecipeDisplayItem[] selectedItemRecipeList;

	// create item
	[SerializeField] Image createTimeBar;
	[SerializeField] Item createItem;
	[SerializeField] float createTime;

	// link component element
	public void LinkComponentElement()
	{

	}


	public void CreateItemList( Store data )
	{
		//create s
		createList = new DisplayItem[data.CreateItemSet.Length];

		for ( int i = 0; i < createList.Length; i++ )
		{
			createList[i].LinkComponentElement();
			createList[i].UpdateComponentElement( data.CreateItemSet[i] );
		}
	}

	// update component element
	public void UpdateSelectedItem( Player data )
	{
		selectedImage.sprite = Resources.Load<Sprite>( "ItemIcon/" + selectedItem.Name );

		selectedItemRecipeList = new RecipeDisplayItem[selectedItem.Recipe.Length];
		for ( int i = 0; i < selectedItemRecipeList.Length; i++ )
		{
			selectedItemRecipeList[i].UpdateComponent( selectedItem, selectedItem.RecipeCount[i], data );
		}
	}

	// button - on click method
	public void SetCreateItem()
	{
		createTime = 0.0f;
		createItem = selectedItem;
	}

	public void CreateItem( Player data )
	{
		if( createItem != null )
		{
			createTime += Time.deltaTime;
			createTimeBar.fillAmount = createTime / createItem.MakeTime;

			if( createTime >= createItem.MakeTime )
			{
				data.AddItem( createItem );
				createItem = null;
			}
		}
	}
}
