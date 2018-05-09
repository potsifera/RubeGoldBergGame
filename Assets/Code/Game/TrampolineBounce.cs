using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBounce : MonoBehaviour {

	
	private Rigidbody otherRB;

	

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("something colided with trampoline");
		otherRB = other.GetComponent<Rigidbody>();
		otherRB.AddForce(transform.forward * 250);
	
	}

	

		
}
