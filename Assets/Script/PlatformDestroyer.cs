using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestructionPoint;

	void Start()
	{
		platformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");
	}
	void Update()
	{
		if (transform.position.y > platformDestructionPoint.transform.position.y){
			gameObject.SetActive(false);}
	}
}
