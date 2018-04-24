using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class textLevelStatus : MonoBehaviour {

    public Text LevelStatusNumber;
    public int NumberOfLevel;

    [SerializeField]
    private LevelPass LevelPassScript;


    void Start()
    {
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
    }
   void Update()
    { 
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "GGG")
        {
            LevelStatusNumber.text = "" + NumberOfLevel;
            NumberOfLevel = LevelPassScript.LevelStatusAmt;
        }
        else if (sceneName == "GGGPYRAMID")
        {
             LevelStatusNumber.text = "" + NumberOfLevel;
            NumberOfLevel = LevelPassScript.LevelStatusAmt-25;
        }
        else if (sceneName == "GGGPREHISTORIC")
        {
            LevelStatusNumber.text = "" + NumberOfLevel;
            NumberOfLevel = LevelPassScript.LevelStatusAmt - 50;
        }
        else if (sceneName == "GGGICEAGE")
        {
            LevelStatusNumber.text = "" + NumberOfLevel;
            NumberOfLevel = LevelPassScript.LevelStatusAmt - 75;
        }
        else if (sceneName == "GGGFUTURE")
        {
            LevelStatusNumber.text = "" + NumberOfLevel;
            NumberOfLevel = LevelPassScript.LevelStatusAmt - 100;
        }
    }
}
