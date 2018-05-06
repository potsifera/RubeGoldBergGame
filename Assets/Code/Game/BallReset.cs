﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {
	

	public Vector3 initialPosition;
	public Rigidbody rb;

	public List<GameObject> starPrefabs;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		initialPosition = gameObject.transform.position;
		Debug.Log(initialPosition);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			Debug.Log("this is a collision with the ground");
			gameObject.transform.position = initialPosition;
			rb.velocity = new Vector3(0, 0, 0);
			rb.angularVelocity = new Vector3(0, 0, 0);

			foreach (GameObject star in starPrefabs) {
				star.SetActive(true);
			}

		}
	}




}
