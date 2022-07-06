using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;

public class Clicker : MonoBehaviour
{

    bool isSessionQualityOK;
    public GameObject scriptPlace;
    

    private void Start()
    {
        ARSession.stateChanged += HandleStateChanged;
        _scriptPlace = scriptPlace.GetComponent<ARTapToPlaceObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSessionQualityOK)
        {
            SpawnCubbeWithClickTriggerGesture();
        }
    }

    private void HandleStateChanged(ARSessionStateChangedEventArgs stateEventArguments)
    {
        isSessionQualityOK = stateEventArguments.state == ARSessionState.SessionTracking;
    }

    public GameObject itemPrefab;
   
    private ARTapToPlaceObject _scriptPlace;
    //ARTapToPlaceObject placementPose;

    private void SpawnCubbeWithClickTriggerGesture()
    {
        HandInfo handInformation = ManomotionManager.Instance.Hand_infos[0].hand_info;
        GestureInfo gestureInformation = handInformation.gesture_info;
        ManoGestureTrigger currentDetectedTriggerGesture = gestureInformation.mano_gesture_trigger;

        if (currentDetectedTriggerGesture == ManoGestureTrigger.CLICK)
        {
            
            //PlaceObject.PlaceObject();
            _scriptPlace.PlaceObject();
            //GameObject newItem = Instantiate(itemPrefab);
            //Vector3 positionToMove = Camera.main.transform.position + (Camera.main.transform.forward * 2);
            Handheld.Vibrate();
        }
    }







}
