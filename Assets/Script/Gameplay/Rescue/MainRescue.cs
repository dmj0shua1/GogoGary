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

    ScoreManager scoreManagerScript;
    private LevelPass LevelPassScript;

    void Start() 
    {
        RescueManagerScript = GameObject.Find("RescueManager").GetComponent<RescueManager>();
        PlatformGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
        flrCounterScript = GameObject.Find("player").GetComponent<floorcounterEl>();
        floorDown = GameObject.Find("FloorDown").GetComponent<Text>();
        scoreManagerScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "player")
        {
            gameObject.SetActive(false);
            RescueManagerScript.AddRescuePoint(RescuePointToGive);
            if (SceneManager.GetActiveScene().name == "Endless")
            {
                flrCounterScript.countFloor_el++;
                floorDown.text = flrCounterScript.countFloor_el.ToString();
                scoreManagerScript.rescueCounter++;
            }
            
            
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

    void update()
    {
        if (SceneManager.GetActiveScene().name == "GGGPYRAMID")
        {
            for (int set1 = 26; set1 <= 36; set1++)
            {
                if (LevelPassScript.LevelStatusAmt == set1)
                {
                    
                    //if (PlatformGeneratorScript.SecondFloorNumber == 0 && PlatformGeneratorScript.FirstFloorNumber == 1)
                    //{
                    //    gameObject.SetActive(false);
                    //    PlatformGeneratorScript.SetRescuePoint = PlatformGeneratorScript.SetRescuePoint - 1;
                    //    PlatformGeneratorScript.ExtraRescue();
                    //}
                    //else if (PlatformGeneratorScript.SecondFloorNumber == 1 && PlatformGeneratorScript.FirstFloorNumber == 0)
                    //{
                    //    gameObject.SetActive(false);
                    //    PlatformGeneratorScript.SetRescuePoint = PlatformGeneratorScript.SetRescuePoint - 1;
                    //    PlatformGeneratorScript.ExtraRescue();
                    //}
                    //else if (PlatformGeneratorScript.SecondFloorNumber == 0 && PlatformGeneratorScript.FirstFloorNumber == 2)
                    //{
                    //    gameObject.SetActive(false);
                    //    PlatformGeneratorScript.SetRescuePoint = PlatformGeneratorScript.SetRescuePoint - 1;
                    //    PlatformGeneratorScript.ExtraRescue();
                    //}
                    //else if (PlatformGeneratorScript.SecondFloorNumber == 4 && PlatformGeneratorScript.FirstFloorNumber == 3)
                    //{
                    //    gameObject.SetActive(false);
                    //    PlatformGeneratorScript.SetRescuePoint = PlatformGeneratorScript.SetRescuePoint - 1;
                    //    PlatformGeneratorScript.ExtraRescue();
                    //}
                    //else if (PlatformGeneratorScript.SecondFloorNumber == 0 && PlatformGeneratorScript.FirstFloorNumber == 2)
                    //{
                    //    gameObject.SetActive(false);
                    //    PlatformGeneratorScript.SetRescuePoint = PlatformGeneratorScript.SetRescuePoint - 1;
                    //    PlatformGeneratorScript.ExtraRescue();
                    //}
                    //else if (PlatformGeneratorScript.SecondFloorNumber == 2 && PlatformGeneratorScript.FirstFloorNumber == 1)
                    //{
                    //    gameObject.SetActive(false);
                    //    PlatformGeneratorScript.SetRescuePoint = PlatformGeneratorScript.SetRescuePoint - 1;
                    //    PlatformGeneratorScript.ExtraRescue();
                    //}
                }
            }
           
            
        }
       
       
    }
   
}
