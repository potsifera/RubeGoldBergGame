using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {
	

	public Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		initialPosition = gameObject.transform.position;
		Debug.Log(initialPosition);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag("Ground"))
		{
			Debug.Log("this is a collision with the ground");
			gameObject.transform.position = initialPosition;
			
		}
	}




}
