using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour {
	public float distance;
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		transform.position = new Vector3 (-2056f, 62.46f, 1216.4f);
	}
	public void onclick()
	{
		transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
