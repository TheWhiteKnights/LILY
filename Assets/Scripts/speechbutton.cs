using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speechbutton : MonoBehaviour {

	public GameObject controller;
	public void click()
	{
		controller.GetComponent<controller> ().speechbutton = true;
	}
}
