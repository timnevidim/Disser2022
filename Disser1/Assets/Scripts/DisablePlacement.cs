using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlacement : MonoBehaviour
{



     public GameObject Interaction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 1)
        {
           Destroy(Interaction);
        }
    }



}
