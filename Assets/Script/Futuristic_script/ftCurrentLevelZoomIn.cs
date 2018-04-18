using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ftCurrentLevelZoomIn : MonoBehaviour {
    public Button SampleButton;
    public Button PlayButton;
    public int UnlockLevelHolder;
    public RectTransform ScrollRectMap;
    private LevelValueHolder LevelValueHolderScript;
    private ieButtonCameraView ButtonCameraViewScript;
    public bool Isactivate;
    void Awake() 
    {
        if (PlayerPrefs.GetInt("OpenStageFuturistic") == 1)
        {
            Isactivate = true;
        }
    }
    void Start() 
    {
        ButtonCameraViewScript = GameObject.Find("Main Camera View").GetComponent<ieButtonCameraView>();
        UnlockLevelHolder = PlayerPrefs.GetInt("UnlockLevels");
        if (PlayerPrefs.GetInt("OpenStageFuturistic") == 1)
        {
            Isactivate = true;
        }
        /*if (PlayerPrefs.GetInt("CurrentZoom")==0 && UnlockLevelHolder ==1)
        {
            StartCoroutine(AutoPlay());
            //PlayButton.onClick.Invoke();
            //Isactivate = true;
        }*/
       
       
    }
    public void CurrentZoomOff() { /*PlayerPrefs.SetInt("CurrentZoom", 0);*/ }
    void Update() 
    {
        if (Isactivate)
        {
            SampleButton = GameObject.Find("ftBuilding_L" + UnlockLevelHolder).GetComponent<Button>();
            if (SampleButton.interactable == true && SampleButton.gameObject.activeSelf)
            {
                SampleButton.onClick.Invoke();
                ButtonCameraViewScript.RescueCheckerLevelMethod();
                Isactivate = false;
                if (UnlockLevelHolder >= 88)
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

