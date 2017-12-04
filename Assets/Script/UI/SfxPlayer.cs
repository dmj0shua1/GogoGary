using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour {
    
    public GameObject objSoundSource;
    private AudioSource asSfx;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playSfx()
    {

        if (PlayerPrefs.GetInt("SoundChecker") == 0)
        {
            asSfx = objSoundSource.GetComponent<AudioSource>();
            asSfx.Play();
        }
        
           
    }
}
