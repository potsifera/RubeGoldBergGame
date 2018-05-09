using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSensorScript : MonoBehaviour {

	public Material activeBallMaterial;
	public Material inactiveBallMaterial;
	private Renderer ballRenderer;
	public bool ballIsOutside = false;
	public bool playerIsInside = true;



	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Throwable"))
		{
			Debug.Log("ball left the AAAREA");
			ballIsOutside = true;
			ballRenderer = other.GetComponent<Renderer>();
			ballRenderer.material = activeBallMaterial;
		}

		if (other.gameObject.CompareTag("Controller"))
		{
			Debug.Log("player OUTSIDE AREA");
			playerIsInside = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Throwable"))
		{
			Debug.Log("ball inside the AAAREA");
			ballIsOutside = false;
			ballRenderer = other.GetComponent<Renderer>();
			ballRenderer.material = inactiveBallMaterial;
		}

		if (other.gameObject.CompareTag("Controller"))
		{
			Debug.Log("player INSIDE AREA");
			playerIsInside = true;
		}
	}
}
