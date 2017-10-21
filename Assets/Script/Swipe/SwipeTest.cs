using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour {
	
	public SwipeManager swipeControls;

	public Transform player;
	public float moveSpeed;

	playercontroller PlayerScript;

	private bool ifRight;
	private bool Check1;
    
    public bool isSwipe;

	void Start ()
	{
		PlayerScript = GameObject.Find ("player").GetComponent<playercontroller> ();
	}

	void Update () 
	{
        if (isSwipe)
        {
            if (swipeControls.SwipeLeft || swipeControls.SwipeRight) PlayerScript.Check1 = true;
            if (swipeControls.SwipeLeft) PlayerScript.ifRight = true;
            else if (swipeControls.SwipeRight) PlayerScript.ifRight = false;
        }
		
	}

}
