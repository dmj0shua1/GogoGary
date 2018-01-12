using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkThroughWalls : MonoBehaviour {

    public Transform Player;
    public float PosX;
    public float PosX2;
    public float PosY;
    public bool isChange;
    private playercontroller playerControllerScript;

    void Start() 
    {
        isChange = true;
        playerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
    }
    void Update()
    {
        PosY = Player.transform.position.y;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isChange)
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
        else if (!isChange)
        {
            if (other.gameObject.CompareTag("RightWall") && !playerControllerScript.ifRight)
            {
                playerControllerScript.ifRight = true;
            }
            else if (other.gameObject.CompareTag("LeftWall") && playerControllerScript.ifRight)
            {
                playerControllerScript.ifRight = false;
            }
        }
     
    }

 
}
