using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFootController : MonoBehaviour {

    public GameObject BigFootObject;
    [SerializeField]
    private ieBigFootManager ieBigFootManagerScript;
    public Animator BigFootBackAnim;
    public bool isEnabled;
    public AudioSource BigFootSfx;
    void Start() 
    {
        ieBigFootManagerScript = GameObject.Find("BigFootManager").GetComponent<ieBigFootManager>();
        BigFootBackAnim = GameObject.Find("ieBigFoot").GetComponent<Animator>();
    }
    void Update() 
    {
        //if (isAnimate)
       // {
           // BigFootBackAnim.SetBool("isBack", false);
        //}
        if (isEnabled)
        {
            StartCoroutine(isCollideEnabled());
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BigFootObject.SetActive(true);
            ieBigFootManagerScript.isShake = true;
            StartCoroutine(isCollideTime());
        }  

    }

   
    IEnumerator isCollideTime()
    {
        yield return new WaitForSeconds(3f);
        BigFootBackAnim.SetBool("isBack", false);
        BigFootSfx.volume = (0.020f);
        isEnabled = true;

    }
    IEnumerator isCollideEnabled()
    {
        yield return new WaitForSeconds(3f);
        BigFootObject.SetActive(false);
        BigFootSfx.enabled = false;

    }
}
