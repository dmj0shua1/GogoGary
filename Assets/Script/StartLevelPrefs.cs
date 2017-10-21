using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartLevelPrefs : MonoBehaviour {

    public int PlaceTotalBuilding;
    private LevelValueHolder LevelValueHolderScript;
    public Text NumberOfPeopleText;
   
    void Start() 
    {
        if (!PlayerPrefs.HasKey("UnlockLevels")) PlayerPrefs.SetInt("UnlockLevels",1);
        if(!PlayerPrefs.HasKey("RescuePoints")) PlayerPrefs.SetInt("RescuePoints",75);
        if (!PlayerPrefs.HasKey("TotalRescuePoints")) PlayerPrefs.SetInt("TotalRescuePoints", 0);
      
        for (int num = 1; num < PlaceTotalBuilding; num++)
        {
            if (!PlayerPrefs.HasKey("Building_L" + num.ToString())) PlayerPrefs.SetInt("Building_L" + num.ToString(), 0);
            LevelValueHolderScript = GameObject.Find("Building_L" + num.ToString()).GetComponent<LevelValueHolder>();
            LevelValueHolderScript.RescueHolderPlayerPref = PlayerPrefs.GetInt("Building_L" + num.ToString());

          
            /*if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 0)
            {
                LevelValueHolderScript.star1.SetActive(false);
                LevelValueHolderScript.star2.SetActive(false);
                LevelValueHolderScript.star3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 1)
            {
                LevelValueHolderScript.star1.SetActive(true);
                LevelValueHolderScript.star2.SetActive(false);
                LevelValueHolderScript.star3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 2)
            {
                LevelValueHolderScript.star1.SetActive(true);
                LevelValueHolderScript.star2.SetActive(true);
                LevelValueHolderScript.star3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 3)
            {
                LevelValueHolderScript.star1.SetActive(true);
                LevelValueHolderScript.star2.SetActive(true);
                LevelValueHolderScript.star3.SetActive(true);
            }*/
        }
        
    }
}
