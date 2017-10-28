using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleAd : MonoBehaviour {
// Use this for initialization
    public GameObject objRewardedAds;
    Text txtFreeCoinAmount;
    AudioSource coinAudio;
    Text txtuigold;

#if UNITY_IOS
    private string gameId = "1576335";
#elif UNITY_ANDROID
private string gameId = "1576334";
#endif
    void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, true);
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
        if (PlayerPrefs.GetInt("adsCounter") <= 3 )
        {
            PlayerPrefs.SetInt("adsCounter",PlayerPrefs.GetInt("adsCounter") + 1);
            print("ifAds");
        }
        else
        {
            PlayerPrefs.SetInt("adsCounter", 0);
            Invoke("showAdInvoked", 1.0f);
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
        /*     PlayerPrefs.SetInt("rewardedAdCounter", 0);
             PlayerPrefs.SetInt("rewardClaimed",1);*/
             objRewardedAds.SetActive(false);
             Invoke("displayCoinReceived", 1.5f);
          
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
}

