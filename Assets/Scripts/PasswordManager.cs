using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PasswordManager : MonoBehaviour {

	public string Password;

	private Queue<char> _passwordAsChars;
	private int _passwordLength;
	private Queue<char> _currentPassword;

	public GameObject Painting;

	// Use this for initialization
	void Start () {
		this._passwordLength = Password.Length;
		this._passwordAsChars = new Queue<char>(this._passwordLength);
		this._currentPassword = new Queue<char>(this._passwordLength);
		for (int i = 0; i < this._passwordLength; i++)
		{
			this._passwordAsChars.Enqueue(this.Password [i]);
			this._currentPassword.Enqueue('*');
		}
		Debug.LogFormat ("Correct password: {0}", this._passwordAsChars.ToString ());
		Debug.LogFormat ("Current password: {0}", this._currentPassword.ToString ());
	}

	public void EnterLetter(char letter)
	{
		// add the current letter to the queue
		this._currentPassword.Dequeue();
		this._currentPassword.Enqueue (letter);

		for (int i = 0; i < this._passwordLength; i++) {
			if (this._currentPassword.ElementAt (i) != this._passwordAsChars.ElementAt (i))
			{
				Debug.LogFormat ("Password Incorrect. Last Key pushed {0}", letter.ToString ());
				return;
			}
		}
		Debug.Log ("success! Password correct!");
		this.TriggerResult ();
	}

	private void TriggerResult()
	{
		// triggered result is simple, make the painting disappear
		this.Painting.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
