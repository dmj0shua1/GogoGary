using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPrefsUnlock : MonoBehaviour {

    private LevelValueHolder LevelValueHolderScript;
    public Sprite SmileSprite;


	// Use this for initialization
	void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage1")
        {
            for (int num = 1; num < 26; num++)
            {


                LevelValueHolderScript = GameObject.Find("Building_L" + num.ToString()).GetComponent<LevelValueHolder>();
                if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 0)
                {

                }
                else if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 1)
                {
                    LevelValueHolderScript.Star1.GetComponent<SpriteRenderer>().sprite = SmileSprite;

                }
                else if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 2)
                {
                    LevelValueHolderScript.Star1.GetComponent<SpriteRenderer>().sprite = SmileSprite;
                    LevelValueHolderScript.Star2.GetComponent<SpriteRenderer>().sprite = SmileSprite;

                }
                else if (PlayerPrefs.GetInt("Building_L" + LevelValueHolderScript.UnlockedValue) == 3)
                {
                    LevelValueHolderScript.Star1.GetComponent<SpriteRenderer>().sprite = SmileSprite;
                    LevelValueHolderScript.Star2.GetComponent<SpriteRenderer>().sprite = SmileSprite;
                    LevelValueHolderScript.Star3.GetComponent<SpriteRenderer>().sprite = SmileSprite;

                }
            }
        }
     
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
