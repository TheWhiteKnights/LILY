using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watsonui : MonoBehaviour {

	public GameObject watsoncomponent;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (watsoncomponent.activeInHierarchy) {
			gameObject.SetActive (true);
		}
	}
}
