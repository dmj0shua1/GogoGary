using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelValueHolder : MonoBehaviour {

    public Button TestButtonObject;
    [SerializeField]
    private MainHolder MainHolderScript;
    [SerializeField]
    private ButtonCameraView ButtonCameraViewScript;
    public int ObjectiveValue, FloorValue, StartingValue, DebrisValue, TimeValue, HalfObjectiveValue, UnlockedValue, FireTriggerValue, PowerupValue, LevelPlaceValue,RescuePointValue,RescueHolderPlayerPref;
    public bool isActivateTipsValue, isShakeActivateValue;
    public Color CameraColorValue;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public bool debriTipsValue, starTipsValue, boltTipsValue,shakeTipsValue;
 
    void Start() 
    {
        MainHolderScript = GameObject.Find("LevelButton1").GetComponent<MainHolder>();
        ButtonCameraViewScript = GameObject.Find("Main Camera View").GetComponent<ButtonCameraView>();
    }

    public void CheckEnabled() 
    {
        if (UnlockedValue <= PlayerPrefs.GetInt("UnlockLevels"))
        {
            TestButtonObject.interactable = true;
            // gameObject.GetComponent<Button>().interactable = true;
        }
    }
    public void PassValue () 
    {
        MainHolderScript.ObjectivePass = ObjectiveValue;
        MainHolderScript.FloorPass = FloorValue;
        MainHolderScript.StartingPass= StartingValue; 
        MainHolderScript.DebrisPass = DebrisValue; 
        MainHolderScript.TimePass = TimeValue;
        MainHolderScript.HalfObjectivePass = HalfObjectiveValue;
        MainHolderScript.UnlockedLevels = UnlockedValue;
        MainHolderScript.FireTriggerPass  = FireTriggerValue;
        MainHolderScript.PowerupPass = PowerupValue;
        MainHolderScript.isActivateTipsPass = isActivateTipsValue;
        MainHolderScript.isShakeActivatePass = isShakeActivateValue;
        MainHolderScript.ButtonPass = LevelPlaceValue;
        MainHolderScript.CameraColorPass = CameraColorValue;
        MainHolderScript.RescuePointPass = RescuePointValue;
        MainHolderScript.RescueHolderPrefPass = RescueHolderPlayerPref;
        MainHolderScript.debriTipsPass = debriTipsValue;
        MainHolderScript.starTipsPass = starTipsValue;
        MainHolderScript.boltTipsPass = boltTipsValue;
        MainHolderScript.shakeTipsPass = shakeTipsValue;

    }
}
