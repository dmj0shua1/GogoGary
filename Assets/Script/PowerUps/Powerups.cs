using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

	public bool safeMode;
	public float powerupLength;
	private PowerupManager powerupManagerScript;
    AudioSource AudioSourceComponent;
    private PlatformGenerator PlatformGeneratorScript;

	void Start () {
		powerupManagerScript = GameObject.Find ("PowerupManager").GetComponent<PowerupManager> ();
        PlatformGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
      
	}

	void Update () {}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "player") 
		{
			powerupManagerScript.ActivatePowerup (safeMode, powerupLength);
            gameObject.SetActive(false);

        }
        else if (other.gameObject.CompareTag("Hitbox"))
        {
            gameObject.SetActive(false);
            PlatformGeneratorScript.setPowerups = PlatformGeneratorScript.setPowerups - 1;
            PlatformGeneratorScript.ExtraPowerUps();
        }
        /*else if (other.gameObject.CompareTag("debris"))
        {
            gameObject.SetActive(false);
            PlatformGeneratorScript.setPowerups = PlatformGeneratorScript.setPowerups - 1;
            PlatformGeneratorScript.ExtraPowerUps();
        }*/

		
	}
}
