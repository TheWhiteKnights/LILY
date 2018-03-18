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
	public bool speechbutton;
	void Start()
	{
		speech = false;
		speechbutton = false;
		text2speech = Instantiate(Resources.Load("text2speech")) as GameObject; 
		text = true;
		text2speech.GetComponent<text2speech> ().speech = "Welcome";
	}
	void createspeech()
	{
		speech2text = Instantiate (Resources.Load ("speech2text")) as GameObject;
		speech2text.GetComponent<speech2text> ().ResultsField = ui;
	}
	void Update()
	{	
		if (text) {
			if (text2speech.GetComponent<text2speech> ().ended) {
				Destroy (text2speech);
				speech = true;
				text = false;
			}
			return;
		}
		if(speech)
		{
			if (speechbutton) {
				createspeech ();
				speechbutton = false;
			}
			if (speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains ("how are you")) {
				Destroy (speech2text);
				text2speech = Instantiate (Resources.Load ("text2speech")) as GameObject;
				text = true;
				speech = false;
				text2speech.GetComponent<text2speech> ().speech = "I am Feeling good. Thanks";
			}
			else if (speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains ("what are you")) {
				Destroy (speech2text);
				text2speech = Instantiate (Resources.Load ("text2speech")) as GameObject;
				text = true;
				speech = false;
				text2speech.GetComponent<text2speech> ().speech = "Well, I'm not a person. I'm a virtual assistant.";
			}
			else if (speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains ("how old are you")) {
				Destroy (speech2text);
				text2speech = Instantiate (Resources.Load ("text2speech")) as GameObject;
				text = true;
				speech = false;
				text2speech.GetComponent<text2speech> ().speech = "I prefer not to answer with a number. I know I'm young";
			}
			else if (speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("you") && speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("annoying")) {
				Destroy (speech2text);
				text2speech = Instantiate (Resources.Load ("text2speech")) as GameObject;
				text = true;
				speech = false;
				text2speech.GetComponent<text2speech> ().speech = "I don't mean to. I'll ask my developers to make me less annoying.";
			}
			else if (speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("you") &&( speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("good")||speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("beautiful") ||speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("nice"))) {
				Destroy (speech2text);
				text2speech = Instantiate (Resources.Load ("text2speech")) as GameObject;
				text = true;
				speech = false;
				text2speech.GetComponent<text2speech> ().speech = "Why, thank you";
			}
			else if (speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("who") && speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("boss")||speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("is") ||speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("nice")){
				Destroy (speech2text);
				text2speech = Instantiate (Resources.Load ("text2speech")) as GameObject;
				text = true;
				speech = false;
				text2speech.GetComponent<text2speech> ().speech = "Why, thank you";
			}
			else if (speech2text.GetComponent<speech2text> ().speechtext.ToLower ().Contains("good bye")){
				Application.Quit ();
			}
			return;
		}
	}
}
