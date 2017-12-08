using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryWall : MonoBehaviour {

    public GameObject _TempWall;
    public bool isActivate;
    private LevelPass LevelPassScript;
    void Awake() 
    {
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        if (LevelPassScript.LevelStatusAmt >= 31)
        {
            isActivate = false;
        }
        if (isActivate)
        {
            _TempWall.SetActive(true);
        }
        else if(!isActivate)
        {
            _TempWall.SetActive(false);
        }
    }


}
