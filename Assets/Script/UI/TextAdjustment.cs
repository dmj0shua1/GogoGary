using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAdjustment : MonoBehaviour {

    public RectTransform _transformText;
    public float PosX;
    public float PosY;

    void Start() 
    {
        if (PlayerPrefs.GetInt("LanguageNumber") == 1)
        {
            _transformText.position = new Vector3(PosX, PosY, 0);
        }
       
    }
}
