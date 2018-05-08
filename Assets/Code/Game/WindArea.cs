using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {

	public float strength;
	public Vector3 direction;
	private Rigidbody otherRB;
	

	private void OnTriggerEnter(Collider other)
	{
		otherRB = other.GetComponent<Rigidbody>();
		otherRB.AddForce(transform.up * 200);
	}

}
