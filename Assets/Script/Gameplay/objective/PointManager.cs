using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour {

    public bool UnlockNow;
    public GameObject ViewPanel;
    public GameObject WarningSign;
    public Text loadingText;
    public bool IsActivate;
    private bool loadScene = true;
	private floorcounter FloorCounterScript;
	private CameraFollow CameraFollowScript;
	private FireAi FireAiScript;
	private TimeManager TimeManagerScript;
    private playercontroller PlayerControllerScript;
    private PowerupManager PowerupManagerScript;
    private LevelPass LevelPassScript;
    private PlusSpeedManager PlusSpeedManagerScript;
    private LevelValueHolder LevelValueHolderScript;
    private RescueManager RescueManagerScript;
    public bool isTestActivate;
    public GameObject Pause;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject MissionFailedObject;
    public bool isComplete;
    public bool isCompleteActivate;
    private Animator MyAnimation;
    private Animator MyAnimationLava;

    public GameObject wallofdeathparticle1;
    public GameObject wallofdeathparticle2;
    public AudioSource FireSfx;
    public AudioSource viewPanelSfx;
    //public Text TestDisplay;
    //public Sprite SmileyObject;


	void Start()
	{
        if (SceneManager.GetActiveScene().name == "GGGPYRAMID") MyAnimation = GameObject.Find("WallOfDeath").GetComponent<Animator>();
        if (SceneManager.GetActiveScene().name == "GGGPREHISTORIC")MyAnimationLava= GameObject.Find("LavaOfDeath").GetComponent<Animator>();
		FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();
		CameraFollowScript = GameObject.Find ("Main Camera").GetComponent<CameraFollow>();
		FireAiScript = GameObject.Find ("Fire").GetComponent<FireAi> ();
		TimeManagerScript = GameObject.Find ("countDown").GetComponent<TimeManager> ();
        PlayerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
        PowerupManagerScript = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        PlusSpeedManagerScript = GameObject.Find("plusspeedManager").GetComponent<PlusSpeedManager>();
        RescueManagerScript = GameObject.Find("RescueManager").GetComponent<RescueManager>();
        if (PlayerPrefs.GetInt("SoundChecker") == 0)
        {
            viewPanelSfx.enabled = true;
          
        }
        else if (PlayerPrefs.GetInt("SoundChecker") == 1)
        {
            viewPanelSfx.enabled = false;
        }
	}
	void Update()
	{
		//FloorObjective ();
		CheckPointObjective ();
		HalfFloorCount ();
        WarningSignTrigger();
       
        //completeLevelCounterMethod();
        /*if (loadScene == true)
         {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }*/  
	}
 	
	private void CheckPointObjective()
	{
		if (FloorCounterScript.countFloor == FloorCounterScript.CameraStopPoint) 
		{
            CameraFollowScript.enabled = false;
        }
	}

	public void HalfFloorCount()
	{
		if(FloorCounterScript.countFloor == FloorCounterScript.halfFloorPoint)
		{
        }
	}


	public void FloorObjective()
	{

        if (FloorCounterScript.countFloor == FloorCounterScript.floorObjective)
        {
            //FireAiScript.StartFire = false;
            TimeManagerScript.isStopMainTime = false;
            //PlayerControllerScript.moveSpeed = 0f;
            PowerupManagerScript.powerupActive = false;
            PlusSpeedManagerScript.addSpeedActive = false;
            ViewPanel.SetActive(true);
            Pause.SetActive(false);
            //completeLevelCounterMethod();
            NextLevelMethod();
            CheckerUnlock();
            StarRateChecker();
            Scene currentScene1 = SceneManager.GetActiveScene();
            string sceneName1 = currentScene1.name;
            if (sceneName1 == "GGG")
            {
                if (PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) < LevelPassScript.RescueHolderPlayerPrefAmt)
                {
                    if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
                    {
                        PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), LevelPassScript.RescueHolderPlayerPrefAmt);

                    }
                    PlayerPrefs.SetInt("TotalRescuePoints", PlayerPrefs.GetInt("TotalRescuePoints") + LevelPassScript.RescueHolderPlayerPrefAmt);
                    PlayerPrefs.SetInt("TotalRescuePoints", PlayerPrefs.GetInt("TotalRescuePoints") - LevelPassScript.RescuePointAmtCopy);
                }

            }
        }
        //completelevelcounter
      //
        Scene currentScene2 = SceneManager.GetActiveScene();
        string sceneName2 = currentScene2.name;
        if (sceneName2 == "GGGPYRAMID")
        {
            if (PlayerPrefs.GetInt("pyBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString()) < LevelPassScript.RescueHolderPlayerPrefAmt)
            {
                if (PlayerPrefs.HasKey("pyBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString()))
                {
                    PlayerPrefs.SetInt("pyBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString(), LevelPassScript.RescueHolderPlayerPrefAmt);

                }
                PlayerPrefs.SetInt("pyTotalRescuePoints", PlayerPrefs.GetInt("pyTotalRescuePoints") + LevelPassScript.RescueHolderPlayerPrefAmt);
                PlayerPrefs.SetInt("pyTotalRescuePoints", PlayerPrefs.GetInt("pyTotalRescuePoints") - LevelPassScript.RescuePointAmtCopy);
            }
        }

        //
        Scene currentScene3 = SceneManager.GetActiveScene();
        string sceneName3 = currentScene3.name;
        if (sceneName3 == "GGGPREHISTORIC")
        {
            if (PlayerPrefs.GetInt("phBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString()) < LevelPassScript.RescueHolderPlayerPrefAmt)
            {
                if (PlayerPrefs.HasKey("phBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString()))
                {
                    PlayerPrefs.SetInt("phBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString(), LevelPassScript.RescueHolderPlayerPrefAmt);

                }
                PlayerPrefs.SetInt("phTotalRescuePoints", PlayerPrefs.GetInt("phTotalRescuePoints") + LevelPassScript.RescueHolderPlayerPrefAmt);
                PlayerPrefs.SetInt("phTotalRescuePoints", PlayerPrefs.GetInt("phTotalRescuePoints") - LevelPassScript.RescuePointAmtCopy);
            }
        }
        //
        Scene currentScene4 = SceneManager.GetActiveScene();
        string sceneName4 = currentScene4.name;
        if (sceneName4 == "GGGICEAGE")
        {
            if (PlayerPrefs.GetInt("ieBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString()) < LevelPassScript.RescueHolderPlayerPrefAmt)
            {
                if (PlayerPrefs.HasKey("ieBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString()))
                {
                    PlayerPrefs.SetInt("ieBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString(), LevelPassScript.RescueHolderPlayerPrefAmt);

                }
                PlayerPrefs.SetInt("ieTotalRescuePoints", PlayerPrefs.GetInt("ieTotalRescuePoints") + LevelPassScript.RescueHolderPlayerPrefAmt);
                PlayerPrefs.SetInt("ieTotalRescuePoints", PlayerPrefs.GetInt("ieTotalRescuePoints") - LevelPassScript.RescuePointAmtCopy);
            }
        }
        //
        Scene currentScene5 = SceneManager.GetActiveScene();
        string sceneName5 = currentScene4.name;
        if (sceneName5 == "GGGFUTURE")
        {
            if (PlayerPrefs.GetInt("ftBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString()) < LevelPassScript.RescueHolderPlayerPrefAmt)
            {
                if (PlayerPrefs.HasKey("ftBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString()))
                {
                    PlayerPrefs.SetInt("ftBuilding_L" + LevelPassScript.UnlockLevelAmt.ToString(), LevelPassScript.RescueHolderPlayerPrefAmt);

                }
                PlayerPrefs.SetInt("ftTotalRescuePoints", PlayerPrefs.GetInt("ftTotalRescuePoints") + LevelPassScript.RescueHolderPlayerPrefAmt);
                PlayerPrefs.SetInt("ftTotalRescuePoints", PlayerPrefs.GetInt("ftTotalRescuePoints") - LevelPassScript.RescuePointAmtCopy);
            }
        }
       
	}
    public void completeLevelCounterMethod()
    {
        
        //if (isCompleteActivate)
        //{
            if (isComplete && LevelPassScript.LevelStatusAmt >= 15/*&& PlayerPrefs.GetInt("CompleteLevelCounter") <= 9*/)
            { 
                PlayerPrefs.SetInt("CompleteLevelCounter", PlayerPrefs.GetInt("CompleteLevelCounter") + 1);
                /*TestDisplay.text = "" + PlayerPrefs.GetInt("CompleteLevelCounter");*/
                isComplete = false;

            }
                
        //}
    }
    public void StarRateChecker() 
    {
        if (RescueManagerScript.RescuePointCount == 0)
        {
            /*Star1.gameObject.SetActive(false);
            Star2.gameObject.SetActive(false);
            Star3.gameObject.SetActive(false);*/
        }
        else if (LevelPassScript.RescueHolderPlayerPrefAmt == 1)
        {
            //Star1.GetComponent<SpriteRenderer>().sprite = SmileyObject;
            Star1.gameObject.SetActive(true);
            Star2.gameObject.SetActive(false);
            Star3.gameObject.SetActive(false);
        }
        else if (LevelPassScript.RescueHolderPlayerPrefAmt == 2)
        {
            //Star1.GetComponent<SpriteRenderer>().sprite = SmileyObject;
            //Star2.GetComponent<SpriteRenderer>().sprite = SmileyObject;
            Star1.gameObject.SetActive(true);
            Star2.gameObject.SetActive(true);
            Star3.gameObject.SetActive(false);
        }
        else if (LevelPassScript.RescueHolderPlayerPrefAmt == 3)
        {
            //Star1.GetComponent<SpriteRenderer>().sprite = SmileyObject;
            //Star2.GetComponent<SpriteRenderer>().sprite = SmileyObject;
            //Star3.GetComponent<SpriteRenderer>().sprite = SmileyObject;

            Star1.gameObject.SetActive(true);
            Star2.gameObject.SetActive(true);
            Star3.gameObject.SetActive(true);
        }
    }
    private void NextLevelMethod() 
    {
        if (RescueManagerScript.RescuePointCount >= 1)
       {
            if (UnlockNow && PlayerPrefs.GetInt("UnlockLevels") == LevelPassScript.UnlockLevelAmt)
            {
                    PlayerPrefs.SetInt("UnlockLevels", PlayerPrefs.GetInt("UnlockLevels") + 1);
                    UnlockNow = false; 
            }
          
            else
            {
                UnlockNow = false;
            }
       }
        else if (RescueManagerScript.RescuePointCount == 0)
        {
            ViewPanel.SetActive(false);
            MissionFailedObject.SetActive(true);
        }
        //else 
        //{
           // print(RescueManagerScript.RescuePointCount);
        //}
       
     
    }
    public void CheckerUnlock() 
    {
        
    }

    private void WarningSignTrigger() 
    {
        if (FloorCounterScript.countFloor == LevelPassScript.FireTriggerAmt && IsActivate)
        {
         
           
            FireAiScript.StartFire = true;
            WarningSign.SetActive(true);
            StartCoroutine(LoadNewScene());
            IsActivate = false;
            TimeManagerScript.isStopMainTime = true;
            //
            Scene currentScenewd = SceneManager.GetActiveScene();
            string sceneNamewd = currentScenewd.name;
            if (sceneNamewd == "GGGPYRAMID")
            {
                wallofdeathparticle1.SetActive(true);
                wallofdeathparticle2.SetActive(true);
                MyAnimation.SetBool("isIdle", false); 
            }
            if (sceneNamewd == "GGGPYRAMID" && PlayerPrefs.GetInt("SoundChecker") == 0)
            {
                FireSfx.enabled = true;
                wallofdeathparticle1.SetActive(true);
                wallofdeathparticle2.SetActive(true);
                MyAnimation.SetBool("isIdle", false);
            }
            if (sceneNamewd == "GGGPREHISTORIC")
            {
                
                MyAnimationLava.SetBool("isIdle", false);
            }
            if (sceneNamewd == "GGGICEAGE" && PlayerPrefs.GetInt("SoundChecker") == 0)
            {
                FireSfx.enabled = true;
               
            }
        }    
    }
    
    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);
        WarningSign.SetActive(false);
    }
    
}