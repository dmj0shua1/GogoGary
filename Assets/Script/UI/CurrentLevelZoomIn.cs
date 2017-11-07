using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentLevelZoomIn : MonoBehaviour {
    public Button SampleButton;
    public int UnlockLevelHolder;
    public RectTransform ScrollRectMap;
    private LevelValueHolder LevelValueHolderScript;
    public bool Isactivate;
    void Awake() 
    {
       
    }
    void Start() 
    {
        UnlockLevelHolder = PlayerPrefs.GetInt("UnlockLevels");

       
    }
    void Update() 
    {
        if (Isactivate)
        {
            SampleButton = GameObject.Find("Building_L" + UnlockLevelHolder).GetComponent<Button>();
            if (SampleButton.interactable == true && SampleButton.gameObject.activeSelf)
            {
                SampleButton.onClick.Invoke();
                Isactivate = false;
                if (UnlockLevelHolder >= 14)
                {
                    ScrollRectMap.GetComponent<RectTransform>().localPosition = new Vector3(-10, -716, 0);
                }
            } 
        }
       
    }
 
}

