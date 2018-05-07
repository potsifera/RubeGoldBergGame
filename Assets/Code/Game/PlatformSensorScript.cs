using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSensorScript : MonoBehaviour {

	public Material activeBallMaterial;
	public Material inactiveBallMaterial;
	private Renderer ballRenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Throwable"))
		{
			Debug.Log("ball left the AAAREA");
			ballRenderer = other.GetComponent<Renderer>();
			ballRenderer.material = activeBallMaterial;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Throwable"))
		{
			Debug.Log("ball inside the AAAREA");
			ballRenderer = other.GetComponent<Renderer>();
			ballRenderer.material = inactiveBallMaterial;
		}
	}
}
