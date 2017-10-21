using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour {

	public GameObject wall;
	public Transform wallGenerationPoint;
	public float distanceBetween;
	public ObjectPooler theObjectPools;
	void Start () {
		
	}
	

	void Update () 
	{
		if (transform.position.y > wallGenerationPoint.position.y) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + -distanceBetween, 0);		
			GameObject newWall = theObjectPools.GetPooledObject ();
			newWall.transform.position = transform.position;
			newWall.transform.rotation = transform.rotation;
			newWall.SetActive (true);
		}
	}

}
