using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cheatcode : MonoBehaviour {

    public void UnlockLevelAdd() 
    {
        PlayerPrefs.SetInt("UnlockLevels",25);
    }
    public void UnlockEndlessMethod(string levelName)
    {
        if (PlayerPrefs.GetInt("UnlockLevels") >= 25)
        {
            SceneManager.LoadScene(levelName);
        }
        
    }
}
