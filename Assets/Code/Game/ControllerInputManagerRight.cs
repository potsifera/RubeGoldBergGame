using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputManagerRight : MonoBehaviour {

	public SteamVR_TrackedObject trackedObject;
	public SteamVR_Controller.Device device;

	public ObjectMenuManager objectMenuManager;
	public GameObject objectMenu;

	//swipe
	public float swipeSum;
	public float touchLast;
	public float touchCurrent;
	public float distance;
	public bool hasSwipedLeft;
	public bool hasSwipedRight;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
		objectMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input((int)trackedObject.index);

		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
			touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
		}

		if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log("right touchpad");
			objectMenu.SetActive(true);
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

			if (!hasSwipedLeft)
			{
				if (swipeSum < 0.5f)
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
			objectMenu.SetActive(false);

		}

		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			//spawn object currently selected by menu
			SpawnObject();
		}

	}

	void SwipeLeft()
	{
		objectMenuManager.MenuLeft();
		Debug.Log("Swipeleft");
	}

	void SwipeRight()
	{
		objectMenuManager.MenuRight();
		Debug.Log("Swipe right");
	}

	void SpawnObject()
	{
		objectMenuManager.SpawnCurrentObject();
	}

	
}
