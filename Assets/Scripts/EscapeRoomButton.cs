using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRoomButton : MonoBehaviour
{

	private PasswordManager _passwordManager;
	public char Letter;

	void Start()
	{
		this._passwordManager = this.gameObject.GetComponentInParent<PasswordManager> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void PushButton()
	{
		this._passwordManager.EnterLetter (this.Letter);
	}
	
	#region TriggerMethods
	public void OnTriggerEnter(Collider other)
	{
		this.PushButton ();	
	}
	#endregion
	
	
}
