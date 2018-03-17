using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour {
	GameObject text2speech;
	public Text ui;
	GameObject speech2text;
	bool text;
	bool speech;
	void Start()
	{
		speech = false;
		text2speech = Instantiate(Resources.Load("text2speech")) as GameObject; 
		text = true;
		text2speech.GetComponent<text2speech> ().speech = "hello ebin. how are you feeling today";
	}
	void Update()
	{
		if (text) {
			if (text2speech.GetComponent<text2speech> ().ended) {
				Destroy (text2speech);
				speech2text = Instantiate (Resources.Load ("speech2text")) as GameObject;
				speech2text.GetComponent<speech2text> ().ResultsField = ui;
				speech = true;
				text = false;
			}
			return;
		}
		if(speech)
		{
			if (speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains ("how are you")) {
				Destroy (speech2text);
				text2speech = Instantiate (Resources.Load ("text2speech")) as GameObject;
				text = true;
				speech = false;
				text2speech.GetComponent<text2speech> ().speech = "I am Feeling good. Thanks";
			}
			return;
		}
	}
}
