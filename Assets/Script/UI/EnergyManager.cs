using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{

    // Use this for initialization
    public int energyLeft, energyMaxValue;
    [SerializeField]
    public GameObject[] energyDrinks;
    [Space]
    [SerializeField]
    Sprite energySpriteColored;
    [SerializeField]
    Sprite energySpriteFaded;
    Levelselector lvlSelectorScript;
    [Space]
    [SerializeField]
    string sceneToGo;
    EnergyTimeManager egTimeManager;
    public int timerCount;
    void Start()
    {
        timerCount = PlayerPrefs.GetInt("timerCount");
        energyLeft = PlayerPrefs.GetInt("energyLeft");
        lvlSelectorScript = GameObject.Find("LevelSelect").GetComponent<Levelselector>();
        egTimeManager = gameObject.GetComponent<EnergyTimeManager>();

        if (!PlayerPrefs.HasKey("energyLeft")) PlayerPrefs.SetInt("energyLeft", 5);
        

        energyInitialize();

        if (!PlayerPrefs.HasKey("timerCount")) PlayerPrefs.SetInt("timerCount", 0);
        

        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void decreaseEnergy()
    {
        if (energyLeft > 0)
        {
            energyLeft--;
            PlayerPrefs.SetInt("energyLeft", energyLeft);
            redisplayTime();
            triggerATimer();

        }
    }

    public void redisplayTime()
    {
        if (energyLeft <= energyMaxValue)
        {
            energyLeft = PlayerPrefs.GetInt("energyLeft");
            int energyCheck = 0;

            while (energyCheck < energyMaxValue)
            {
                energyDrinks[energyCheck].GetComponent<Image>().sprite = energySpriteColored;
                energyCheck++;
            }

            while (energyCheck > energyLeft)
            {
                energyCheck--;
                energyDrinks[energyCheck].GetComponent<Image>().sprite = energySpriteFaded;
            }
        }
    }

    private void energyInitialize()
    {
        if (energyLeft <= energyMaxValue)
        {

            redisplayTime();
          //  egTimeManager.saveEnergyTime();


        }

    }

    public void increaseEnergy()
    {
        if (energyLeft < energyMaxValue)
        {
            energyLeft++;
            PlayerPrefs.SetInt("energyLeft", energyLeft);
            energyInitialize();
        }
    }


    public void playGame()
    {
        energyLeft = PlayerPrefs.GetInt("energyLeft");
        if (energyLeft > 0)
        {
            //play
            decreaseEnergy();
            lvlSelectorScript.selectstring(sceneToGo);
        }
        else
        {
            //note that you cant play
        }
    }

    public void triggerATimer()
    {
        if (energyLeft < energyMaxValue)
        {
            for (int i = 0; i < (energyMaxValue - energyLeft); i++)
            {

                EnergyTimer egTimer = energyDrinks[i].GetComponent<EnergyTimer>();

                if (!egTimer.timerActive && timerCount < (energyMaxValue-energyLeft))
                {
                    egTimer.timerActive = true;
                       egTimeManager.saveEnergyTime();
                    egTimer.startTimer();
                    timerCount++;
                    PlayerPrefs.SetInt("timerCount", (PlayerPrefs.GetInt("timerCount")+1));
                    break;
                }
            }

        }
    }





}
