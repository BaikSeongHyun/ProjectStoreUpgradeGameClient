using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoginForm : MonoBehaviour
{
	[SerializeField] InputField idInput;
	[SerializeField] InputField passwordInput;

	public string ID
	{
		get { return idInput.text; }
	}

	public string Password
	{
		get { return passwordInput.text; }	
	}
	
	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (idInput.isFocused)
		{
			if (Input.GetKeyUp( KeyCode.Tab ))
				passwordInput.Select();
		}
		
		if (passwordInput.isFocused)
		{
			if (Input.GetKeyUp( KeyCode.KeypadEnter ))
				;
		}
	}
}
