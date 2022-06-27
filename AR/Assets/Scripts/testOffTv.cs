using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class testOffTv : MonoBehaviour
{



    public GameObject screen;
    public VideoPlayer tvOnOff;
    public bool isOn = true;



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




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
}
