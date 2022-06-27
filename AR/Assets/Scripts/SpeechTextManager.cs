using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class SpeechTextManager : MonoBehaviour
{
    [SerializeField] private string language = "ru-RU";
    [SerializeField] private Text UiText;

    [Serializable]

    public struct VoiceCommand
    {
        public string Keyword;
        public UnityEvent Response;
    }

    public VoiceCommand[] voiceCommands;

    private Dictionary<string, UnityEvent> commands = new Dictionary<string, UnityEvent>();

    private void Awake()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
        foreach (var command in voiceCommands)
        {
            commands.Add(command.Keyword.ToLower(), command.Response);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TextToSpeech.instance.Setting(language, 1, 1);
        SpeechToText.instance.Setting(language);

        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;
#if UNITY_ANDROID
            SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
    }


    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }
    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }
    
    void OnFinalSpeechResult(string result)
    {
        UiText.text = result;
        if (result != null)
        {
            var response = commands[result.ToLower()];
            if (response != null)
            {
                response?.Invoke();
            }
        }
    }

     void OnPartialSpeechResult(string result)
    {
        UiText.text = result; 
    }

    public void StartSpeaking(string message)
    {
        TextToSpeech.instance.StartSpeak(message);
    }
    public void StopSpeaking()
    {
        TextToSpeech.instance.StopSpeak();
    }
    void OnSpeakStart()
    {
        Debug.Log("Talking Started...");
    }
    void OnSpeakStop()
    {
        Debug.Log("Talking Stopped");
    }
}
