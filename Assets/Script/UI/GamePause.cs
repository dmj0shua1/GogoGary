using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour {
    public bool isPause;
    public GameObject panelPause;
    public GameObject countDownObject;
    private testingcamerashake cameraShakeScript;
    void Start() 
    {
        cameraShakeScript = GameObject.Find("camerashaketest").GetComponent<testingcamerashake>();
    }

    public void pause() 
    {
        isPause = false;
        countDownObject.SetActive(false);
        cameraShakeScript.shakeDuration = 0;
    }

    public void Resume()
    {
        StartCoroutine(ResumeCountDown());
        countDownObject.SetActive(true);
    }
    IEnumerator ResumeCountDown()
    {
        //yield return new WaitForSeconds(1);
        yield return new WaitForSecondsRealtime(2);
        isPause = true;
        panelPause.SetActive(false);
       

        //Time.timeScale = 1;
    }

    void Update() 
    {
        if (isPause == true)
        {
            Time.timeScale = 1f;
        }
        else if (isPause == false)
        {
            Time.timeScale = 0f;
        }
    }
}
