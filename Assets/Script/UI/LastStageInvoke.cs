using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LastStageInvoke : MonoBehaviour {

    public Button NextBtn;
    public float PosX;
    public RectTransform ListTrans;
    public bool Activate2;
    public bool Activate3;
    public bool Activate4;

    void Awake() 
    {
       
    }
	void Start () 
    {
        ListTrans = GameObject.Find("List").GetComponent<RectTransform>();

        if (PlayerPrefs.GetInt("LastLevelStagePickerSelect") == 1 || PlayerPrefs.GetInt("UnlockLevels") >= 26)
        {
            StartCoroutine(AutoPlay());
            PlayerPrefs.SetInt("LastLevelStagePickerSelect", 0);
        }
        if (PlayerPrefs.GetInt("LastLevelStagePickerSelect") == 2 || PlayerPrefs.GetInt("UnlockLevels") >= 51)
        {
            Activate2 = true;
           
        }
        if (PlayerPrefs.GetInt("LastLevelStagePickerSelect") == 3 || PlayerPrefs.GetInt("UnlockLevels") >= 76)
        {
            Activate3 = true;

        }
        /*if (PlayerPrefs.GetInt("LastLevelStagePickerSelect") == 4 || PlayerPrefs.GetInt("UnlockLevels") >= 101)
        {
            Activate4 = true;

        } */
	}
    void Update()
    {
        PosX = ListTrans.transform.position.x;
        if (Activate2)
        {
            if (PosX < 1300)
            {
                Activate2 = false;
            }
            else
            {
                StartCoroutine(AutoPlay2());
                PlayerPrefs.SetInt("LastLevelStagePickerSelect", 0);
            }
       
        }
        if (Activate3)
        {
            if (PosX < 500)
            {
                Activate3 = false;
            }
            else
            {
                StartCoroutine(AutoPlay2());
                PlayerPrefs.SetInt("LastLevelStagePickerSelect", 0);
            }

        }
        /*if (Activate4)
        {
            if (PosX < -1600)
            {
                Activate3 = false;
            }
            else
            {
                StartCoroutine(AutoPlay3());
                PlayerPrefs.SetInt("LastLevelStagePickerSelect", 0);
            }

        }*/
      
    }

    IEnumerator AutoPlay()
    {
        yield return new WaitForSeconds(0.001f);
        NextBtn.onClick.Invoke();
    }

    IEnumerator AutoPlay2()
    {
        yield return new WaitForSeconds(0.001f);
        NextBtn.onClick.Invoke();

    }
    IEnumerator AutoPlay3()
    {
        yield return new WaitForSeconds(0.001f);
        NextBtn.onClick.Invoke();

    }
  
  
}
