using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMovement : MonoBehaviour {

    private playercontroller ThePlayer;
    debriZone DebriZoneScript;
    public Animator MyAnimation;
    public bool DestroyBool;
    public bool isDebriGround;
    void Start()
    {
        ThePlayer = GameObject.Find("player").GetComponent<playercontroller>();
        MyAnimation = GetComponent<Animator>();
    }

    void Update() 
    {
        if (GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
        {
            isDebriGround = true;
        }
    }
 
            
    void OnTriggerStay2D(Collider2D other)
    {
       
        if (other.name == "player")
        {
            ThePlayer.OnDebris = true;
           
            if (ThePlayer.addStar == true && isDebriGround ==true)
            {
                MyAnimation.SetBool("DestroyDeb",!DestroyBool);
                StartCoroutine(debridestrowithstar());
            }
        }
      
       
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "player")
        {
            ThePlayer.OnDebris = false;
        }
    }
    IEnumerator debridestrowithstar()
    {
        yield return new WaitForSeconds(0.400f);
        gameObject.SetActive(false);
        ThePlayer.addStar2 = true;
    }
}
