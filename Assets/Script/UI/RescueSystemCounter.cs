using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RescueSystemCounter : MonoBehaviour {
    public Text RescueNumCounterText;
    void Awake() 
    {
        RescueNumCounterText.text = "" + (PlayerPrefs.GetInt("TotalRescuePoints"));
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
