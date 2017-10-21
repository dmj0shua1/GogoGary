using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPass : MonoBehaviour {

    public GameObject Platform, FloorCounter, TimeStart,Debris,Powerup;
    public int ObjectiveAmt, FloorAmt, StartingAmt, DebrisAmt, TimeAmt, HalfObjectiveAmt, UnlockLevelAmt, FireTriggerAmt, PowerupAmt, LevelNumberAmt,LevelStatusAmt,RescuePointAmt,RescueHolderPlayerPrefAmt,RescuePointAmtCopy;
    public bool isActivateTipsAmt,isShakeActivateAmt;
    public GameObject[] ButtonNextLevel;
    public int CurrentButtonPassAmt;
    private LevelValueHolder LevelValueHolderScript;
    public GameObject TargetLevel;
    public Color CameraColorAmt;
    void Start()
    {
     
    }
    public void TargetMethod()
    { 
        TargetLevel = ButtonNextLevel[CurrentButtonPassAmt]; 
    }
    public void TestNextButton() 
    {
        /*TargetLevel = ButtonNextLevel[CurrentButtonPassAmt];
        LevelValueHolderScript = TargetLevel.GetComponent<LevelValueHolder>();
        LevelValueHolderScript.PassValue();*/
    }


    void Update()
    {
       
    }
}
