using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class floorcounterEl : MonoBehaviour {

    public int MainCount_el;
	public int countFloor_el;
	public int CameraStopPoint;
	public int floorObjective;
	public int halfFloorPoint;
	public Text theText_el;

    public bool isActive_el;
    public bool isNoFunction_el;
    [Header("CountFloors")]
    public int CountFloorPlus_el;
    public int CheckCountPlus;
    private DebriTrigger DebriTriggerScript_el;
    [Header("NewRescuePointGeneration")]
    public int MainFloorHolderDivided;
    public int MainFloorDecreaseDivided;
    private FireAi fireAiScript;
    private DifficultyManager diffManagerScript;
    public bool IsStopFire;

    void Start() 
    {
        countFloor_el = MainCount_el;
        theText_el.text = "" + MainCount_el;
        fireAiScript = GameObject.Find("Fire").GetComponent<FireAi>();
        diffManagerScript = GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>();
        //MainFloorHolderDivided = MainCount / 7;
        //MainFloorDecreaseDivided = MainFloorHolderDivided;


    }

    void Update()
    {
        if (countFloor_el == 2 && !IsStopFire)
        {
            fireAiScript.StartFire = true;
            IsStopFire = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (isNoFunction_el)
        {
            if (other.gameObject.CompareTag("floor"))
            {
                    other.gameObject.tag = "Untagged"; 
                    isActive_el = true;
                    countFloor_el++;
                    CountFloorPlus_el++;
                    //MainFloorDecreaseDivided--;
                    theText_el.text = Mathf.Round(countFloor_el).ToString();
                    DebriTriggerScript_el = other.gameObject.GetComponent<DebriTrigger>();
                    DebriTriggerScript_el.IsTrigger = false;
                    diffManagerScript.checkScore();
                }
            }
        }
    }
  
		

