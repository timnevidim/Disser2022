using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "ru-RU";
    [SerializeField]
    Text uiText;
    void Start()
    {
        Setup(LANG_CODE);

#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;

        CheckPermission();   
    }
    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }

    #region Text to Speech
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
    #endregion

    #region Speech to Text
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
        uiText.text = result;
    }
    void OnPartialSpeechResult(string result)
    {
        uiText.text = result;
    }
    #endregion

    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }
}
