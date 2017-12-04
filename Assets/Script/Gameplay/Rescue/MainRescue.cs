using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainRescue : MonoBehaviour {

    public int RescuePointToGive;
    private RescueManager RescueManagerScript;
    private PlatformGenerator PlatformGeneratorScript;
    private floorcounterEl floorcounterElScript;
    public Text theText_el;
    void Start() 
    {
        RescueManagerScript = GameObject.Find("RescueManager").GetComponent<RescueManager>();
        PlatformGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
        floorcounterElScript = GameObject.Find("player").GetComponent<floorcounterEl>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "player")
        {
            RescueManagerScript.AddRescuePoint(RescuePointToGive);
            gameObject.SetActive(false);
            floorcounterElScript.countFloor_el++;
            theText_el.text = floorcounterElScript.countFloor_el.ToString();
           
        }
        else if (other.gameObject.CompareTag("Hitbox"))
        {
            gameObject.SetActive(false);
            PlatformGeneratorScript.SetRescuePoint = PlatformGeneratorScript.SetRescuePoint - 1;
            PlatformGeneratorScript.ExtraRescue();
        }
        else if (other.gameObject.CompareTag("HitBoxCam"))
        {
           gameObject.SetActive(false);
            //PlatformGeneratorScript.SetRescuePoint = PlatformGeneratorScript.SetRescuePoint - 1;
        }
          
    }
   
}
