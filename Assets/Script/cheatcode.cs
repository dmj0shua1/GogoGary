using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cheatcode : MonoBehaviour {

    public void UnlockLevelAdd() 
    {
        PlayerPrefs.SetInt("UnlockLevels",101);
        PlayerPrefs.SetInt("TotalRescuePoints", 75);
        PlayerPrefs.SetInt("pyTotalRescuePoints", 75);
        PlayerPrefs.SetInt("phTotalRescuePoints", 75);
        PlayerPrefs.SetInt("ieTotalRescuePoints", 75);

        for (int num = 1; num < 26; num++)
        {
            PlayerPrefs.SetInt("Building_L" + num,3);
        }
        for (int num = 26; num < 51; num++)
        {
            PlayerPrefs.SetInt("pyBuilding_L" + num, 3);
        }
        for (int num = 51; num < 76; num++)
        {
            PlayerPrefs.SetInt("phBuilding_L" + num, 3);
        }

        for (int num = 76; num < 101; num++)
        {
            PlayerPrefs.SetInt("ieBuilding_L" + num, 3);
        }
    }
    public void UnlockLevelEn()
    {
        PlayerPrefs.SetInt("energyLeft", 5);

    }
    public void TotalRescueAdd()
    {
        PlayerPrefs.SetInt("TotalRescuePoints", 75);
    }
    public void UnlockEndlessMethod(string levelName)
    {
        if (PlayerPrefs.GetInt("UnlockLevels") >= 25)
        {
            SceneManager.LoadScene(levelName);
        }
        
    }
}
