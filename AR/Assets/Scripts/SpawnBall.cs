using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {

	[SerializeField]
	GameObject ball;

	public GameObject ARCamera;
	private GameObject Assistant;
	public Transform BallPosition;
	public void Spawn()
	{
		Assistant = Instantiate (ball, new Vector3(0f, -0.5f, 0f), Quaternion.identity);
	}

	private void MoveObjToPos()
    {
        Assistant.transform.position = Vector3.Lerp(Assistant.transform.position, BallPosition.position, 1f * Time.deltaTime);
    }
	public float CheckDist()
    {
        float dist = Vector3.Distance(Assistant.transform.position, BallPosition.transform.position);
        return dist;
    }

	void Update()
    {
        // Проверка на дистанцию
        if (CheckDist() >= 0.1f)
        {
            MoveObjToPos();
        }
        // Поворот Ассистента в сторону пользователя
        Assistant.transform.LookAt(ARCamera.transform);
    }
}
