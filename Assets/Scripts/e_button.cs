using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_button : MonoBehaviour
{

	public GameObject Painting;
	private SphereCollider collider;
	
	void Awake()
	{
		collider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	#region TriggerMethods
	public void OnTriggerEnter(Collider other)
	{
		Debug.Log("EBUTTONPRESSED");
		this.Painting.SetActive(false);
	}
	#endregion
	
	
}
