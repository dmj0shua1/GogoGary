using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : MonoBehaviour {

    public float _moveSpeed;
    public bool _ground;
    public bool moveRight;

    public Transform WallChecker;
    public float wallCheckRadius;
    public LayerMask WhatisWall;
    private bool HittingWall;

    private bool HittingEdge;
    public Transform EdgeChecker;

    [Header("MummyManager")]

    public bool IsMove;
    public Rigidbody2D MummyRigid;
    public Collider2D MummyMainCollider;

    [Header("MummyEffect")]
    public Rigidbody2D PlayerRigid;
    public playercontroller PlayerControllerScript;
    public MummyManager MummyManagerScript;
    public float EffectLengthCounter;
    public bool effectMode;

    void Start() 
    {
        PlayerRigid = GameObject.Find("player").GetComponent<Rigidbody2D>();
        PlayerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
        MummyManagerScript = GameObject.Find("MummyManager").GetComponent<MummyManager>();
    }

    void Update() 
    {
        HittingWall = Physics2D.OverlapCircle(WallChecker.position, wallCheckRadius, WhatisWall);
        HittingEdge = Physics2D.OverlapCircle(EdgeChecker.position, wallCheckRadius, WhatisWall);

        if (HittingWall || !HittingEdge) 
            moveRight = !moveRight; 
               

            if (moveRight)
            {
                transform.localScale = new Vector3(-24f, 30f, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(_moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            }
            else if (!moveRight)
            {
                transform.localScale = new Vector3(24f, 30f, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-_moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            }     
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Hitbox"))
        {
            
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            MummyMainCollider.enabled = false;
            MummyManagerScript.ActivateMummyeffect(effectMode,EffectLengthCounter);
            _moveSpeed = 0;

        }

        if (other.gameObject.CompareTag("StopCamera"))
        {

            gameObject.SetActive(false);
        }
      
    }



    void OnTriggerExit2D(Collider2D other)
    {
        _moveSpeed = 3;
    }
   

}
