using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentLevelZoomIn : MonoBehaviour {
    public Button SampleButton;
    public Button PlayButton;
    public int UnlockLevelHolder;
    public RectTransform ScrollRectMap;
    private LevelValueHolder LevelValueHolderScript;
    private ButtonCameraView ButtonCameraViewScript;
    public bool Isactivate;
    void Awake() 
    {
       
    }
    void Start() 
    {
        ButtonCameraViewScript = GameObject.Find("Main Camera View").GetComponent<ButtonCameraView>();
        UnlockLevelHolder = PlayerPrefs.GetInt("UnlockLevels");
        if (PlayerPrefs.GetInt("CurrentZoom")==0 && UnlockLevelHolder ==1)
        {
            StartCoroutine(AutoPlay());
            //PlayButton.onClick.Invoke();
            //Isactivate = true;
        }
       
    }
    public void CurrentZoomOff() { /*PlayerPrefs.SetInt("CurrentZoom", 0);*/ }
    void Update() 
    {
        if (Isactivate)
        {
            SampleButton = GameObject.Find("Building_L" + UnlockLevelHolder).GetComponent<Button>();
            if (SampleButton.interactable == true && SampleButton.gameObject.activeSelf)
            {
                SampleButton.onClick.Invoke();
                ButtonCameraViewScript.RescueCheckerLevelMethod();
                Isactivate = false;
                if (UnlockLevelHolder >= 14)
                {
                    ScrollRectMap.GetComponent<RectTransform>().localPosition = new Vector3(-10, -716, 0);
                }
            } 
        }
       
    }

    IEnumerator AutoPlay()
    {
        yield return new WaitForSeconds(1.8f);
        PlayButton.onClick.Invoke();
        
    }
 
}

