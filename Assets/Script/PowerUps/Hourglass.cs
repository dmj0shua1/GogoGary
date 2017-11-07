using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hourglass : MonoBehaviour {

	public float SpeedTimeLength;
    public float AddSpeed;
    public bool speedMode;
    private PlusSpeedManager PlusSpeedManagerScript;

	void Start () {
		PlusSpeedManagerScript = GameObject.Find ("plusspeedManager").GetComponent<PlusSpeedManager> ();
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {

        if (other.name == "player")
        {
            PlusSpeedManagerScript.Add_speed_time(speedMode, SpeedTimeLength, AddSpeed);
            gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Hitbox"))
        {
            gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Powerup"))
        {
            gameObject.SetActive(false);
        }
		
	}
}
