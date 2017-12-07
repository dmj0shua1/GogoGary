using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryWall : MonoBehaviour {

    public GameObject _TempWall;
    public bool isActivate;
    void Awake() 
    {
        isActivate = true;
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
