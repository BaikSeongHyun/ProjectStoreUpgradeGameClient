using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class ProduceViewSet : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler 
	{



//	//produce item;
//	[SerializeField] Item produceItem;
//	[SerializeField] float produceTime;
//	[SerializeField] private Image stateGauge;
//
//	//select item; ItemView
//	[SerializeField] Item selectedItem;
//	[SerializeField] Image selectedImage;
//	[SerializeField] RecipeDisplayItem[] selectedItemRecipeList;

	//produce item button;
	[SerializeField] private ProduceButton produceButton;
	[SerializeField] ProduceAbleItem produceAbleItem;
	[SerializeField] RecipeItemList recipeItemList;
	[SerializeField] Item selectItem;








	public void LinkComponentElement(){
		produceButton.LinkComponentElement ();
		produceAbleItem.LinkComponentElement ();
		recipeItemList.LinkComponentElement ();

		//produceAbleItem
//		stateGauge = GameObject.Find ("StateGauge").GetComponent<Image>();
	}



	public void ProduceAbleItemListSend(Store data)
	{
		produceAbleItem.ProduceAbleItemList (data);

	}

	// update component element
	public void UpdateSelectedItemSend( Player data )
	{
		produceAbleItem.UpdateSelectedItem (data);
	}

	//button click method
	public void SetProduceItem()
	{
		// count recipe

//		produceTime = 0.0f;
//		produceItem = selectedItem;
		Debug.Log("b");
	}


	public void ProduceProcess(Player data){
		
//		if( produceItem != null )
//		{
//			produceTime += Time.deltaTime;
//			stateGauge.fillAmount = produceTime / produceItem.MakeTime;
//
//			if( produceTime >= produceItem.MakeTime )
//			{
//				data.AddItem( produceItem );
//				produceItem = null;
//			}
//		}
	}

	public void ClickAndSelectItem(PointerEventData eventData){
		
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

