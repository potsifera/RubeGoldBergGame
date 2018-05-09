using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

	public PlatformSensorScript cheatSensor;



	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Throwable") && cheatSensor.playerIsInside)
		{
			gameObject.SetActive(false);
		}
	}
}
