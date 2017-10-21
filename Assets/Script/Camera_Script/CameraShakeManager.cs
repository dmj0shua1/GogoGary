using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour {

    private floorcounter FloorCounterScript;
    private CameraShake CameraShakeScript;
   
    public Transform CameraShakePoint;
    public int Counter_Floors;
    public float timeThreshold;
    public bool isShake;

    private testingcamerashake TestingCameraShakeScript;
    private LevelPass LevelPassScript;
    //public GameObject BlackOutObject;
	void Start () {

        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();
        TestingCameraShakeScript = GameObject.Find("camerashaketest").GetComponent<testingcamerashake>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        //BlackOutObject = GameObject.Find("blackout").GetComponent<GameObject>();
        //CameraShakeScript = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        if (LevelPassScript.isShakeActivateAmt == true)
        {
            isShake = true;
            //BlackOutObject.SetActive(true);

        }

	}

	void Update () {
        if (transform.position.y > CameraShakePoint.position.y)
        {
            if (isShake)
            {
                if (Random.Range(0f, 100f) < timeThreshold)
                {
                    TestingCameraShakeScript.IsActiveShake = true;
                    if (TestingCameraShakeScript.shakeDuration == 0)
                    {
                        TestingCameraShakeScript.shakeDuration = 1f;
                    }
                }
                if (FloorCounterScript.countFloor == 5)
                {
                    TestingCameraShakeScript.enabled = false;
                } 
            }
            
        }
	}
}
