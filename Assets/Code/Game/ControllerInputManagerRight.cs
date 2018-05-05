using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputManagerRight : MonoBehaviour {

	public SteamVR_TrackedObject trackedObject;
	public SteamVR_Controller.Device device;

	public GameObject player;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input((int)trackedObject.index);

		if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log("right touchpad");
		}
		
	}
}
