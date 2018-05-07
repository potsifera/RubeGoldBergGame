using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;
	public float throwForce = 1.5f;
	private Renderer ballRenderer;
	public Material activeBallMaterial;
	public Material inactiveBallMaterial;
	


	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input((int)trackedObj.index);
		
	}



	void OnTriggerStay(Collider other)
	{
		//if the ball is selected
		if (other.gameObject.CompareTag("Throwable") )
		{
	
			//trigger a throw
			if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
			{
				ThrowObject(other);
			}
			//grab the object
			else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
			{
				GrabObject(other);
			}
		}
		else {

		}

		if (other.gameObject.CompareTag("Structure"))
		{
			if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
			{
				GrabObject(other);
			}
			else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
			{
				ReleaseObject(other);
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
		Debug.Log("you have released the trigger and thrown");
	}

	void ReleaseObject(Collider col)
	{
		col.transform.SetParent(null);
		Rigidbody rigidbody = col.GetComponent<Rigidbody>();
		Debug.Log("you have released the object");
	}

	
}
