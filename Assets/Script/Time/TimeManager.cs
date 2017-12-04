using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;
	public float countingTime;
	public float recordTime;
	private Text theText;

	//hourglass
	//public float plustime;
	//private bool timeActive;

	private playercontroller PlayerControllerScript;
    //private floorcounter FloorCounterScript;
	//stoptime
	public bool isStopMainTime;
    //public float EndAnimation;
	//Coroutine
	private IEnumerator coroutine;
    private FireAi FireAiScript;

    public Animator MyAnimation;
    public GameObject BlackoutObject;
    public bool check;
    public int WarningCount;
    //private FireAi FireAiScripting;
    public AudioSource AlarmSound;
	void Start () {
		theText = GetComponent<Text>();
		countingTime = startingTime;
		/*PlayerControllerScript = GameObject.Find ("player").GetComponent<playercontroller> ();*/
        //FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();
        //FireAiScripting = GameObject.Find("Fire").GetComponent<FireAi>();
        FireAiScript = GameObject.Find("Fire").GetComponent<FireAi>();
        MyAnimation = /*GameObject.Find("blackout").*/ BlackoutObject.GetComponent<Animator>();
        theText.text = "" + startingTime;
        check = true;
		}
  
    void Update()
	{
			if (isStopMainTime) 
			{ 
                countingTime -= Time.deltaTime;
				 if (countingTime <= WarningCount) {
                 
                   // BlackoutObject.SetActive(true);
                   // MyAnimation.SetBool("IsIdle",true);
                }
             
             
			}
	}
}
