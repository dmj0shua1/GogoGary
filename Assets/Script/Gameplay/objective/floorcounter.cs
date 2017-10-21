using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class floorcounter : MonoBehaviour {

    public int MainCount;
	public int countFloor;
	public int CameraStopPoint;
	public int floorObjective;
	public int halfFloorPoint;
	public Text theText;

    public bool isActive;
    public bool isNoFunction;
    [Header("CountFloors")]
    public int CountFloorPlus;
    public int CheckCountPlus;
    private DebriTrigger DebriTriggerScript;
    void Start() 
    {
        countFloor = MainCount;
        theText.text = "" + MainCount; 

    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (isNoFunction)
        {
            if (other.gameObject.CompareTag("floor"))
            {
                    isActive = true;
                    countFloor--;
                    CountFloorPlus++;
                    theText.text = " " + Mathf.Round(countFloor);
                    DebriTriggerScript = other.gameObject.GetComponent<DebriTrigger>();
                    DebriTriggerScript.IsTrigger = false;
                }
            }
        }
    }
  
		

