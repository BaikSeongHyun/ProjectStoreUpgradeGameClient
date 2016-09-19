using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;



public class ProduceViewSet : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler 
	{

	//this class control;
	[SerializeField] private ProduceButton produceButton;
	[SerializeField] ProduceAbleItem produceAbleItem;
	[SerializeField] RecipeItemList recipeItemList;

	//feature variable, this variable effected producebutton,itemview;
	[SerializeField] Item selectItem;

	public void recipe(){
		Player player;
		//player
	}
		

	//link
	public void LinkComponentElement(){
		produceButton.LinkComponentElement ();
		produceAbleItem.LinkComponentElement ();
		recipeItemList.LinkComponentElement ();

		//produceAbleItem
		//		stateGauge = GameObject.Find ("StateGauge").GetComponent<Image>();
	}


	//selectItem need Method;
	public void ProduceSelectItem(PointerEventData eventdata){
		//iteminfomationgetting from ProduceAbleItem;
		//selectItem = eventdata.pointerCurrentRaycast.gameObject.GetComponent<Item> ();
		Debug.Log ("this infomation get from ProduceAbleItem and send to Itemview");
		recipeItemList.SendItemViewItemUpdate(selectItem);
	}

	public Item GetProduceSelectItem()
	{return selectItem;}







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
	public void SetProduceItem(Item item)
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

