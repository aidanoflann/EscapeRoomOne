using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour {

	public GameObject Door;
	public GameObject StickStem;

	private BoxCollider _collider;
	private Rigidbody _rigidbody;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake()
	{
		this._collider = this.GetComponent<BoxCollider>();
		this._rigidbody = this.GetComponent<Rigidbody>();
	}
	
	public void OnTriggerEnter(Collider other)
	{
		Debug.LogFormat("COLLISION");
		if (other.gameObject == this.StickStem)
		{
			this._collider.enabled = false;
			Destroy(this._rigidbody);
			this.Door.SetActive(false);
			this.gameObject.transform.position = new Vector3(7.55f, 1.69f, -3.8f);
			this.gameObject.transform.eulerAngles = new Vector3(9.349f, -27.391f, 13.409f);
		}
	}
}
