using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartLevelPrefs : MonoBehaviour {

    public int PlaceTotalBuilding;
    private LevelValueHolder LevelValueHolderScript;
    private pyLevelValueHolder pyLevelValueHolderScript;
    public Text NumberOfPeopleText;
    void Start() 
    {
        if (!PlayerPrefs.HasKey("UnlockLevels")) PlayerPrefs.SetInt("UnlockLevels",1);
        if(!PlayerPrefs.HasKey("RescuePoints")) PlayerPrefs.SetInt("RescuePoints",75);
        if (!PlayerPrefs.HasKey("TotalRescuePoints")) PlayerPrefs.SetInt("TotalRescuePoints", 0);
        if (!PlayerPrefs.HasKey("pyTotalRescuePoints")) PlayerPrefs.SetInt("pyTotalRescuePoints", 0);
        if (!PlayerPrefs.HasKey("CurrentZoom")) PlayerPrefs.SetInt("CurrentZoom", 0);
        if (!PlayerPrefs.HasKey("CompleteLevelCounter")) PlayerPrefs.SetInt("CompleteLevelCounter", 0);

     
        for (int num = 1; num < PlaceTotalBuilding; num++)
        {
            if (!PlayerPrefs.HasKey("Building_L" + num.ToString())) PlayerPrefs.SetInt("Building_L" + num.ToString(), 0);
            LevelValueHolderScript = GameObject.Find("Building_L" + num.ToString()).GetComponent<LevelValueHolder>();
            LevelValueHolderScript.RescueHolderPlayerPref = PlayerPrefs.GetInt("Building_L" + num.ToString());
        }

        for (int num = 26; num < 51; num++)
        {
            if (!PlayerPrefs.HasKey("pyBuilding_L" + num.ToString())) PlayerPrefs.SetInt("pyBuilding_L" + num.ToString(), 0);
            pyLevelValueHolderScript = GameObject.Find("pyBuilding_L" + num.ToString()).GetComponent<pyLevelValueHolder>();
            pyLevelValueHolderScript.RescueHolderPlayerPref = PlayerPrefs.GetInt("pyBuilding_L" + num.ToString());
        }
        
    }
}
