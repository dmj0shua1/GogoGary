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
       if (sceneName == "Stage2")
       {
           RescueNumCounterText.text = "" + (PlayerPrefs.GetInt("pyTotalRescuePoints"));
       }
   
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
