using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        LevelStatusNumber.text = "" + NumberOfLevel;
        NumberOfLevel = LevelPassScript.LevelStatusAmt;
    }
}
