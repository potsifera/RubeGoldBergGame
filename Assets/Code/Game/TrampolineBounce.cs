using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBounce : MonoBehaviour {

	
	private Rigidbody otherRB;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("something colided with trampoline");
		otherRB = other.GetComponent<Rigidbody>();
		otherRB.AddForce(transform.forward * 1000);
	
	}

	

		
}
