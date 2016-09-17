using UnityEngine;
using System.Collections;

public class SecondStepUI : MonoBehaviour
{
	public GameObject recipeInventory;
	public bool inventoryButton = false;
	public bool cashStoreButton = false;
	public GameObject cashStore;

	// Use this for initialization
	void Start () 
	{
		LinkElement ();	
	}
	
	// Update is called once per frame

	void LinkElement()
	{
		recipeInventory = GameObject.Find ("RecipeUI");
		recipeInventory.SetActive (inventoryButton);
		cashStore = GameObject.Find ("CashStore");
		cashStore.SetActive (false);
	}

	public void RecipeModeOn()
	{		
		if (!inventoryButton)
		{
			inventoryButton = true;
			recipeInventory.SetActive (inventoryButton);
		}
		else if(inventoryButton)
		{
			inventoryButton = false;
			recipeInventory.SetActive (inventoryButton);
		}

	}
	public void CashModeOn()
	{
		if (!cashStoreButton)
		{
			cashStoreButton = true;
			cashStore.SetActive (cashStoreButton);

			inventoryButton = true;
			recipeInventory.SetActive (inventoryButton);
		}
		else if (cashStoreButton)
		{
			cashStoreButton = false;
			cashStore.SetActive (cashStoreButton);

			inventoryButton = false;
			recipeInventory.SetActive (inventoryButton);
		}
	}
}
