﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadNextLevel : MonoBehaviour {

	public List<GameObject> starPrefabs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Throwable"))
		{
			//check stars 
			if (CheckStars())
			{
				//change level
				Debug.Log("chaning level");
			}
		}
	}

	bool CheckStars()
	{
		foreach (GameObject star in starPrefabs)
		{
			if (star.activeInHierarchy)
			{
				return false;
			}
		}
		return true;
	}



}
