using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ftMainGate : MonoBehaviour {

    [SerializeField]
    private Animator MyAnimationGate1;
    [SerializeField]
    private Animator MyAnimationGate2;
    public bool isGate;

    void Start() 
    {
        MyAnimationGate1 = GameObject.Find("gate1").GetComponent<Animator>();
        MyAnimationGate2 = GameObject.Find("gate2").GetComponent<Animator>();
    }

    void Update() 
    {
        if (isGate)
        {
            MyAnimationGate1.SetBool("isGate1", true);
            MyAnimationGate2.SetBool("isGate2", false);
        }
        else
        {
            MyAnimationGate1.SetBool("isGate1", false);
            MyAnimationGate2.SetBool("isGate2", true);
        }
    }
}
