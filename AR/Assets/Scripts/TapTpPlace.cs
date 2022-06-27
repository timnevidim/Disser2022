using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Video;

[RequireComponent(typeof(ARRaycastManager))]
public class TapTpPlace : MonoBehaviour
{

    public GameObject PrefabToPlace;

    private GameObject spawnedObject;
    private GameObject screen;
    public VideoPlayer tvOnOff;
    public VideoClip[] videoClips;
    
    private int i=0;
    public bool isOn = true;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        return;

        if(_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(PrefabToPlace, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
            
        }
    }

    public void offTV()
    {
        screen = GameObject.FindGameObjectWithTag("Screen");
        screen.GetComponent<MeshRenderer>().enabled = false;
        tvOnOff = screen.GetComponent<VideoPlayer>();
        tvOnOff.Stop();
    }

    public void onTV()
    {
        screen = GameObject.FindGameObjectWithTag("Screen");
        screen.GetComponent<MeshRenderer>().enabled = true;
        tvOnOff = screen.GetComponent<VideoPlayer>();
        tvOnOff.Play();
    }

    public void SwitchClip()
    {
        //tvOnOff.Stop();
        tvOnOff.playOnAwake=true;
        screen = GameObject.FindGameObjectWithTag("Screen");
        tvOnOff.clip = videoClips[i++];
        
    }



}
