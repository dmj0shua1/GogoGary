using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlusSpeedManager : MonoBehaviour {

    public bool speedMode;
    public bool addSpeedActive;

    public float AddSpeed;
    public float SpeedTimeLength;
    private float PlayerSpeed;
    public playercontroller PlayerScript;

    void Start()
    {
        PlayerScript = GameObject.Find("player").GetComponent<playercontroller>();
    }
    void Update()
    {
        if (addSpeedActive)
        {
            SpeedTimeLength -= Time.deltaTime;

            if (speedMode)
            {
                PlayerScript.moveSpeed = PlayerScript.moveSpeed + AddSpeed;
            
           }
           if (SpeedTimeLength <= 0)
            {
                SpeedTimeLength = 0;
                addSpeedActive = false;
            }  
        }
    }
 
    public void Add_speed_time (bool speed, float time, float add)
    {
        AddSpeed = add;
        speedMode = speed;
        SpeedTimeLength = time;
        PlayerSpeed = PlayerScript.moveSpeed;
        addSpeedActive = true;
    }

}
