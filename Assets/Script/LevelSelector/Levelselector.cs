﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levelselector : MonoBehaviour {

    public Button[] levelButtons;
    public GameObject MainHolderScript;
    EnergyManager egManagerScript;
    public GameObject NoteToUnlock;
    //public int levelReached;
    void Start() 
    {
        MainHolderScript = GameObject.Find("Holder");
        egManagerScript = GameObject.Find("Energy").GetComponent<EnergyManager>();
    }
    public void select(int levelname)
    {
        SceneManager.LoadScene(levelname);
        Destroy(MainHolderScript);
      
    }
    public void selectstring(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    public void GoToSceneEnergyReq(string levelname)
    {
        if (PlayerPrefs.GetInt("energyLeft") <= 0)
        {
            SceneManager.LoadScene(levelname);
            Destroy(MainHolderScript);
        }
        else
        {
            egManagerScript.decreaseEnergy();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }

    public void UnlockEndlessMethod(string levelName) 
    {
        if (PlayerPrefs.GetInt("UnlockLevels") >= 25)
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            NoteToUnlock.SetActive(true);
        }
    }

    public void closeNote() 
    {
        NoteToUnlock.SetActive(false);
    }


   
}
