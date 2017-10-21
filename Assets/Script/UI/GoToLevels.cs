using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevels : MonoBehaviour {
    [SerializeField]
    private LevelPass LevelPassScript;
    public GameObject MainHolderScript;
    void Start() 
    {
        MainHolderScript = GameObject.Find("Holder");
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
    }

    public void select(int SceneName)
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
        if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
        {
            LevelPassScript.RescueHolderPlayerPrefAmt = LevelPassScript.RescuePointAmtCopy; 
            /*if (PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) >= LevelPassScript.RescuePointAmt)
            {
                PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), 0);
            }
            else if (PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) == LevelPassScript.RescuePointAmt)
            {
                LevelPassScript.RescuePointAmt = 0;
            }*/
            /*if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
            {

                if (PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) <= LevelPassScript.RescuePointAmt)
                {
                    PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), 0);
                }

                else if (PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) == LevelPassScript.RescuePointAmt)
                {
                    LevelPassScript.RescuePointAmt = 0;
                }
            }*/
           
        }
    }
}
