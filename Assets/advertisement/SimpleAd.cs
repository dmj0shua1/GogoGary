using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleAd : MonoBehaviour {
// Use this for initialization
    public GameObject objRewardedAds;
    public GameObject ImageDeath;
    public GameObject RewardsInfo;
    Text txtFreeCoinAmount;
    AudioSource coinAudio;
    Text txtuigold;
    private LevelPass LevelPassScript;
    private LevelValueHolder LevelValueHolderScript;
    public GameObject GameOverObject;
    public GameObject internetMessageBox;
    private internetChecker InternetCheckerScript;
    public GameObject PanelForAds;
    public EnergyManager egManagerScript;
    public GameObject internetConDialog;
    public bool adReady;
    //public Animation gameOverFade;
#if UNITY_IOS
    private string gameId = "1576335";
#elif UNITY_ANDROID
private string gameId = "1576334";
#endif
void Awake()
{
    egManagerScript = GameObject.Find("Energy").GetComponent<EnergyManager>();

    if (SceneManager.GetActiveScene().name == "GGG" || SceneManager.GetActiveScene().name == "GGGPYRAMID")
    {
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        ImageDeath.SetActive(false);
        if (!PlayerPrefs.HasKey("rewardClaimed")) PlayerPrefs.SetInt("rewardClaimed", 0);
        if (PlayerPrefs.GetInt("rewardClaimed") == 0)
        {
            LevelPassScript.FireTriggerAmt = LevelPassScript.FireTriggerAmt - 2;
            PlayerPrefs.SetInt("rewardClaimed", 1);
            print("ok");
        }

    }
}
    void Start()
    {
        InternetCheckerScript = GameObject.Find("internetChecker").GetComponent<internetChecker>();
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId);
        }

        if (SceneManager.GetActiveScene().name == "adtest")
        {
            PlayerPrefs.SetInt("adsCounter",0);
        }

        if (!PlayerPrefs.HasKey("adsDisabled"))
        {
            PlayerPrefs.SetInt("adsDisabled", 0);
        }
        //txtFreeCoinAmount = GameObject.Find("freeCoinsAmount").GetComponent<Text>();
        //coinAudio = GameObject.Find("sfxBuySound").GetComponent<AudioSource>();
        //txtuigold = GameObject.Find("txtuigold").GetComponent<Text>();
    }

    public void gameOverAd()
    {
        if (PlayerPrefs.GetInt("adsCounter") <= 2 )
        {
            PlayerPrefs.SetInt("adsCounter",PlayerPrefs.GetInt("adsCounter") + 1);
            print("ifAds");
        }
        else
        {
            PlayerPrefs.SetInt("adsCounter", 0);
            Invoke("showAdInvoked", /*1.0f*/0.200f);
            objRewardedAds.SetActive(false);
            ImageDeath.SetActive(true);
            //PanelForAds.SetActive(true);
            //StartCoroutine(PanelAds());
            print("elseAds");
        }
    }

    private void showAdInvoked()
    {
        ShowAd();
    }

	 public void ShowAd()
  {
      if (Advertisement.IsReady())
    {
        Advertisement.Show();
    }


  }

     public void DisableAds()
     {
         PlayerPrefs.SetInt("adsDisabled", 1);
     }

     public void rewardedAd()
     {
         if (Advertisement.IsReady("rewardedVideo"))
         {
             Advertisement.Show("rewardedVideo");
             print("ifrewardAds");
            // PlayerPrefs.SetInt("rewardedAdCounter", 0);
             PlayerPrefs.SetInt("rewardClaimed",0);
             objRewardedAds.SetActive(false);
             StartCoroutine(rewardInfoTime());
             //RewardsInfo.SetActive(true);
             ImageDeath.SetActive(true);
             Invoke("displayCoinReceived", 1.5f);
          
         }

      /*   var options = new ShowOptions { resultCallback = HandleShowResult };
         Advertisement.Show("rewardedVideo", options);*/
     }

     public void rewardedAdLvlSelector()
     {
         if (Advertisement.IsReady("rewardedVideo"))
         {
           
            // Advertisement.Show("rewardedVideo");

         }
         else
         {
             Debug.Log(string.Format("Ads not ready for placement '{0}'", "rewardedVideo"));
             internetConDialog.SetActive(true);
         }
         var options = new ShowOptions { resultCallback = HandleShowResult };
         Advertisement.Show("rewardedVideo", options);
     }
     public void internetmessageBoxMethod() 
     {
         if (InternetCheckerScript.internetConnectBool == false)
         {
             internetMessageBox.SetActive(true);   
         }
     }
     public void AddHeadstart() 
     {
         if (PlayerPrefs.GetInt("rewardClaimed")==0)
         {
             LevelPassScript.FireTriggerAmt = LevelPassScript.FireTriggerAmt - 2;
             PlayerPrefs.SetInt("rewardClaimed", 1);
             print("ok");
         }
         else
         {
             LevelPassScript.TargetLevel = LevelPassScript.ButtonNextLevel[LevelPassScript.CurrentButtonPassAmt];
             LevelValueHolderScript = LevelPassScript.TargetLevel.GetComponent<LevelValueHolder>();
             LevelPassScript.FireTriggerAmt = LevelValueHolderScript.FireTriggerValue;
         }
     }
     void displayCoinReceived()
     {
         /*int randomCoin = UnityEngine.Random.Range(10, 15);
         PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") + randomCoin);
         txtFreeCoinAmount.text = "You got " + randomCoin.ToString() + " free coins!";
         coinAudio.PlayDelayed(1f);

         int curGold = Convert.ToInt32(txtuigold.text.ToString());
         txtuigold.text = (curGold + randomCoin).ToString();*/
     }
     IEnumerator rewardInfoTime()
     {
         yield return new WaitForSeconds(1);
        RewardsInfo.SetActive(true);
        GameOverObject.SetActive(false);
        //gameOverFade.enabled = true;
     }
     IEnumerator PanelAds()
     {
         yield return new WaitForSeconds(2);
         PanelForAds.SetActive(false);
     }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                giveRewards();
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                internetConDialog.SetActive(true);
                break;
        }
    }

    private void giveRewards()
    {
        if (SceneManager.GetActiveScene().name == "Stage1" || SceneManager.GetActiveScene().name == "Stage2" || SceneManager.GetActiveScene().name == "Stage3" || SceneManager.GetActiveScene().name == "Stage4")
        {
            //energy reward
            objRewardedAds.SetActive(false);
            egManagerScript.refillAmountAdSuccess();
             internetConDialog.SetActive(false);
          
        }
    }

    public void checkIfReady(string placementId)
    {
        adReady = Advertisement.IsReady(placementId);
    }

}

