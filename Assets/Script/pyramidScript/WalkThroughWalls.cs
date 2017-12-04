using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkThroughWalls : MonoBehaviour {

    public Transform Player;
    public float PosX;
    public float PosX2;
    public float PosY;

    void Update()
    {
        PosY = Player.transform.position.y;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RightWall"))
        {
            transform.position = new Vector3(PosX2, PosY, 0);
        }
        else if (other.gameObject.CompareTag("LeftWall"))
        {
            transform.position = new Vector3(PosX, PosY, 0);
        }
    }

 
}
