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
    }
}
