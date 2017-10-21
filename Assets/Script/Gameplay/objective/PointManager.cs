using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	void Start()
	{
		FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();
		CameraFollowScript = GameObject.Find ("Main Camera").GetComponent<CameraFollow>();
		FireAiScript = GameObject.Find ("Fire").GetComponent<FireAi> ();
		TimeManagerScript = GameObject.Find ("countDown").GetComponent<TimeManager> ();
        PlayerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
        PowerupManagerScript = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        PlusSpeedManagerScript = GameObject.Find("plusspeedManager").GetComponent<PlusSpeedManager>();
        RescueManagerScript = GameObject.Find("RescueManager").GetComponent<RescueManager>();
	}
	void Update()
	{
		FloorObjective ();
		CheckPointObjective ();
		HalfFloorCount ();
        WarningSignTrigger();

        if (loadScene == true)
         {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }  
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


	private void FloorObjective()
	{
   
		if (FloorCounterScript.countFloor == FloorCounterScript.floorObjective ) 
		{
        FireAiScript.StartFire = false;
        TimeManagerScript.isStopMainTime = false;
        PlayerControllerScript.moveSpeed = 0f;
        PowerupManagerScript.powerupActive = false;
        PlusSpeedManagerScript.addSpeedActive = false;
        ViewPanel.SetActive(true);
        Pause.SetActive(false);
        NextLevelMethod();
        CheckerUnlock();
        if (PlayerPrefs.GetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()) < LevelPassScript.RescueHolderPlayerPrefAmt )
        {
            if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
            {
                PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), LevelPassScript.RescueHolderPlayerPrefAmt);
                
            }
            PlayerPrefs.SetInt("TotalRescuePoints", PlayerPrefs.GetInt("TotalRescuePoints") + LevelPassScript.RescueHolderPlayerPrefAmt);
            PlayerPrefs.SetInt("TotalRescuePoints", PlayerPrefs.GetInt("TotalRescuePoints") - LevelPassScript.RescuePointAmtCopy);
        }
        StarRateChecker();
		}
       
	}
    public void StarRateChecker() 
    {
        if (RescueManagerScript.RescuePointCount == 0)
        {
            Star1.gameObject.SetActive(false);
            Star2.gameObject.SetActive(false);
            Star3.gameObject.SetActive(false);
        }
        else if (LevelPassScript.RescueHolderPlayerPrefAmt == 1)
        {
             Star1.gameObject.SetActive(true);
            Star2.gameObject.SetActive(false);
            Star3.gameObject.SetActive(false); 
        }
        else if (LevelPassScript.RescueHolderPlayerPrefAmt == 2)
        {
            Star1.gameObject.SetActive(true);
            Star2.gameObject.SetActive(true);
            Star3.gameObject.SetActive(false);
        }
        else if (LevelPassScript.RescueHolderPlayerPrefAmt == 3)
        {
            Star1.gameObject.SetActive(true);
            Star2.gameObject.SetActive(true);
            Star3.gameObject.SetActive(true);
        }
    }
    private void NextLevelMethod() 
    {
        //if (RescueManagerScript.RescuePointCount >= 1)
        //{
            if (UnlockNow && PlayerPrefs.GetInt("UnlockLevels") == LevelPassScript.UnlockLevelAmt)
            {
                PlayerPrefs.SetInt("UnlockLevels", PlayerPrefs.GetInt("UnlockLevels") + 1);
            
                UnlockNow = false;
            }
            else
            {
                UnlockNow = false;
            }
       // }
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
            
        }    
    }
    
    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);
        WarningSign.SetActive(false);
    }
    
}