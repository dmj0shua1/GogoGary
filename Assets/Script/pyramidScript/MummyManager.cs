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
    [SerializeField]
    private LevelPass LevelPassScript;
    [SerializeField]
    private PlatformGenerator PlatformGeneratorScript;

    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<playercontroller>();
        MummyControllerScript = GameObject.Find("Mummy").GetComponent<MummyController>();
        PlatformGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
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

    /*public void MummyActivation() 
    {
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        if (LevelPassScript.LevelStatusAmt >= 31)
            {
                PlatformGeneratorScript.IsGenerateMummy = true;
            }
    }*/

    public void MummyThreshold() 
    {
 
    }
}
