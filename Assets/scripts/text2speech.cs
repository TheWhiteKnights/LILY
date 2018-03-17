/**
* Copyright 2015 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using UnityEngine;
using IBM.Watson.DeveloperCloud.Services.TextToSpeech.v1;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Utilities;
using System.Collections;
using System.Collections.Generic;
using IBM.Watson.DeveloperCloud.Connection;

public class text2speech : MonoBehaviour
{
	private string _username = "12c4a00d-5a5c-40f3-a458-81c8d0aaf5e5";
	private string _password = "uaGUnCNZmlNA";
	private string _url = "https://stream.watsonplatform.net/text-to-speech/api";
	public string speech;
	public bool ended;
    TextToSpeech _textToSpeech;
	string _testString = "<speak version=\"1.0\"><prosody pitch=\"150Hz\">";
	string _foot = "</prosody></speak>";

    string _createdCustomizationId;
    CustomVoiceUpdate _customVoiceUpdate;
    string _customizationName = "unity-example-customization";
    string _customizationLanguage = "en-US";
    string _customizationDescription = "A text to speech voice customization created within Unity.";
    string _testWord = "Watson";

    private bool _synthesizeTested = false;
    private bool _getVoicesTested = false;
    private bool _getVoiceTested = false;
    private bool _getPronuciationTested = false;
    private bool _getCustomizationsTested = false;
    private bool _createCustomizationTested = false;
    private bool _deleteCustomizationTested = false;
    private bool _getCustomizationTested = false;
    private bool _updateCustomizationTested = false;
    private bool _getCustomizationWordsTested = false;
    private bool _addCustomizationWordsTested = false;
    private bool _deleteCustomizationWordTested = false;
    private bool _getCustomizationWordTested = false;

    public void Start()
    {
		ended = false;
        LogSystem.InstallDefaultReactors();
       //  Create credential and instantiate service
        Credentials credentials = new Credentials(_username, _password, _url);

        _textToSpeech = new TextToSpeech(credentials);

        Runnable.Run(Examples());
    }
		
    private IEnumerator Examples()
    {
        //  Synthesize
        Log.Debug("ExampleTextToSpeech.Examples()", "Attempting synthesize.");
		_textToSpeech.Voice = VoiceType.en_US_Allison;
        _textToSpeech.ToSpeech(HandleToSpeechCallback, OnFail, _testString + speech + _foot, true);
        while (!_synthesizeTested)
            yield return null;

        //	Get Voices
        Log.Debug("ExampleTextToSpeech.Examples()", "Attempting to get voices.");
        _textToSpeech.GetVoices(OnGetVoices, OnFail);
        while (!_getVoicesTested)
            yield return null;

        //	Get Voice
		Log.Debug("ExampleTextToSpeech.Examples()", "Attempting to get voice {0}.", VoiceType.en_US_Allison);
		_textToSpeech.GetVoice(OnGetVoice, OnFail, VoiceType.en_US_Allison);
        while (!_getVoiceTested)
            yield return null;

        //	Get Pronunciation
        Log.Debug("ExampleTextToSpeech.Examples()", "Attempting to get pronunciation of {0}", _testWord);
		_textToSpeech.GetPronunciation(OnGetPronunciation, OnFail, _testWord, VoiceType.en_US_Allison);
        while (!_getPronuciationTested)
            yield return null;

       
    }

    void HandleToSpeechCallback(AudioClip clip, Dictionary<string, object> customData = null)
	{
		PlayClip (clip);
	}
	IEnumerator wait(float time)
	{
		yield return new WaitForSeconds(time);
	}

    public void PlayClip(AudioClip clip)
    {
        if (Application.isPlaying && clip != null)
        {
            GameObject audioObject = new GameObject("AudioObject");
            AudioSource source = audioObject.AddComponent<AudioSource>();
            source.spatialBlend = 0.0f;
            source.loop = false;
            source.clip = clip;
            source.Play();

            Destroy(audioObject, clip.length);

            _synthesizeTested = true;
			wait (clip.length);
			ended = true;
        }
    }

    private void OnGetVoices(Voices voices, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnGetVoices()", "Text to Speech - Get voices response: {0}", customData["json"].ToString());
        _getVoicesTested = true;
    }

    private void OnGetVoice(Voice voice, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnGetVoice()", "Text to Speech - Get voice  response: {0}", customData["json"].ToString());
        _getVoiceTested = true;
    }

    private void OnGetPronunciation(Pronunciation pronunciation, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnGetPronunciation()", "Text to Speech - Get pronunciation response: {0}", customData["json"].ToString());
        _getPronuciationTested = true;
    }

    private void OnGetCustomizations(Customizations customizations, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnGetCustomizations()", "Text to Speech - Get customizations response: {0}", customData["json"].ToString());
        _getCustomizationsTested = true;
    }

    private void OnCreateCustomization(CustomizationID customizationID, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnCreateCustomization()", "Text to Speech - Create customization response: {0}", customData["json"].ToString());
        _createdCustomizationId = customizationID.customization_id;
        _createCustomizationTested = true;
    }

    private void OnDeleteCustomization(bool success, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnDeleteCustomization()", "Text to Speech - Delete customization response: {0}", customData["json"].ToString());
        _createdCustomizationId = null;
        _deleteCustomizationTested = true;
    }

    private void OnGetCustomization(Customization customization, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnGetCustomization()", "Text to Speech - Get customization response: {0}", customData["json"].ToString());
        _getCustomizationTested = true;
    }

    private void OnUpdateCustomization(bool success, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnUpdateCustomization()", "Text to Speech - Update customization response: {0}", customData["json"].ToString());
        _updateCustomizationTested = true;
    }

    private void OnGetCustomizationWords(Words words, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnGetCustomizationWords()", "Text to Speech - Get customization words response: {0}", customData["json"].ToString());
        _getCustomizationWordsTested = true;
    }

    private void OnAddCustomizationWords(bool success, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnAddCustomizationWords()", "Text to Speech - Add customization words response: {0}", customData["json"].ToString());
        _addCustomizationWordsTested = true;
    }

    private void OnDeleteCustomizationWord(bool success, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnDeleteCustomizationWord()", "Text to Speech - Delete customization word response: {0}", customData["json"].ToString());
        _deleteCustomizationWordTested = true;
    }

    private void OnGetCustomizationWord(Translation translation, Dictionary<string, object> customData = null)
    {
        Log.Debug("ExampleTextToSpeech.OnGetCustomizationWord()", "Text to Speech - Get customization word response: {0}", customData["json"].ToString());
        _getCustomizationWordTested = true;
    }

    private void OnFail(RESTConnector.Error error, Dictionary<string, object> customData)
    {
        Log.Error("ExampleTextToSpeech.OnFail()", "Error received: {0}", error.ToString());
    }
}
