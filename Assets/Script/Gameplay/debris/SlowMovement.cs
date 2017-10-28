using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMovement : MonoBehaviour {

    private playercontroller ThePlayer;
    public Animator MyAnimation;
    public bool DestroyBool;
    void Start()
    {
        ThePlayer = GameObject.Find("player").GetComponent<playercontroller>();
        MyAnimation = GetComponent<Animator>();
    }

    void Update() 
    {
       
    }
 
            
             //MyAnimation.SetBool("DestroyDeb", !DestroyBool);
             //DestroyBool = true;
        
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "player")
        {
            ThePlayer.OnDebris = true;
           
            if (ThePlayer.addStar == true)
            {
                MyAnimation.SetBool("DestroyDeb",!DestroyBool);
                //StartCoroutine(debridestrowithstar());
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
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
