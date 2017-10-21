using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsLoader : MonoBehaviour {

    public GameObject TipsObject;
    private debrisGeneration DebrisGenerationScript;
    private SwipeTest SwipeTestScript;
    private playercontroller PlayerContollerScript;

	void Start () {
        DebrisGenerationScript = GameObject.Find("DebrisGeneration").GetComponent<debrisGeneration>();
        PlayerContollerScript= GameObject.Find("player").GetComponent<playercontroller>();
        SwipeTestScript = GameObject.Find("Swipe").GetComponent<SwipeTest>();

        if (DebrisGenerationScript.IsActivate)
        {
            TipsObject.SetActive(true);
            PlayerContollerScript.isAllMove = false;
            //SwipeTestScript.isSwipe = false;
            //Time.timeScale = 0f;
        }
	}
    void Awake()
    {
       
    }
	void Update () {
       
	}

    public void IsButtonActive() 
    {
        TipsObject.SetActive(false);
        PlayerContollerScript.isAllMove = true;
        //Time.timeScale = 1f;
        //SwipeTestScript.isSwipe = true;
    }
}
