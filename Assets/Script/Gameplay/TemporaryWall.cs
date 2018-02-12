using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TemporaryWall : MonoBehaviour {

    public GameObject _TempWall;
    public bool isActivate;
    private LevelPass LevelPassScript;
    void Awake() 
    {
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        
        if (SceneManager.GetActiveScene().name == "GGGPYRAMID")
        {
            if (LevelPassScript.LevelStatusAmt >= 36)
            {
                isActivate = false;
            }
            if (isActivate)
            {
                _TempWall.SetActive(true);
            }
            else if (!isActivate)
            {
                _TempWall.SetActive(false);
            }
        }
        if (SceneManager.GetActiveScene().name == "GGGPREHISTORIC" || SceneManager.GetActiveScene().name == "GGGICEAGE")
        {
            if (LevelPassScript.LevelStatusAmt >= 36)
            {
                isActivate = false;
            }
            if (isActivate)
            {
                _TempWall.SetActive(true);
            }
            else if (!isActivate)
            {
                _TempWall.SetActive(false);
            }
        }


      
    }


}
