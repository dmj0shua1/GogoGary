using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ftboltMain : MonoBehaviour {

    private playercontroller playerControllerScript;

    public bool BoltEffect;
    public bool BoltEffect2;
	void Start () {
        playerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
        BoltEffect2 = true;
	}
	
	void Update () {

        if (BoltEffect)
        {
            playerControllerScript.Player_Gary.bodyType = RigidbodyType2D.Static;
            StartCoroutine(BoltEffectTimer());
        }
        else if (!BoltEffect)
        {
            playerControllerScript.Player_Gary.bodyType = RigidbodyType2D.Dynamic;
            BoltEffect2 = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("trap1"))
        {
            if (BoltEffect2)
            {
                BoltEffect = true; 
            }
             
        }
    }

    IEnumerator BoltEffectTimer()
    {
        yield return new WaitForSeconds(0.8f);
        BoltEffect = false;
        BoltEffect2 = false;
    }
}
