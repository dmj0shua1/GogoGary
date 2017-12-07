using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeStatus : MonoBehaviour {
    [SerializeField]
    private LevelPass LevelPassScript;
    private LevelValueHolder LevelValueHolderScript;
    public string GoToScene;
    void Start() 
    {
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
    }
    public void PlusIntLevelStatus()
    {
        if (LevelPassScript.LevelStatusAmt == 25)
        {
            SceneManager.LoadScene(GoToScene);
        }
        else
        {
            LevelPassScript.CurrentButtonPassAmt = LevelPassScript.CurrentButtonPassAmt + 1;
            LevelPassScript.TargetLevel = LevelPassScript.ButtonNextLevel[LevelPassScript.CurrentButtonPassAmt];
            LevelValueHolderScript = LevelPassScript.TargetLevel.GetComponent<LevelValueHolder>();
            LevelPassScript.ObjectiveAmt = LevelValueHolderScript.ObjectiveValue;
            LevelPassScript.FloorAmt = LevelValueHolderScript.FloorValue;
            LevelPassScript.StartingAmt = LevelValueHolderScript.StartingValue;
            LevelPassScript.DebrisAmt = LevelValueHolderScript.DebrisValue;
            LevelPassScript.TimeAmt = LevelValueHolderScript.TimeValue;
            LevelPassScript.HalfObjectiveAmt = LevelValueHolderScript.HalfObjectiveValue;
            LevelPassScript.UnlockLevelAmt = LevelValueHolderScript.UnlockedValue;
            LevelPassScript.FireTriggerAmt = LevelValueHolderScript.FireTriggerValue;
            LevelPassScript.PowerupAmt = LevelValueHolderScript.PowerupValue;
            LevelPassScript.isActivateTipsAmt = LevelValueHolderScript.isActivateTipsValue;
            LevelPassScript.isShakeActivateAmt = LevelValueHolderScript.isShakeActivateValue;
            LevelPassScript.CameraColorAmt = LevelValueHolderScript.CameraColorValue;
            LevelPassScript.RescuePointAmt = LevelValueHolderScript.RescuePointValue;
            LevelPassScript.debriTipsAmt = LevelValueHolderScript.debriTipsValue;
            LevelPassScript.starTipsAmt = LevelValueHolderScript.starTipsValue;
            LevelPassScript.shakeTipsAmt = LevelValueHolderScript.shakeTipsValue;
            LevelPassScript.boltTipsAmt = LevelValueHolderScript.boltTipsValue;
            LevelPassScript.LevelStatusAmt = LevelPassScript.LevelStatusAmt + 1;
        }
    }

    public void RescuePointAmtChange() 
    { 
                if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
                {

                    LevelPassScript.RescueHolderPlayerPrefAmt = PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString());
                    LevelPassScript.RescuePointAmtCopy = LevelPassScript.RescueHolderPlayerPrefAmt;
                }
            
        //
           
     
    }

}
