using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ieGoToLevels : MonoBehaviour {
    [SerializeField]
    private LevelPass LevelPassScript;
    public GameObject MainHolderScript;
    private RescueManager RescueManagerScript;
    void Start() 
    {
        MainHolderScript = GameObject.Find("Holder");
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        RescueManagerScript = GameObject.Find("RescueManager").GetComponent<RescueManager>();
    }

    public void select(string SceneName)
    {
        Time.timeScale = 1f;
        Destroy(MainHolderScript);
        SceneManager.LoadScene(SceneName);
       

    }

    public void ChangerescueCopy() 
    {
        /*if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
        {
            PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), LevelPassScript.RescuePointAmtCopy);
        }*/
    }
    public void ChangezeroRescuePoint() 
    {
        if (PlayerPrefs.HasKey("ieBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString()))
        {
            LevelPassScript.RescueHolderPlayerPrefAmt = LevelPassScript.RescuePointAmtCopy; 
        }
    }
    public void LevelUnlockCheckMethod() 
    {
        if (RescueManagerScript.RescuePointCount > 1)
        {
            if (/*UnlockNow &&*/ PlayerPrefs.GetInt("UnlockLevels") == LevelPassScript.UnlockLevelAmt)
            {
                PlayerPrefs.SetInt("UnlockLevels", PlayerPrefs.GetInt("UnlockLevels") + 1);

                //UnlockNow = false;

            }

            /*else
            {
                UnlockNow = false;
            }*/
        }
    }
    public void CurrentZoomOn() 
    {
        PlayerPrefs.SetInt("CurrentZoom", 1);
    }

    public void RescueCopyMethod()
    {
        if (PlayerPrefs.HasKey("ieBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString()))
        {

            LevelPassScript.RescueHolderPlayerPrefAmt = PlayerPrefs.GetInt("ieBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString());
            LevelPassScript.RescuePointAmtCopy = LevelPassScript.RescueHolderPlayerPrefAmt;
        }
    }
}
