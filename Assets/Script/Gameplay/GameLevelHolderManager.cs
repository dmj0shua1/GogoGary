using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLevelHolderManager : MonoBehaviour {
    [SerializeField]
    private PlatformGenerator PlatFormGeneratorScript;
    [SerializeField]
    private floorcounter FloorCounterScript;
    [SerializeField]
    private TimeManager TimeManagerScript;
    [SerializeField]
    private debrisGeneration debrisGenerationScript;
    [SerializeField]
    private PowerupGeneration PowerupGenerationScript;
    [SerializeField]
    private LevelPass LevelPassScript;
    [SerializeField]
    private OjbectTransformPosition ObjectTransformScript;
    public GameObject debriTipsObject, starTipsObject, boltTipsObject,ShakeTipsObject;
    public bool debriTipsShow, starTipsShow, boltTipsShow,ShakeTips;
    [Header("Tutorial")]
    public GameObject SwipeRightObject;
    public GameObject HandRightObject;
    private SwipeTest SwipeTestScript;
    private FireAi FireAiScript;
    private playercontroller playerControllerScript;
    private PointManager PointManagerScript;
    public Text TestDisplay;
    //public bool isActivateDifficulty;
    [Header("LevelChecker")]
    public GameObject ImageWin;
    public GameObject ImageNote;
    public Button NextButton;
    void Awake() 
    {
        PlatFormGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();
        TimeManagerScript = GameObject.Find("countDown").GetComponent<TimeManager>();
        debrisGenerationScript = GameObject.Find("DebrisGeneration").GetComponent<debrisGeneration>();
        PowerupGenerationScript = GameObject.Find("PowerupGeneration").GetComponent<PowerupGeneration>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        SwipeTestScript = GameObject.Find("Swipe").GetComponent<SwipeTest>();
        FireAiScript = GameObject.Find("Fire").GetComponent<FireAi>();
        playerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
        PointManagerScript = GameObject.Find("PointManager").GetComponent<PointManager>();

        PlatFormGeneratorScript.EndGenerate =LevelPassScript.FloorAmt;
        FloorCounterScript.MainCount = LevelPassScript.ObjectiveAmt;
        TimeManagerScript.startingTime = LevelPassScript.StartingAmt;
        debrisGenerationScript.randomDebrisThreshold = LevelPassScript.DebrisAmt;
        PlatFormGeneratorScript.timeThreshold = LevelPassScript.TimeAmt;
        FloorCounterScript.halfFloorPoint = LevelPassScript.HalfObjectiveAmt;
        PlatFormGeneratorScript.powerupThreshold = LevelPassScript.PowerupAmt;
        debrisGenerationScript.IsActivate = LevelPassScript.isActivateTipsAmt;
        PlatFormGeneratorScript.AmountRescuePoint = LevelPassScript.RescuePointAmt;
        debriTipsShow = LevelPassScript.debriTipsAmt;
        starTipsShow = LevelPassScript.starTipsAmt;
        ShakeTips = LevelPassScript.shakeTipsAmt;
        boltTipsShow = LevelPassScript.boltTipsAmt;

        if (debriTipsShow)
        {
            debriTipsObject.SetActive(true);
            SwipeTestScript.enabled = false;
           
        }
        else if (starTipsShow)
        {
            starTipsObject.SetActive(true);
            SwipeTestScript.enabled = false;
        }
        else if (ShakeTips)
        {
            ShakeTipsObject.SetActive(true);
            SwipeTestScript.enabled = false;
        }
         else if (boltTipsShow)
        {
            boltTipsObject.SetActive(true);
            SwipeTestScript.enabled = false;
        }
        else if (LevelPassScript.UnlockLevelAmt == 1)
        {
           ObjectTransformScript.IsActivate = true;
           SwipeRightObject.SetActive(true);
           HandRightObject.SetActive(true);

        }
        //completeLevelMethod();
        //TestDisplay.text = "" + PlayerPrefs.GetInt("CompleteLevelCounter");
    }

    public void isSwipeMethod() 
    {
        SwipeTestScript.enabled = true;
    }

    public void completeLevelMethod() 
    {
        //if (isActivateDifficulty)
       // {
        if (LevelPassScript.LevelStatusAmt >= 15)
        {
           
            if (PlayerPrefs.GetInt("CompleteLevelCounter") == 1)
            {

                FireAiScript.minSpeed = FireAiScript.minSpeed + 1;
                FireAiScript.maxSpeed = FireAiScript.maxSpeed + 1;
            }
            if (PlayerPrefs.GetInt("CompleteLevelCounter") == 2)
            {
                playerControllerScript.DecreaseSpeed = playerControllerScript.DecreaseSpeed - 1;
                FireAiScript.minSpeed = FireAiScript.minSpeed + 1;
                FireAiScript.maxSpeed = FireAiScript.maxSpeed + 1;
            }
            if (PlayerPrefs.GetInt("CompleteLevelCounter") >= 3)
            {
                FireAiScript.minSpeed = FireAiScript.minSpeed + 1;
                FireAiScript.maxSpeed = FireAiScript.maxSpeed + 1;

            }
            if (PlayerPrefs.GetInt("CompleteLevelCounter") >= 6)
            {
                playerControllerScript.DecreaseSpeed = playerControllerScript.DecreaseSpeed - 1;
            }
            if (PlayerPrefs.GetInt("CompleteLevelCounter") >= 9)
            {
                FireAiScript.minSpeed = FireAiScript.minSpeed + 1;
                FireAiScript.maxSpeed = FireAiScript.maxSpeed + 1;
                playerControllerScript.DecreaseSpeed = playerControllerScript.DecreaseSpeed - 1;
                //PointManagerScript.isCompleteActivate = false;

            }
        }
        //}
        
    }
    //rescuechecker
    public void RescueUnlockChecker() 
    {   
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "GGG")
        {
            if (PlayerPrefs.GetInt("UnlockLevels") == 16 || PlayerPrefs.GetInt("UnlockLevels") == 15)
            {
                if (LevelPassScript.LevelStatusAmt >= 15)
                {

                    if (PlayerPrefs.GetInt("TotalRescuePoints") != 45)
                    {
                        ImageWin.SetActive(false);
                        ImageNote.SetActive(true);
                        NextButton.interactable = false;
                    }
                    else
                    {
                        ImageWin.SetActive(true);
                        ImageNote.SetActive(false);
                    }
                }

                else
                {
                    ImageWin.SetActive(true);
                    ImageNote.SetActive(false);
                }
            }
            if (PlayerPrefs.GetInt("UnlockLevels") == 21 || PlayerPrefs.GetInt("UnlockLevels") == 20)
            {
                if (LevelPassScript.LevelStatusAmt >= 20)
                {

                    if (PlayerPrefs.GetInt("TotalRescuePoints") != 60)
                    {
                        ImageWin.SetActive(false);
                        ImageNote.SetActive(true);
                        NextButton.interactable = false;
                    }
                    else
                    {
                        ImageWin.SetActive(true);
                        ImageNote.SetActive(false);
                    }
                }

                else
                {
                    ImageWin.SetActive(true);
                    ImageNote.SetActive(false);
                }
            }
        }
        else if (sceneName == "GGGPYRAMID")
        {
            if (PlayerPrefs.GetInt("UnlockLevels") == 40 || PlayerPrefs.GetInt("UnlockLevels") == 41)
            {
                if (LevelPassScript.LevelStatusAmt >= 40)
                {

                    if (PlayerPrefs.GetInt("pyTotalRescuePoints") != 45)
                    {
                        ImageWin.SetActive(false);
                        ImageNote.SetActive(true);
                        NextButton.interactable = false;
                    }
                    else
                    {
                        ImageWin.SetActive(true);
                        ImageNote.SetActive(false);
                    }
                }

                else
                {
                    ImageWin.SetActive(true);
                    ImageNote.SetActive(false);
                }
            }
            if (PlayerPrefs.GetInt("UnlockLevels") == 45 || PlayerPrefs.GetInt("UnlockLevels") == 46)
            {
                if (LevelPassScript.LevelStatusAmt >= 45)
                {

                    if (PlayerPrefs.GetInt("pyTotalRescuePoints") != 60)
                    {
                        ImageWin.SetActive(false);
                        ImageNote.SetActive(true);
                        NextButton.interactable = false;
                    }
                    else
                    {
                        ImageWin.SetActive(true);
                        ImageNote.SetActive(false);
                    }
                }

                else
                {
                    ImageWin.SetActive(true);
                    ImageNote.SetActive(false);
                }
            }
        }
        
        //stage2
    }
    //
}
