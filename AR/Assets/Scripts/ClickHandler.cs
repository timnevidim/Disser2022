using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ClickHandler : MonoBehaviour
{



    public UnityEvent upEvent;
    public UnityEvent downEvent;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        Debug.Log("Down");
        downEvent?.Invoke();
    }

    void OnMouseUp()
    {
        Debug.Log("Up");
        downEvent?.Invoke();
    }

}
