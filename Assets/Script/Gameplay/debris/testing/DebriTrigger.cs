using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebriTrigger : MonoBehaviour {
    [SerializeField]
    private playercontroller playerControllerScript;
    public BoxCollider2D Col1;
    public BoxCollider2D Col2;
    public BoxCollider2D Col3;
    public bool IsTrigger;
    void Awake() 
    {
        IsTrigger = true;
    }
    void Start() 
    {
        playerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
    }
    void Update() 
    {
        if (Col1.enabled == false && Col2.enabled == false)
        {
            StartCoroutine(LoadEnabled());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<Collider2D>().isTrigger = true;
            Col1.enabled = false;
            Col2.enabled = false;
            Col3.enabled = false;
        }
         
      
    }
    IEnumerator LoadEnabled()
    {
        yield return new WaitForSeconds(0.300f);
        Col1.enabled = true;
        Col2.enabled = true;
        Col3.enabled = true;
       
    }
}
