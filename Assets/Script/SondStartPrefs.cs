using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SondStartPrefs : MonoBehaviour {

    public GameObject SoundBtnON;
    public GameObject SoundBtnOFF;
    public AudioSource FireSound;
    public GameObject fireObject;
    public bool IsSound;
    public GameObject xMarkObject;
    void Awake() 
    {
        /*if (PlayerPrefs.GetInt("SoundChecker") == 0)
        {
            fireObject.SetActive(true);
        }*/
    }
	void Start () {
		if (!PlayerPrefs.HasKey("SoundChecker")) PlayerPrefs.SetInt("SoundChecker", 0);
        if (PlayerPrefs.GetInt("SoundChecker")==1)
        {
            IsSound=true;
            SoundBtnOFF.SetActive(true);
            SoundBtnON.SetActive(false);
        }
        if (PlayerPrefs.GetInt("VibrateSettings") == 0)
        {
            xMarkObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("VibrateSettings") == 1)
        {
            xMarkObject.SetActive(true);
        }
        
	}
	
	// Update is called once per frame
    public void SoundButtonON() 
    {
       PlayerPrefs.SetInt("SoundChecker", 0);
       IsSound = false;

       
    }
    public void SoundButtonOFF()
    {
        PlayerPrefs.SetInt("SoundChecker", 1);
        IsSound = true;

    }
	void Update () {

        if (IsSound)
        {
            fireObject.SetActive(false);
        }
        else
        {
            fireObject.SetActive(true);     
        }
	}

    public void VibrateMethod() 
    {
        if (PlayerPrefs.GetInt("VibrateSettings") == 0)
        {
            PlayerPrefs.SetInt("VibrateSettings", 1);
            xMarkObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("VibrateSettings") == 1)
        {
            PlayerPrefs.SetInt("VibrateSettings", 0);
            xMarkObject.SetActive(false);
        }
    }
}
