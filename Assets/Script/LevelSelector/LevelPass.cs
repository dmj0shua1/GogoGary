using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : MonoBehaviour {

    public GameObject Platform, FloorCounter, TimeStart,Debris,Powerup;
    public int ObjectiveAmt, FloorAmt, StartingAmt, DebrisAmt, TimeAmt, HalfObjectiveAmt, UnlockLevelAmt, FireTriggerAmt, PowerupAmt, LevelNumberAmt,LevelStatusAmt,RescuePointAmt,RescueHolderPlayerPrefAmt,RescuePointAmtCopy;
    public bool isActivateTipsAmt,isShakeActivateAmt;
    public GameObject[] ButtonNextLevel;
    public int CurrentButtonPassAmt;
    private LevelValueHolder LevelValueHolderScript;
    public GameObject TargetLevel;
    public Color CameraColorAmt;
    public bool debriTipsAmt, starTipsAmt, boltTipsAmt, shakeTipsAmt;
    private int StageNumCounter;
    void Start()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage1")
        {
            StageNumCounter = 0;
            for (int num = 0; num < 25; num++)
            {
                StageNumCounter++;
                ButtonNextLevel[num] = (GameObject)Resources.Load("Stage1/Building_L" + StageNumCounter, typeof(GameObject));
            }
        }
        else if (sceneName == "Stage2")
        {
            StageNumCounter = 25;
            for (int num = 0; num < 25; num++)
            {
                StageNumCounter++;
                ButtonNextLevel[num] = (GameObject)Resources.Load("Stage2/pyBuilding_L" + StageNumCounter, typeof(GameObject));
            }
        }
        else if (sceneName == "Stage3")
        {
            StageNumCounter = 50;
            for (int num = 0; num < 25; num++)
            {
                StageNumCounter++;
                ButtonNextLevel[num] = (GameObject)Resources.Load("Stage3/phBuilding_L" + StageNumCounter, typeof(GameObject));
            }
        }
        else if (sceneName == "Stage4")
        {
            StageNumCounter = 75;
            for (int num = 0; num < 25; num++)
            {
                StageNumCounter++;
                ButtonNextLevel[num] = (GameObject)Resources.Load("Stage4/ieBuilding_L" + StageNumCounter, typeof(GameObject));
            }
        }
      
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
