using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFootController : MonoBehaviour {

    public GameObject BigFootObject;
    [SerializeField]
    private ieBigFootManager ieBigFootManagerScript;
    void Start() 
    {
        ieBigFootManagerScript = GameObject.Find("BigFootManager").GetComponent<ieBigFootManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BigFootObject.SetActive(true);
            ieBigFootManagerScript.isShake = true;
        }  

    }
}
