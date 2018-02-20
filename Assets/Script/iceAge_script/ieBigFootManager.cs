using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ieBigFootManager : MonoBehaviour {
    
    [SerializeField]
    private testingcamerashake TestingCameraShakeScript;
    public bool isShake;
    public playercontroller PlayerControllerScript;

	void Start () {
        TestingCameraShakeScript = GameObject.Find("camerashaketest").GetComponent<testingcamerashake>();
        PlayerControllerScript = GameObject.Find("Player").GetComponent<playercontroller>();
	}
	

	void Update () {
        if (isShake)
        {
            TestingCameraShakeScript.IsActiveShake = true;
            if (TestingCameraShakeScript.shakeDuration == 0)
            {
                TestingCameraShakeScript.shakeDuration = 1f;
               
            }
            PlayerControllerScript.moveSpeed = 10;
            StartCoroutine(isCollideTime());
        }
        if (!isShake)
        {
            //PlayerControllerScript.moveSpeed = PlayerControllerScript.currentSpeed;
        }
       
	}

    IEnumerator isCollideTime()
    {
        yield return new WaitForSeconds(3f);
        isShake = false;
        PlayerControllerScript.moveSpeed = PlayerControllerScript.currentSpeed;
 
    }
}
