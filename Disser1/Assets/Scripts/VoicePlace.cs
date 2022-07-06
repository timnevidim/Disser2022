using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoicePlace : MonoBehaviour
{


    public GameObject scriptPlace;
    private ARTapToPlaceObject _scriptPlace;
    public GameObject recognaised;
    Text _recognaised;
    private bool work = false;

    // Start is called before the first frame update
    void Start()
    {
        _scriptPlace = scriptPlace.GetComponent<ARTapToPlaceObject>();
        //_recognised = recognaised.GetComponent<Text>().text;
        _recognaised = recognaised.GetComponentInChildren(typeof(Text)) as Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (_recognaised.text == "мебель" && work == false)
        {
            voiceplace();
            work = true;
        }
    }

    public void voiceplace()
    {
        _scriptPlace.PlaceObject();
        Handheld.Vibrate();
    }
}
