using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SondStartPrefs : MonoBehaviour {

    public GameObject SoundBtnON;
    public GameObject SoundBtnOFF;
    public AudioSource FireSound;
    public GameObject fireObject;
    public bool IsSound;
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
}
