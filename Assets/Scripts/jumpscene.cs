﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpscene : MonoBehaviour {
	[SerializeField]
	public string nxt;

	public void onclick()
	{
		SceneManager.LoadScene (nxt);
	}
}
