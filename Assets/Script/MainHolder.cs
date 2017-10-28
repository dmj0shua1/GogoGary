using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHolder : MonoBehaviour {

    [SerializeField]
    private LevelPass LevelPassScript;
   // private LevelValueHolder LevelValueHolderScript;
    public int ObjectivePass, FloorPass, StartingPass, DebrisPass, TimePass, HalfObjectivePass, UnlockedLevels,FireTriggerPass,PowerupPass,ButtonPass,LevelStatusPass,RescuePointPass,RescueHolderPrefPass;
    public bool isActivateTipsPass,isShakeActivatePass;
    public Color CameraColorPass;
    public bool debriTipsPass, starTipsPass, boltTipsPass, shakeTipsPass;
    void Start() 
    {
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
       /*if (UnlockedLevels <=PlayerPrefs.GetInt("UnlockLevels"))
        {
            gameObject.GetComponent<Button>().interactable = true;
        }*/
        
    }
    public void Checkbutton() 
    {
        if (UnlockedLevels <= PlayerPrefs.GetInt("UnlockLevels"))
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void pass()
    {
        LevelPassScript.ObjectiveAmt = ObjectivePass;
        LevelPassScript.FloorAmt = FloorPass;
        LevelPassScript.StartingAmt = StartingPass;
        LevelPassScript.DebrisAmt = DebrisPass;
        LevelPassScript.TimeAmt = TimePass;
        LevelPassScript.HalfObjectiveAmt = HalfObjectivePass;
        LevelPassScript.UnlockLevelAmt = UnlockedLevels;
        LevelPassScript.FireTriggerAmt = FireTriggerPass;
        LevelPassScript.PowerupAmt = PowerupPass;
        LevelPassScript.isActivateTipsAmt = isActivateTipsPass;
        LevelPassScript.isShakeActivateAmt = isShakeActivatePass;
        LevelPassScript.CurrentButtonPassAmt = ButtonPass;
        LevelPassScript.LevelStatusAmt = LevelStatusPass;
        LevelPassScript.CameraColorAmt = CameraColorPass;
        LevelPassScript.RescuePointAmt = RescuePointPass;
        LevelPassScript.RescueHolderPlayerPrefAmt = RescueHolderPrefPass;
        LevelPassScript.RescuePointAmtCopy = RescueHolderPrefPass;
        LevelPassScript.debriTipsAmt = debriTipsPass;
        LevelPassScript.starTipsAmt = starTipsPass;
        LevelPassScript.shakeTipsAmt = shakeTipsPass;
        LevelPassScript.boltTipsAmt = boltTipsPass;
    }
    public void RescuePointZero() 
    {
        /*if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
        {

            if (PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) <= LevelPassScript.RescuePointAmt)
            {
                PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), 0);
            }
          
            else if (PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) == RescuePointPass)
            {
                LevelPassScript.RescuePointAmt = 0;
            }
        }*/
    }

    /*public void GetValueLevels() 
    {
        ObjectivePass = LevelValueHolderScript.ObjectiveValue;
        FloorPass = LevelValueHolderScript.FloorValue;
        StartingPass = LevelValueHolderScript.StartingValue;
        DebrisPass = LevelValueHolderScript.DebrisValue;
        TimePass = LevelValueHolderScript.TimeValue;
        HalfObjectivePass = LevelValueHolderScript.HalfObjectiveValue;
        UnlockedLevels = LevelValueHolderScript.UnlockedValue;
        FireTriggerPass = LevelValueHolderScript.FireTriggerValue;
        PowerupPass = LevelValueHolderScript.PowerupValue;
    }*/
 
}
