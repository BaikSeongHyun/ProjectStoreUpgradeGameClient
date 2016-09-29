using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoginForm : MonoBehaviour
{
	// field
	[SerializeField] GameManager manager;
	[SerializeField] InputField ipInput;
	[SerializeField] InputField portInput;
	[SerializeField] InputField idInput;
	[SerializeField] InputField passwordInput;

	//property
	public string IP { get { return ipInput.text; } }

	public int Port { get { return 9800; } }

	public string ID { get { return idInput.text; } }

	public string Password { get { return passwordInput.text; } }
	
	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if( ipInput.isFocused )
		{
			if( Input.GetKeyUp( KeyCode.Tab ) )
				portInput.Select();
		}
		else if( portInput.isFocused )
		{
			if( Input.GetKeyUp( KeyCode.Tab ) )
				idInput.Select();
		}
		else if( idInput.isFocused )
		{
			if( Input.GetKeyUp( KeyCode.Tab ) )
				passwordInput.Select();
		}		
		else if( passwordInput.isFocused )
		{
			if( Input.GetKeyUp( KeyCode.KeypadEnter ) )
				manager.SendJoinRequest();
		}
	}
}
