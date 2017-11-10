using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRescue : MonoBehaviour {

    public int RescuePointToGive;
    private RescueManager RescueManagerScript;
    private PlatformGenerator PlatformGeneratorScript;

    void Start() 
    {
        RescueManagerScript = GameObject.Find("RescueManager").GetComponent<RescueManager>();
        PlatformGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "player")
        {
            RescueManagerScript.AddRescuePoint(RescuePointToGive);
            gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Hitbox"))
        {
            gameObject.SetActive(false);
            PlatformGeneratorScript.SetRescuePoint = PlatformGeneratorScript.SetRescuePoint - 1;
        }
        else if (other.gameObject.CompareTag("HitBoxCam"))
        {
           gameObject.SetActive(false);
            //PlatformGeneratorScript.SetRescuePoint = PlatformGeneratorScript.SetRescuePoint - 1;
        }
          
    }
   
}
