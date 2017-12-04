using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGeneration : MonoBehaviour {

	public GameObject powerupsObject;
	public Transform powerupPoint;
	public float distanceBetween;
	public float PowerupsHeight;
	public floorcounterEl FloorCounterScript;
	public float powerupThreshold;
	public ObjectPooler powerupPooler;
	//
	public int setPowerups;
	public int amountPowerups;

	void Start()
	{
		PowerupsHeight = /*0.34f;*/powerupsObject.GetComponent<BoxCollider2D>().size.y;
		FloorCounterScript = GameObject.Find("player").GetComponent<floorcounterEl>();

	}

	void Update()
	{
		//powerupGeneration
		if (transform.position.y > powerupPoint.position.y) {  
		transform.position = new Vector3 (transform.position.x, transform.position.y + PowerupsHeight + -distanceBetween, 0);
		if (FloorCounterScript.countFloor_el <= FloorCounterScript.halfFloorPoint) {
		    if (Random.Range (0f, 100f) < powerupThreshold) {
		        GameObject newTime = powerupPooler.GetPooledObject ();
		            float debrisXposition = Random.Range (0, 10);
		                Vector3 debrisPosition = new Vector3 (debrisXposition, PowerupsHeight,0f);
		                    newTime.transform.position = transform.position + debrisPosition;
		                    newTime.transform.rotation = transform.rotation;
		                    newTime.SetActive (true);
		                        if (setPowerups == amountPowerups) {
		                            powerupThreshold = 0;
		                                newTime.SetActive (false);
		                                    } else {
		                                        setPowerups++;
		                                             }
				}
			}
		}
		//end
	}

}
