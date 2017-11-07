using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPrefsUnlock : MonoBehaviour {

    private LevelValueHolder LevelValueHolderScript;

	// Use this for initialization
	void Start () {
        for (int num = 1; num <26; num++)
        {
            LevelValueHolderScript = GameObject.Find("Building_L" + num.ToString()).GetComponent<LevelValueHolder>();
            if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 0)
            {
                LevelValueHolderScript.Star1.SetActive(false);
                LevelValueHolderScript.Star2.SetActive(false);
                LevelValueHolderScript.Star3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 1)
            {
                LevelValueHolderScript.Star1.SetActive(true);
                LevelValueHolderScript.Star2.SetActive(false);
                LevelValueHolderScript.Star3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 2)
            {
                LevelValueHolderScript.Star1.SetActive(true);
                LevelValueHolderScript.Star2.SetActive(true);
                LevelValueHolderScript.Star3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 3)
            {
                LevelValueHolderScript.Star1.SetActive(true);
                LevelValueHolderScript.Star2.SetActive(true);
                LevelValueHolderScript.Star3.SetActive(true);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
