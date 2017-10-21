using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

	public bool safeMode;
	public float powerupLength;
	private PowerupManager powerupManagerScript;
    AudioSource AudioSourceComponent;

	void Start () {
		powerupManagerScript = GameObject.Find ("PowerupManager").GetComponent<PowerupManager> ();
      
	}

	void Update () {}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "player") 
		{
			powerupManagerScript.ActivatePowerup (safeMode, powerupLength);
            gameObject.SetActive(false);
            
		}
		
	}
}
