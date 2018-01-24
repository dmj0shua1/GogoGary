using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhBirdManager : MonoBehaviour {
   
    public float EffectLengthCounter;
    public float Playerspeed;
    public bool birdEffectActive;
    public bool effectMode;
    public playercontroller PlayerControllerScript;
    public phBirdController phBirdControllerScript;
    private LevelPass LevelPassScript;
    private PlatformGenerator PlatformGeneratorScript;


    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<playercontroller>();
        phBirdControllerScript = GameObject.Find("PhBird").GetComponent<phBirdController>();
        PlatformGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
    }  
    void Update()
    {
       
        if (birdEffectActive)  
        {
            EffectLengthCounter -= Time.deltaTime;
            if (effectMode)
            {
                PlayerControllerScript.moveSpeed = 0;
                
            }
            if (EffectLengthCounter <= 0)
            {
                birdEffectActive = false;
               
            }
        }
    }
    public void ActivateBirdeffect(bool effect, float time)
    {
     
        effectMode = effect;
        EffectLengthCounter = time;
        birdEffectActive = true;
    }

 

    public void MummyThreshold() 
    {
    
    }
}
