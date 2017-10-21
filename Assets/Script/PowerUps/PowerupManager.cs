using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerupManager : MonoBehaviour {

    private bool safeMode;
	public bool powerupActive;

	private float poweruplengthCounter;
	private float PlayerSpeed;
	public playercontroller PlayerScript;

	public Text poweruptext;
    //testing
   
	void Start () {
		PlayerScript = GameObject.Find("player").GetComponent<playercontroller>();
      
	}

	void Update () 
	{
		if (powerupActive) 
		{
			poweruplengthCounter -= Time.deltaTime;
			poweruptext.text = " " + Mathf.Round(poweruplengthCounter);

			if (safeMode) 
			{
				PlayerScript.DecreaseSpeed = PlayerScript.moveSpeed;
              
			}

			if (poweruplengthCounter <= 0) 
			{
               
				PlayerScript.DecreaseSpeed = PlayerSpeed;
				powerupActive = false;
			}
          
		}
	}

	public void ActivatePowerup(bool safe, float time)
	{
		safeMode = safe;
		poweruplengthCounter = time;
		PlayerSpeed = PlayerScript.DecreaseSpeed;
		powerupActive = true;
        
	}
}
