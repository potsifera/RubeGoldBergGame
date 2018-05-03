using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction2 : MonoBehaviour
{

	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;
	public float throwForce = 1.5f;

	//swipe
	public float swipeSum;
	public float touchLast;
	public float touchCurrent;
	public float distance;
	public bool hasSwipedLeft;
	public bool hasSwipedRight;
	public ObjectMenuManager objectMenuManager;

	// Use this for initialization
	void Start()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	// Update is called once per frame
	void Update()
	{
		device = SteamVR_Controller.Input((int)trackedObj.index);

		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad)) {
			touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x; 
		}
		if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
		{
			touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
			distance = touchCurrent - touchLast;
			touchLast = touchCurrent;
			swipeSum += distance;

			if (!hasSwipedRight)
			{
				if (swipeSum > 0.5f)
				{
					swipeSum = 0;
					SwipeRight();
					hasSwipedRight = true;
					hasSwipedLeft = false;
				}
			}

			if (!hasSwipedRight)
			{
				if (swipeSum < -0.5f)
				{
					swipeSum = 0;
					SwipeLeft();
					hasSwipedLeft = true;
					hasSwipedRight = false;
				}
			}
		}

		if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
		{
			swipeSum = 0;
			touchCurrent = 0;
			touchLast = 0;
			hasSwipedLeft = false;
			hasSwipedRight = false;
		}

	}

	void SwipeLeft()
	{
		objectMenuManager.MenuLeft();
		Debug.Log("SwipeLeft");
	}

	void SwipeRight() {
		objectMenuManager.MenuRight();
		Debug.Log("SwipeRight");
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag("Throwable"))
		{
			if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
			{
				ThrowObject(col);
			}
			else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
			{
				GrabObject(col);
			}
		}
	}

	void GrabObject(Collider col)
	{
		col.transform.SetParent(gameObject.transform);
		col.GetComponent<Rigidbody>().isKinematic = true;
		device.TriggerHapticPulse(2000);
		Debug.Log("you are touching down the trigger on an object");
	}

	void ThrowObject(Collider col)
	{
		col.transform.SetParent(null);
		Rigidbody rigidBody = col.GetComponent<Rigidbody>();
		rigidBody.isKinematic = false;
		rigidBody.velocity = device.velocity * throwForce;
		rigidBody.angularVelocity = device.angularVelocity;
		Debug.Log("you have released the trigger");
	}
}
