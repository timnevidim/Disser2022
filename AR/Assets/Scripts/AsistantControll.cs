using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AsistantControll : MonoBehaviour
{
    [Header("Объект ARCamera")]
    public GameObject ARCamera;
    [Header("Префаб Ассистента")]
    public GameObject AssistantPrefab;
    private GameObject Assistant;
    [Header("Позиция Ассистента")]
    public Transform AssistantPosition;
    public void CreateJarvis()
    {
        Assistant = Instantiate(AssistantPrefab, ARCamera.transform.position + new Vector3(5f, 10f, 5f), ARCamera.transform.rotation);
    }
    void Update()
    {
        if (CheckDist() >= 0.1f)
        {
            MoveObjToPos();
        }
        Assistant.transform.LookAt(ARCamera.transform);
        Assistant.transform.Rotate(0, 190f, 0);
    }

    public float CheckDist()
    {
        float dist = Vector3.Distance(Assistant.transform.position, AssistantPosition.transform.position);
        return dist;
    }

    private void MoveObjToPos()
    {
        Assistant.transform.position = Vector3.Lerp(Assistant.transform.position, AssistantPosition.position, 1f * Time.deltaTime);
    }

    public void DestroyJarvis()
    {
        Destroy(Assistant, 3);
    }

    public IEnumerator CoroutineSample5s()
    {
        yield return new WaitForSeconds(5);
    }
}
