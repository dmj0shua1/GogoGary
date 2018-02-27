using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartLevelPrefs : MonoBehaviour {

    public int PlaceTotalBuilding;
    private LevelValueHolder LevelValueHolderScript;
    private pyLevelValueHolder pyLevelValueHolderScript;
    private phLevelValueHolder phLevelValueHolderScript;
    private ieLevelValueHolder ieLevelValueHolderScript;
    public Text NumberOfPeopleText;
    void Start() 
    {
        if (!PlayerPrefs.HasKey("UnlockLevels")) PlayerPrefs.SetInt("UnlockLevels",1);
        if (!PlayerPrefs.HasKey("TotalRescuePoints")) PlayerPrefs.SetInt("TotalRescuePoints", 0);
        if (!PlayerPrefs.HasKey("pyTotalRescuePoints")) PlayerPrefs.SetInt("pyTotalRescuePoints", 0);
        if (!PlayerPrefs.HasKey("CurrentZoom")) PlayerPrefs.SetInt("CurrentZoom", 0);
        if (!PlayerPrefs.HasKey("CompleteLevelCounter")) PlayerPrefs.SetInt("CompleteLevelCounter", 0);
        if (!PlayerPrefs.HasKey("OpenStagePyramid")) PlayerPrefs.SetInt("OpenStagePyramid", 0);
        if (!PlayerPrefs.HasKey("OpenStagePreHistoric")) PlayerPrefs.SetInt("OpenStagePreHistoric", 0);
        if (!PlayerPrefs.HasKey("OpenStageIceAge")) PlayerPrefs.SetInt("OpenStageIceAge", 0);
        if (!PlayerPrefs.HasKey("isNotice")) PlayerPrefs.SetInt("isNotice", 0);
        if (!PlayerPrefs.HasKey("pyisNotice")) PlayerPrefs.SetInt("pyisNotice", 0);
        if (!PlayerPrefs.HasKey("LastLevelStagePickerSelect")) PlayerPrefs.SetInt("LastLevelStagePickerSelect", 0);
        if (!PlayerPrefs.HasKey("phTotalRescuePoints")) PlayerPrefs.SetInt("phTotalRescuePoints", 0);
        if (!PlayerPrefs.HasKey("phTotalRescuePoints")) PlayerPrefs.SetInt("ieTotalRescuePoints", 0);
        if (!PlayerPrefs.HasKey("OpenStagePreHistoric")) PlayerPrefs.SetInt("OpenStagePreHistoric", 0);
        if (!PlayerPrefs.HasKey("VibrateSettings")) PlayerPrefs.SetInt("VibrateSettings", 0);

        

     
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

        for (int num = 51; num < 76; num++)
        {
            if (!PlayerPrefs.HasKey("phBuilding_L" + num.ToString())) PlayerPrefs.SetInt("phBuilding_L" + num.ToString(), 0);
            phLevelValueHolderScript = GameObject.Find("phBuilding_L" + num.ToString()).GetComponent<phLevelValueHolder>();
            phLevelValueHolderScript.RescueHolderPlayerPref = PlayerPrefs.GetInt("phBuilding_L" + num.ToString());
        }
        for (int num = 76; num < 101; num++)
        {
            if (!PlayerPrefs.HasKey("ieBuilding_L" + num.ToString())) PlayerPrefs.SetInt("ieBuilding_L" + num.ToString(), 0);
            ieLevelValueHolderScript = GameObject.Find("ieBuilding_L" + num.ToString()).GetComponent<ieLevelValueHolder>();
            ieLevelValueHolderScript.RescueHolderPlayerPref = PlayerPrefs.GetInt("ieBuilding_L" + num.ToString());
        }
        
    }
}
