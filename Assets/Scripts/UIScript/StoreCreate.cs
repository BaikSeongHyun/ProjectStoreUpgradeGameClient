using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreCreate : MonoBehaviour
{
	[SerializeField] Store createTargetInfo;
	[SerializeField] GameManager manager;
	[SerializeField] Image createTargetImage;

	void Awake()
	{
		LinkComponentElement();
	}

	public void LinkComponentElement()
	{
		manager = GameObject.Find( "GameLogic" ).GetComponent<GameManager>();
		createTargetImage = transform.Find( "CreateTargetImage" ).GetComponent<Image>();
	}

	public void OnClickSetCreateStore( int data )
	{
		switch ( data )
		{
		// bakery
			case 1:
				createTargetInfo = Database.Instance.FindStoreUseID( "store0001" );
				createTargetImage.sprite = Resources.Load<Sprite>( "StoreImage/store0001" );
				break;
		// cafe
			case 2:
				createTargetInfo = Database.Instance.FindStoreUseID( "store0002" );
				createTargetImage.sprite = Resources.Load<Sprite>( "StoreImage/store0002" );
				break;
		// bar
			case 3:
				createTargetInfo = Database.Instance.FindStoreUseID( "store0003" );
				createTargetImage.sprite = Resources.Load<Sprite>( "StoreImage/store0003" );
				break;
		}
	}

	// on click method -> close popup
	public void OnClickClosePopUp()
	{
		this.gameObject.SetActive( false );
	}

	// on click method -> confirm create store
	public void OnClickConfirmStore()
	{
		if( createTargetInfo != null )
		{
			manager.SendCreateStore( createTargetInfo );
			OnClickClosePopUp();
		}
	}
}
