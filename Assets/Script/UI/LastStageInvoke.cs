using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LastStageInvoke : MonoBehaviour {

    public Button NextBtn;
    public float PosX;
    public RectTransform ListTrans;
    public bool Activate2;
	void Start () 
    {
        ListTrans = GameObject.Find("List").GetComponent<RectTransform>();
       
        if (PlayerPrefs.GetInt("LastLevelStagePickerSelect") == 1)
        {
            StartCoroutine(AutoPlay());
            PlayerPrefs.SetInt("LastLevelStagePickerSelect", 0);
        }
        if (PlayerPrefs.GetInt("LastLevelStagePickerSelect") == 2)
        {
            Activate2 = true;
           
        }
      
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
  
}
