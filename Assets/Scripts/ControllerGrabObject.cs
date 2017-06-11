using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//https://www.raywenderlich.com/149239/htc-vive-tutorial-unity
public class ControllerGrabObject : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	// 1
	private GameObject collidingObject; 
	// 2
	private GameObject objectInHand; 

	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	private void SetCollidingObject(Collider col)
	{
		// 1
		if (collidingObject || !col.GetComponent<Rigidbody>())
		{
			return;
		}
		// 2
		collidingObject = col.gameObject;
	}
	
	private void GrabObject()
	{
		// 1
		objectInHand = collidingObject;
		collidingObject = null;
		// 2
		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
		Debug.LogFormat("Added {0} to connected body", objectInHand.ToString());
	}
	
	private void ReleaseObject()
	{
		// 1
		Debug.LogFormat("Releasing object");
		if (GetComponent<FixedJoint>())
		{
			Debug.LogFormat("FixedJoint found, removing.");
			// 2
			GetComponent<FixedJoint>().connectedBody = null;
			Destroy(GetComponent<FixedJoint>());
			// 3
			Rigidbody handObjectRigidBody = objectInHand.GetComponent<Rigidbody>();
			if (handObjectRigidBody)
			{
				handObjectRigidBody.velocity = Controller.velocity;
				handObjectRigidBody.angularVelocity = Controller.angularVelocity;	
			}
		}
		// 4
		objectInHand = null;
	}
	
	private FixedJoint AddFixedJoint()
	{
		FixedJoint fx = gameObject.AddComponent<FixedJoint>();
		fx.breakForce = 20000;
		fx.breakTorque = 20000;
		return fx;
	}

	#region TriggerMethods
	public void OnTriggerEnter(Collider other)
	{
		SetCollidingObject(other);
	}

	public void OnTriggerStay(Collider other)
	{
		SetCollidingObject(other);
	}

	public void OnTriggerExit(Collider other)
	{
		if (!collidingObject)
		{
			return;
		}

		collidingObject = null;
	}
	#endregion

	// Update is called once per frame
	void Update () {
		// 1
		if (Controller.GetHairTriggerDown())
		{
			if (collidingObject)
			{
				Debug.LogFormat("Grabbing {0}", collidingObject.ToString());
				GrabObject();
			}
		}

// 2
		if (Controller.GetHairTriggerUp())
		{
			if (objectInHand)
			{
				ReleaseObject();
			}
		}
	}
}
