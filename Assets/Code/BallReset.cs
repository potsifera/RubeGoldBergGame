using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {
	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;

	public Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		initialPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag("Ground"))
		{
			gameObject.transform.position = initialPosition;
		}
	}




}
