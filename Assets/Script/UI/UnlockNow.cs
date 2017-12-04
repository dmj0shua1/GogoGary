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

    void Awake()
    {
        CurrentHolder = 75 -PlayerPrefs.GetInt("TotalRescuePoints");
      
    }
    
    public void _checkTotalPoints() 
    {
        if (PlayerPrefs.GetInt("TotalRescuePoints") >= 72)
        {
            UnlockMessageBoxObject.SetActive(true);
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
