using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	

	public Transform target;
	public float Y;


	void Update () 
	{
		transform.position = new Vector3(transform.position.x, target.position.y + Y,-2);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		
	}
}
