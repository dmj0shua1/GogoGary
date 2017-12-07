using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCameraCollider : MonoBehaviour {
    public BoxCollider2D Col1;
    private floorcounter FloorCounterScript;
 
	// Use this for initialization
	void Start () {
        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();
	}
	
	// Update is called once per frame
	void Update () {
        if (FloorCounterScript.countFloor ==2)
        {
            Col1.enabled = false;  
        }
	}
}
