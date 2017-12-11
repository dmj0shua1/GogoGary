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
        CurrentHolder = 75 -PlayerPrefs.GetInt("TotalRescuePoints");
      
    }

    void Start() 
    {
        pyCurrentLevelZoomInScript = GameObject.Find("CurrenLevelZoomOut").GetComponent<pyCurrentLevelZoomIn>();
    }
    
    public void _checkTotalPoints() 
    {
        if (PlayerPrefs.GetInt("TotalRescuePoints") >= 72)
        {
            UnlockMessageBoxObject.SetActive(true);
            pyCurrentLevelZoomInScript.Isactivate = true;
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
