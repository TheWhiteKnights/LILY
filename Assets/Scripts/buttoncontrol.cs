using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class buttoncontrol : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {
	public GameObject xcamera;

	void Update()
	{
		Input.simulateMouseWithTouches = true;
		if (!ispressed)
			return;
		xcamera.GetComponent<cameracontrol> ().onclick ();
		Debug.Log ("pressed btn");
	}
	bool ispressed=false;
	public void OnPointerDown(PointerEventData eventData)
	{
		ispressed = true;
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		ispressed = false;
	}
		
}





