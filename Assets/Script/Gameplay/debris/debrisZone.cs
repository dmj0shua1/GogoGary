using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisZone : MonoBehaviour {

	public Collider2D deb;
    public Collider2D MainDebCollider;
	public GameObject debrisPoint;
	public Rigidbody2D DebrisBodyType;
    [SerializeField]
    private DebriTrigger DebriTriggerScript;
    public SpriteRenderer debriSpriteRenderer;
    void Awake() 
    {
        
        //DebriTriggerScript = GameObject.FindGameObjectWithTag("floor").GetComponent<DebriTrigger>();
    }
    void Start() 
    {
       
    }
    void Update() 
    {
    }
	void OnTriggerEnter2D(Collider2D other)
    {
        DebriTriggerScript = other.gameObject.GetComponent<DebriTrigger>();
        if (other.CompareTag("floor")&& DebriTriggerScript.IsTrigger==true)
        {
           
            if (DebriTriggerScript.IsTrigger)
            {
              MainDebCollider.enabled= true;
              deb.enabled = false;
              DebrisBodyType.bodyType = RigidbodyType2D.Static;
              //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }

        }

       
	}
  
    void OnTriggerExit2D(Collider2D other) 
    {
        
        if (other.CompareTag("Hitbox"))
        {
            DebriTriggerScript = other.gameObject.GetComponent<DebriTrigger>();
                //DebriTriggerScript = other.gameObject.GetComponent<DebriTrigger>();
                //DebriTriggerScript.Col1.enabled = true;   
        }
    }
}
