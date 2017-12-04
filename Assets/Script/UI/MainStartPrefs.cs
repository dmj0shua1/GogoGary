using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStartPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("Stage2Checker")) PlayerPrefs.SetInt("Stage2Checker", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
