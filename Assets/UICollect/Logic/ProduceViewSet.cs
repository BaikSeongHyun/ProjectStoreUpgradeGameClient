using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class ProduceViewSet : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler 
	{
	[SerializeField] DisplayItem[] produceAbleItemList;

	//produce item;
	[SerializeField] Item produceItem;
	[SerializeField] float produceTime;
	[SerializeField] private Image stateGauge;

	//produce item button;
	[SerializeField] private GameObject ProduceButton;

	//select item;
	[SerializeField] Item selectedItem;
	[SerializeField] Image selectedImage;
	[SerializeField] RecipeDisplayItem[] selectedItemRecipeList;




	private FirstStep firstStep;//fuck

	public void Link(){
		ProduceButton = GameObject.Find ("ProduceButton");
		stateGauge = GameObject.Find ("StateGauge").GetComponent<Image>();
	}

	void Start(){
		Link ();//fuck
	}

	public void ProduceItemList(Store data)
	{
		produceAbleItemList = new DisplayItem[data.CreateItemSet.Length];
		for (int i = 0; i < produceAbleItemList.Length; i++) {
			produceAbleItemList [i].LinkComponentElement ();
			produceAbleItemList [i].UpdateComponentElement (data.CreateItemSet [i]);
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

	//button click method
	public void SetCreateItem()
	{
		// count recipe

		produceTime = 0.0f;
		produceItem = selectedItem;
	}

	public void ProduceProcess(Player data){
		
		if( produceItem != null )
		{
			produceTime += Time.deltaTime;
			stateGauge.fillAmount = produceTime / produceItem.MakeTime;

			if( produceTime >= produceItem.MakeTime )
			{
				data.AddItem( produceItem );
				produceItem = null;
			}
		}
	}


	public void OnPointerDown(PointerEventData eventDate){
	}

	public void OnPointerEnter(PointerEventData eventDate){
		//image change;
	}

	public void OnPointerExit(PointerEventData eventDate){
		//image change;
	}



	}

