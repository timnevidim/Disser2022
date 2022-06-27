using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{


 
    private void Start()
    {
        
    }
    
    /*public void FindTV()
    {
        HeroObject = this.transform.Find("Assistant(Clone)").GetComponent<GameObject>();
        Debug.Log(HeroObject);
        HeroObject.SetActive(false);
    }
*/

    void Update()
    {
        
    }


    public void LoadSceneVoice()
    {
        SceneManager.LoadScene("Voice");
    }

    public void LoadSceneUI()
    {
        SceneManager.LoadScene("UI");
    }

    public void LoadSceneFace()
    {
        SceneManager.LoadScene("Face_Hands");
    }

    public void LoadSceneMenu()
    {
        SceneManager.LoadScene(0);
    }

}
