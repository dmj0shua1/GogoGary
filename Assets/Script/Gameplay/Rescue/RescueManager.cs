using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueManager : MonoBehaviour {

    public int RescuePointCount;
    public int MaxRescuePoint;
    public int TotalRescuePoints;

    public bool RescuePointIncreasing;
    public Text RescuePointText;
    [SerializeField]
    private LevelPass LevelPassScript;

    void Start() 
    {
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        TotalRescuePoints = PlayerPrefs.GetInt("TotalRescuePoints");
    }

    void Update() 
    {
        RescuePointText.text = "" + (RescuePointCount);
        
    }
    public void AddRescuePoint(int RescuePointToAdd) 
    {
        RescuePointCount += RescuePointToAdd;
        LevelPassScript.RescueHolderPlayerPrefAmt = RescuePointCount;
        /*if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
        {
            PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) + 1);
        }*/
        /*else if (PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) == RescuePointCount)
        {
            PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), LevelPassScript.RescuePointAmtCopy);
        }*/
       
        //LevelPassScript.RescuePointAmt = LevelPassScript.RescuePointAmt - RescuePointCount;
        /*if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
        {
            PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) - 1);
        }*/
       
    }

}
