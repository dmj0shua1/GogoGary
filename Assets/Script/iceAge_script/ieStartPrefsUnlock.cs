using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ieStartPrefsUnlock : MonoBehaviour {
    [SerializeField]
    private ieLevelValueHolder LevelValueHolderScript;
    public Sprite SmileSprite;


	// Use this for initialization
	void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage4")
        {
            for (int num = 76; num < 101; num++)
            {
                LevelValueHolderScript = GameObject.Find("ieBuilding_L" + num.ToString()).GetComponent<ieLevelValueHolder>();
                if (PlayerPrefs.GetInt("ieBuilding_L" + LevelValueHolderScript.UnlockedValue) == 0)
                {

                }
                else if (PlayerPrefs.GetInt("ieBuilding_L" + LevelValueHolderScript.UnlockedValue) == 1)
                {
                    LevelValueHolderScript.Star1.GetComponent<SpriteRenderer>().sprite = SmileSprite;

                }
                else if (PlayerPrefs.GetInt("ieBuilding_L" + LevelValueHolderScript.UnlockedValue) == 2)
                {
                    LevelValueHolderScript.Star1.GetComponent<SpriteRenderer>().sprite = SmileSprite;
                    LevelValueHolderScript.Star2.GetComponent<SpriteRenderer>().sprite = SmileSprite;

                }
                else if (PlayerPrefs.GetInt("ieBuilding_L" + LevelValueHolderScript.UnlockedValue) == 3)
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
