using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour {

	// Use this for initialization
	void Start () {
       	
	}
    public void pause() 
    {
        Time.timeScale = 0f;
    }

    public void Resume() 
    {
        Time.timeScale = 1f;
    
    }
}
