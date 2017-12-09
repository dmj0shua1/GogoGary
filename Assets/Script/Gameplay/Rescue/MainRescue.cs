using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainRescue : MonoBehaviour {

    public int RescuePointToGive;
    private RescueManager RescueManagerScript;
    private PlatformGenerator PlatformGeneratorScript;
    private floorcounterEl flrCounterScript;
    Text floorDown;

    void Start() 
    {
        RescueManagerScript = GameObject.Find("RescueManager").GetComponent<RescueManager>();
        PlatformGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
        flrCounterScript = GameObject.Find("player").GetComponent<floorcounterEl>();
        floorDown = GameObject.Find("FloorDown").GetComponent<Text>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "player")
        {
            if (SceneManager.GetActiveScene().name == "Endless")
            {
                flrCounterScript.countFloor_el++;
                floorDown.text = flrCounterScript.countFloor_el.ToString();
            }
            RescueManagerScript.AddRescuePoint(RescuePointToGive);
            gameObject.SetActive(false);
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
