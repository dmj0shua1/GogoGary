using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stageunlockstate : MonoBehaviour {
    
    public Text TextHolder;
    public string LockTextState;
    public string UnlockTextState;
    public string _StageName;
    public Image StageImage;
    //
    public int CurrentHolder;
    public Text CurrentTotalTxt;
    public GameObject messageBoxObject;
  
    void Start() 
    {
        if (_StageName == "EGYPT")
	    {
		  if (PlayerPrefs.GetInt("TotalRescuePoints") >= 72)
          {
              TextHolder.GetComponent<Text>().text = UnlockTextState;
          }
          else
          {
              StageImage.GetComponent<Image>().color = Color.black;
              TextHolder.GetComponent<Text>().text = LockTextState;
          }
	    }
        if (_StageName == "PREHISTORIC")
        {
            if (PlayerPrefs.GetInt("pyTotalRescuePoints") >= 72)
            {
                TextHolder.GetComponent<Text>().text = UnlockTextState;
            }
            else
            {
                StageImage.GetComponent<Image>().color = Color.black;
                TextHolder.GetComponent<Text>().text = LockTextState;
            }
        }
        if (_StageName == "ICEAGE")
        {
            if (PlayerPrefs.GetInt("ieTotalRescuePoints") >= 72)
            {
                TextHolder.GetComponent<Text>().text = UnlockTextState;
            }
            else
            {
                StageImage.GetComponent<Image>().color = Color.black;
                TextHolder.GetComponent<Text>().text = LockTextState;
            }
         
        }
        if (_StageName == "FUTURE")
        {
            StageImage.GetComponent<Image>().color = Color.black;
            TextHolder.GetComponent<Text>().text = LockTextState;
        }
       
    }
    public void _CheckUnlockStage(string levelname)
    {
        if (_StageName == "EGYPT")
        {
            if (PlayerPrefs.GetInt("TotalRescuePoints") >= 72)
            {
                SceneManager.LoadScene(levelname);
                PlayerPrefs.SetInt("OpenStagePyramid", 1);

            }
            else
            {
                CurrentTotalTxt.text = "" + CurrentHolder;
                messageBoxObject.SetActive(true);
            }
        }

        if (_StageName == "PREHISTORIC")
        {
            if (PlayerPrefs.GetInt("pyTotalRescuePoints") >= 72)
            {
                SceneManager.LoadScene(levelname);
                PlayerPrefs.SetInt("OpenStagePreHistoric", 1);

            }
            else
            {
                CurrentTotalTxt.text = "" + CurrentHolder;
                messageBoxObject.SetActive(true);
            }
        }
        if (_StageName == "ICEAGE")
        {
            if (PlayerPrefs.GetInt("phTotalRescuePoints") >= 72)
            {
                SceneManager.LoadScene(levelname);
                PlayerPrefs.SetInt("OpenStageIceAge", 1);

            }
            else
            {
                CurrentTotalTxt.text = "" + CurrentHolder;
                messageBoxObject.SetActive(true);
            }
        }

    }
}
