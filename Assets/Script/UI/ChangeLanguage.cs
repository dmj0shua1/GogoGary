using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguage : MonoBehaviour {

    public Image EnglishImage;
    public Sprite ChineseSprite;
    public Sprite OriginalSprite;
    public GameObject StartupObject;
    public GameObject StartupButton;
    //private SpriteRenderer sprite;
    void awake()
    {
        if (!PlayerPrefs.HasKey("LanguageNumber")) PlayerPrefs.SetInt("LanguageNumber", 0);
        if (!PlayerPrefs.HasKey("LanguageStartup")) PlayerPrefs.SetInt("LanguageStartup", 0);
      
    }
	void Start () {
        //sprite = GetComponent<SpriteRenderer>();
        startupLanguageMethod();
    
        
	}
	

	void Update () {
        if (PlayerPrefs.GetInt("LanguageNumber") == 1)
        {
            EnglishImage.GetComponent<Image>().overrideSprite = ChineseSprite;

           
        }

       
        else if (PlayerPrefs.GetInt("LanguageNumber") == 0)
        {
            EnglishImage.GetComponent<Image>().overrideSprite = OriginalSprite;
          
        }

        if (PlayerPrefs.GetInt("LanguageStartup") == 1)
        {
            StartupButton.SetActive(false);  
        }

        
	}

    public void LanguageChangerMethod(int num) 
    {
        PlayerPrefs.SetInt("LanguageNumber", num);
    }

    public void startupLanguageMethod() 
    {
        if (PlayerPrefs.GetInt("LanguageStartup") == 0)
        {
            StartupObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("LanguageStartup") == 1)
        {
            StartupObject.SetActive(false);
        }
    }
    public void CloseLanguageMethod()
    {
        if (PlayerPrefs.GetInt("LanguageStartup") == 0)
        {
            PlayerPrefs.SetInt("LanguageStartup", 1);
       
            //StartupObject.SetActive(false);
        }
    }
}
