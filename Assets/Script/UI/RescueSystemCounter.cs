using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RescueSystemCounter : MonoBehaviour {
    public Text RescueNumCounterText;
    void Awake() 
    {
       Scene currentScene = SceneManager.GetActiveScene();
       string sceneName = currentScene.name;
       if (sceneName == "Stage1")
       {
           RescueNumCounterText.text = "" + (PlayerPrefs.GetInt("TotalRescuePoints"));
       }
       else if (sceneName == "Stage2")
       {
           RescueNumCounterText.text = "" + (PlayerPrefs.GetInt("pyTotalRescuePoints"));
       }
       else if (sceneName == "Stage3")
       {
           RescueNumCounterText.text = "" + (PlayerPrefs.GetInt("phTotalRescuePoints"));
       }
       else if (sceneName == "Stage4")
       {
           RescueNumCounterText.text = "" + (PlayerPrefs.GetInt("ieTotalRescuePoints"));
       }
   
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
