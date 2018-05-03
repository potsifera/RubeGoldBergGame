using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;
	public float throwForce = 1.5f;


	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input((int)trackedObj.index);
		
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag("Throwable"))
		{
			if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
			{
				ThrowObject(col);
			}
			else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
				GrabObject(col);
			}
		}
	}

	void GrabObject(Collider col) {
		col.transform.SetParent(gameObject.transform);
		col.GetComponent<Rigidbody>().isKinematic = true;
		device.TriggerHapticPulse(2000);
		Debug.Log("you are touching down the trigger on an object");
	}

	void ThrowObject(Collider col) {
		col.transform.SetParent(null);
		Rigidbody rigidBody = col.GetComponent<Rigidbody>();
		rigidBody.isKinematic = false;
		rigidBody.velocity = device.velocity * throwForce;
		rigidBody.angularVelocity = device.angularVelocity;
		Debug.Log("you have released the trigger");
	}
}
