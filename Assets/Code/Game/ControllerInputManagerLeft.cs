﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputManagerLeft : MonoBehaviour
{
	public SteamVR_TrackedObject trackedObject;
	public SteamVR_Controller.Device device;

	// Teleporter
	private LineRenderer laser;
	public GameObject teleportAimerObject;
	public Vector3 teleportLocation;
	public GameObject player;
	public LayerMask laserMask;
	public static float yNudgeAmount = 0f; // specific to teleportAimerObject height
	private static readonly Vector3 yNudgeVector = new Vector3(0f, yNudgeAmount, 0f);
	public float Height = 1f; // specific to teleportAimerObject height;

	// Use this for initialization
	void Start()
	{
		trackedObject = GetComponent<SteamVR_TrackedObject>();
		laser = GetComponentInChildren<LineRenderer>();
	}

	void setLaserStart(Vector3 startPos)
	{
		laser.SetPosition(0, startPos);
	}

	void setLaserEnd(Vector3 endPos)
	{
		laser.SetPosition(1, endPos);
	}

	// Update is called once per frame
	void Update()
	{

		device = SteamVR_Controller.Input((int)trackedObject.index);

		if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
		{
			//   Debug.Log("pressing down");

			laser.gameObject.SetActive(true);
			teleportAimerObject.SetActive(true);

			laser.SetPosition(0, gameObject.transform.position);
			RaycastHit hit;

			// create bounds raycast condition // 

			if (Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask))
			{
				//     Debug.Log(hit.point);
				teleportLocation = hit.point;
				laser.SetPosition(1, hit.point);
				teleportAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y + Height, teleportLocation.z);
			}

			else
			{
				teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, transform.forward.y * 15 + transform.position.y, transform.forward.z * 15 + transform.position.z);
				RaycastHit groundRay;

				if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, laserMask))
				{
					teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, groundRay.point.y, transform.forward.z * 15 + transform.position.z);
					laser.SetPosition(1, transform.forward * 15 + transform.position);
					teleportAimerObject.transform.position = teleportLocation + new Vector3(0, Height, 0);
				}

				else
				{

					teleportLocation = Vector3.zero;
					laser.SetPosition(1, transform.forward * 15 + transform.position);
					teleportAimerObject.transform.position = teleportLocation + new Vector3(0, Height, 0);
				}

			}
		}

		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
		{
			if (teleportLocation != Vector3.zero)
			{
				laser.gameObject.SetActive(false);
				teleportAimerObject.SetActive(false);
				player.transform.position = teleportLocation;
			}
			else
			{
				laser.gameObject.SetActive(false);
				teleportAimerObject.SetActive(false);
				player.transform.position = player.transform.position;
			}

		}
	}
}

