using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pyStartPrefsUnlock : MonoBehaviour {
    [SerializeField]
    private pyLevelValueHolder LevelValueHolderScript;
    public Sprite SmileSprite;


	// Use this for initialization
	void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage2")
        {
            for (int num = 26; num < 51; num++)
            {
                LevelValueHolderScript = GameObject.Find("pyBuilding_L" + num.ToString()).GetComponent<pyLevelValueHolder>();
                if (PlayerPrefs.GetInt("pyBuilding_L" + LevelValueHolderScript.UnlockedValue) == 0)
                {

                }
                else if (PlayerPrefs.GetInt("pyBuilding_L" + LevelValueHolderScript.UnlockedValue) == 1)
                {
                    LevelValueHolderScript.Star1.GetComponent<SpriteRenderer>().sprite = SmileSprite;

                }
                else if (PlayerPrefs.GetInt("pyBuilding_L" + LevelValueHolderScript.UnlockedValue) == 2)
                {
                    LevelValueHolderScript.Star1.GetComponent<SpriteRenderer>().sprite = SmileSprite;
                    LevelValueHolderScript.Star2.GetComponent<SpriteRenderer>().sprite = SmileSprite;

                }
                else if (PlayerPrefs.GetInt("pyBuilding_L" + LevelValueHolderScript.UnlockedValue) == 3)
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
