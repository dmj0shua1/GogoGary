using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phBirdController : MonoBehaviour {

    private playercontroller ThePlayer;

    public float moveSpeed;
    public float playerRange;

    public LayerMask playerLayer;
    
    public bool playerInRange;
    public bool facingAway;
    public bool followOnLookAway;
    public bool On;

    void Start() 
    {
        ThePlayer = FindObjectOfType<playercontroller>();
    }

    void Update() 
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        
        if (!followOnLookAway)
        {
            if (playerInRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, moveSpeed * Time.deltaTime);
                return;
            }
        }

        if ((ThePlayer.transform.position.x < transform.position.x && ThePlayer.transform.localScale.x < 0) || (ThePlayer.transform.position.x > transform.position.x && ThePlayer.transform.localScale.x > 0))
        {
            facingAway = true;
        }
        else
        {
            facingAway = false;
        }

        if (playerInRange && facingAway)
        {
            transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, moveSpeed * Time.deltaTime);
          
        }
    }

    void OnDrawGizmosSelected()
    {
        if (On)
        {
            Gizmos.DrawSphere(transform.position, playerRange);
        }
     
    }
}
