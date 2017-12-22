using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levelselector : MonoBehaviour {

    public Button[] levelButtons;
    public GameObject MainHolderScript;
    EnergyManager egManagerScript;
    public GameObject NoteToUnlock;
    [SerializeField]
    private GameObject watchAds;
    //public int levelReached;
    void Start() 
    {
        MainHolderScript = GameObject.Find("Holder");
        egManagerScript = GameObject.Find("Energy").GetComponent<EnergyManager>();
        if (!PlayerPrefs.HasKey("watchAdsNote")) PlayerPrefs.SetInt("watchAdsNote", 0);
        if (PlayerPrefs.GetInt("watchAdsNote") == 1) watchAds.SetActive(true);

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
            if (PlayerPrefs.GetInt("watchAdsNote") == 0) PlayerPrefs.SetInt("watchAdsNote", 1);
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

    public void disableWatchAdsNote()
    {
        PlayerPrefs.SetInt("watchAdsNote", 2);
        watchAds.SetActive(false);
    }


   
}
