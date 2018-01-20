using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class phStartPrefsUnlock : MonoBehaviour {
    [SerializeField]
    private phLevelValueHolder LevelValueHolderScript;
    public Sprite SmileSprite;


	// Use this for initialization
	void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage3")
        {
            for (int num = 51; num < 76; num++)
            {
                LevelValueHolderScript = GameObject.Find("phBuilding_L" + num.ToString()).GetComponent<phLevelValueHolder>();
                if (PlayerPrefs.GetInt("phBuilding_L" + LevelValueHolderScript.UnlockedValue) == 0)
                {

                }
                else if (PlayerPrefs.GetInt("phBuilding_L" + LevelValueHolderScript.UnlockedValue) == 1)
                {
                    LevelValueHolderScript.Star1.GetComponent<SpriteRenderer>().sprite = SmileSprite;

                }
                else if (PlayerPrefs.GetInt("phBuilding_L" + LevelValueHolderScript.UnlockedValue) == 2)
                {
                    LevelValueHolderScript.Star1.GetComponent<SpriteRenderer>().sprite = SmileSprite;
                    LevelValueHolderScript.Star2.GetComponent<SpriteRenderer>().sprite = SmileSprite;

                }
                else if (PlayerPrefs.GetInt("phBuilding_L" + LevelValueHolderScript.UnlockedValue) == 3)
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
