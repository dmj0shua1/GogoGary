using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UnlockNow : MonoBehaviour {

    public GameObject messageBoxObject;
    public GameObject UnlockMessageBoxObject;
    public GameObject OpenStage;
    public int CurrentHolder;
    public Text CurrentTotalTxt;
    private pyCurrentLevelZoomIn pyCurrentLevelZoomInScript;
    //

    void Awake()
    {
        CurrentHolder = 75 - PlayerPrefs.GetInt("TotalRescuePoints");
      
    }

    void Start() 
    {
        pyCurrentLevelZoomInScript = GameObject.Find("CurrenLevelZoomOut").GetComponent<pyCurrentLevelZoomIn>();
     
        /*if (PlayerPrefs.GetInt("OpenStagePyramid") == 1)
        {
            OpenStage.SetActive(false);
            pyCurrentLevelZoomInScript.Isactivate = true;


        }*/
    }
    
    public void _checkTotalPoints() 
    {
        /*if (PlayerPrefs.GetInt("TotalRescuePoints") >= 72)
        {
            UnlockMessageBoxObject.SetActive(true);
            pyCurrentLevelZoomInScript.Isactivate = true;
            PlayerPrefs.SetInt("OpenStagePyramid", 1);
        }
        else
        {
            CurrentTotalTxt.text = "" + CurrentHolder;
            messageBoxObject.SetActive(true);
     
        }*/
    }

    public void OpenStageMethod() 
    {
        OpenStage.SetActive(false);
    }
    public void _CheckUnlockStage(string levelname)
    {
            if (PlayerPrefs.GetInt("TotalRescuePoints") >= 72)
            {
                SceneManager.LoadScene(levelname);

            }
            else
            {
                CurrentTotalTxt.text = "" + CurrentHolder;
                messageBoxObject.SetActive(true);
            }  
        
       
       
    }
  
}
