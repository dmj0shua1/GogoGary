using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeColor : MonoBehaviour {

    [SerializeField]
    private LevelPass MainHolderScript;

    public Color CameraColorHolder;
    public Camera GameCamera;
    void Start() 
    {
        MainHolderScript = GameObject.Find("Holder").GetComponent<LevelPass>();

       CameraColorHolder = MainHolderScript.CameraColorAmt;
       GameCamera.backgroundColor = CameraColorHolder;
    }
}
