using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayhighscore : MonoBehaviour {

	public Text DisplayHighScore;

    void Update() 
    {
        DisplayHighScore.text = "" + PlayerPrefs.GetInt("Hscore");
    }
}
