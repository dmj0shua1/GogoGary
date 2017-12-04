using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCameraCollider : MonoBehaviour {
    public BoxCollider2D Col1;
    private floorcounterEl FloorCounterScript;
 
	// Use this for initialization
	void Start () {
        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounterEl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (FloorCounterScript.countFloor_el ==2)
        {
            Col1.enabled = false;  
        }
	}
}
