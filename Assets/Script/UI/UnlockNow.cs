using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockNow : MonoBehaviour {

    public GameObject messageBoxObject;
    public GameObject UnlockMessageBoxObject;
    public GameObject OpenStage;
    public int CurrentHolder;
    public Text CurrentTotalTxt;
    private pyCurrentLevelZoomIn pyCurrentLevelZoomInScript;

    void Awake()
    {
       
      
    }

    void Start() 
    {
        pyCurrentLevelZoomInScript = GameObject.Find("CurrenLevelZoomOut").GetComponent<pyCurrentLevelZoomIn>();
        CurrentHolder = 75 - PlayerPrefs.GetInt("TotalRescuePoints");
        if (PlayerPrefs.GetInt("OpenStagePyramid") == 1)
        {
            OpenStage.SetActive(false);
            pyCurrentLevelZoomInScript.Isactivate = true;


        }
    }
    
    public void _checkTotalPoints() 
    {
        if (PlayerPrefs.GetInt("TotalRescuePoints") >= 72)
        {
            UnlockMessageBoxObject.SetActive(true);
            pyCurrentLevelZoomInScript.Isactivate = true;
            PlayerPrefs.SetInt("OpenStagePyramid", 1);
        }
        else
        {
            CurrentTotalTxt.text = "" + CurrentHolder;
            messageBoxObject.SetActive(true);
     
        }
    }

    public void OpenStageMethod() 
    {
        OpenStage.SetActive(false);
    }

  
}
