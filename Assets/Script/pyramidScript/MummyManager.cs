using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyManager : MonoBehaviour {
   
    public float EffectLengthCounter;
    public float Playerspeed;
    public bool MummyEffectActive;
    public bool effectMode;
    public playercontroller PlayerControllerScript;
    public MummyController MummyControllerScript;

    void Start() 
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<playercontroller>();
        MummyControllerScript = GameObject.Find("Mummy").GetComponent<MummyController>();
    }
    void Update()
    {
       
        if (MummyEffectActive)  
        {
            EffectLengthCounter -= Time.deltaTime;
            if (effectMode)
            {
                PlayerControllerScript.moveSpeed = 0;
                
            }
            if (EffectLengthCounter <= 0)
            {
                MummyEffectActive = false;
            }
        }
    }
    public void ActivateMummyeffect(bool effect, float time)
    {
     
        effectMode = effect;
        EffectLengthCounter = time;
        //Playerspeed = PlayerControllerScript.moveSpeed;
        MummyEffectActive = true;
    }
}
