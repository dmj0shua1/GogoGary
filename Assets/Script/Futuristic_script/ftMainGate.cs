using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ftMainGate : MonoBehaviour {

    [SerializeField]
    private Animator MyAnimationGate1;
    public bool isGate;
    void Start() 
    {
        MyAnimationGate1 = GameObject.Find("ftGateMain").GetComponent<Animator>();
      
    }

    void Update() 
    {
        if (isGate)
        {
            MyAnimationGate1.SetBool("isLeftOpen", true);
            MyAnimationGate1.SetBool("isRightOpen", false);
        }
        else
        {
            MyAnimationGate1.SetBool("isLeftOpen", false);
            MyAnimationGate1.SetBool("isRightOpen", true);

        }
        if (isGate)
        {
            StartCoroutine(changegate2());
        }
        else if (!isGate)
        {
            StartCoroutine(changegate1());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.CompareTag("HitBoxCam"))
        {
           gameObject.SetActive(false);
        }  
    }

    IEnumerator changegate1()
    {
        yield return new WaitForSeconds(2);
        isGate = true;
    }

    IEnumerator changegate2()
    {
        yield return new WaitForSeconds(2);
        isGate = false;
    }
}
