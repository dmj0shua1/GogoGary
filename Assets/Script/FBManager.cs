using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using System.IO;
using System;

public class FBManager : MonoBehaviour
{

    public Text txtStatus;
    public GameObject internetMessageBox;
    public GameObject leaderBoard;
    public GameObject backBtn;
    private internetChecker InternetCheckerScript;

    List<string> perms = new List<string>() { "public_profile", "email", "user_friends" };

    public GameObject LoggedInButtons, btnLogin, btnShare, btnInvite;

    AudioSource sfxCoins;
    // Awake function from Unity's MonoBehavior
    void Start() 
    {
        InternetCheckerScript = GameObject.Find("internetChecker").GetComponent<internetChecker>();
    }
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }

       // sfxCoins = GameObject.Find("sfxPurchasing").GetComponent<AudioSource>();

    }

    public void resetStatusText()
    {
        if (PlayerPrefs.HasKey("shareCoinClaimed") && PlayerPrefs.HasKey("inviteCoinClaimed"))
        {
            txtStatus.text = "leaderboards coming soon! :)";
        }
        else
        {
            //default status text
            txtStatus.text = "share and invite your friends";
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
            txtStatus.text = "Failed to Initialize the Facebook SDK";
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    public void FBLogin()
    {
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }


    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            //txtStatus.text = "UserId: " + aToken.UserId;
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }


            //hide login and show logged in buttons
            btnLogin.SetActive(false);
            LoggedInButtons.SetActive(true);

        }
        else
        {
            Debug.Log("User cancelled login");
            //  txtStatus.text = "User cancelled login";
        }
    }

    public void Share()
    {
#if UNITY_ANDROID
        FB.ShareLink(
            // contentTitle: "Gary G message", 
             new Uri("https://play.google.com/store/apps/details?id=com.LoopBook.GogoGary"),
             contentDescription: "Link to the Playstore",
             photoURL: new Uri("https://i.ytimg.com/vi/Yj7ja6BANLM/maxresdefault.jpg"),
             callback: OnShare);

#elif UNITY_IPHONE
        FB.ShareLink(
            contentTitle: "Gary G message",
            contentURL: new System.Uri("https://itunes.apple.com/us/app/go-go-gary/id1301914670"), 
            contentDescription: "Link to the App Store",
            photoURL: new System.Uri("http://is5.mzstatic.com/image/thumb/Purple128/v4/c8/80/2f/c8802f09-49b2-56b5-a353-f7c4091b7055/source/392x696bb.jpg"), 
            callback: OnShare);
#endif
    }



    private void OnShare(IShareResult result)
    {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            print("Sharelink error: " + result.Error);
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            print(result.PostId);
        }
        else
        {
            print("Share succeed");
            if (!PlayerPrefs.HasKey("shareCoinClaimed"))
            {

                //This is what happens when sharing is a success
                /*
                txtStatus.text = "You received 10 coins for sharing!";
                PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") + 10);*/
                PlayerPrefs.SetInt("shareCoinClaimed", 1);

                //play audio when reward is received
               // if (PlayerPrefs.GetInt("Sfx") == 1) sfxCoins.Play();
            }
            else
            {
                txtStatus.text = "Thank you for sharing with your friends!";
            }

        }
    }

    public void AppInvite()
    {

        FB.Mobile.AppInvite(
 new Uri("https://www.facebook.com/Go-Go-Gary-1489943204431325"),
 new Uri("http://is5.mzstatic.com/image/thumb/Purple128/v4/c8/80/2f/c8802f09-49b2-56b5-a353-f7c4091b7055/source/392x696bb.jpg"),
    OnAppInvite
    );
    }

    private void OnAppInvite(IAppInviteResult result)
    {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            print("Invite error: " + result.Error);
        }
        else
        {
            print("Invite succeed");
            if (!PlayerPrefs.HasKey("inviteCoinClaimed"))
            {
                //This is what happens when inviting is a success
                /*
                txtStatus.text = "You received 10 coins for inviting!";
                PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") + 10);*/
                PlayerPrefs.SetInt("inviteCoinClaimed", 1);
                
                //Play audio when reward is received
                //if (PlayerPrefs.GetInt("Sfx") == 1) sfxCoins.Play();
            }
            else
            {
                txtStatus.text = "Thank you for inviting your friends!";
            }

        }
    }

    public void InviteFriends()
    {
        FB.AppRequest(
      "Here is a free gift!",
      null,
      new List<object>() { "app_users" },
      null, null, null, null,
      delegate(IAppRequestResult result)
      {
          Debug.Log(result.RawResult);
      }
  );
    }

    public void internetMessageBoxMethod() 
    {
        if (InternetCheckerScript.internetConnectBool == false)
        {
            internetMessageBox.SetActive(true);
            leaderBoard.SetActive(false);
            backBtn.SetActive(false);
        }
    }
}
