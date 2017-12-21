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
    int lastTimerTrigged;
    SimpleAd simpleAdScript;
    void Start()
    {
        timerCount = PlayerPrefs.GetInt("timerCount");
        energyLeft = PlayerPrefs.GetInt("energyLeft");
        lvlSelectorScript = GameObject.Find("LevelSelect").GetComponent<Levelselector>();
        egTimeManager = gameObject.GetComponent<EnergyTimeManager>();
        simpleAdScript = GameObject.Find("SimpleAd").GetComponent<SimpleAd>();

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

    public void refillAll()
    {
        PlayerPrefs.SetInt("energyLeft", 5);
        PlayerPrefs.SetInt("timerCount", 0);
        energyLeft = energyMaxValue;
        timerCount = 0;
        egTimeManager.secsLeftEnergy = 0;
        PlayerPrefs.DeleteKey("endTimeEnergy");
        for (int i = 1; i <= energyMaxValue; i++)
        {
            PlayerPrefs.DeleteKey("endTimeed" + i.ToString());
            energyDrinks[i - 1].GetComponent<EnergyTimer>().timerActive = false;
        }
        redisplayTime();

    }

    public void refillAmount()
    {
        simpleAdScript.rewardedAdLvlSelector();

        PlayerPrefs.SetInt("energyLeft", 3);
        PlayerPrefs.SetInt("timerCount", 2);
        energyLeft = 3;
        timerCount = 2;
        egTimeManager.secsLeftEnergy = 0;
        PlayerPrefs.DeleteKey("endTimeEnergy");
        for (int i = energyMaxValue; i >= 3; i--)
        {
            PlayerPrefs.DeleteKey("endTimeed" + i.ToString());
            energyDrinks[i - 1].GetComponent<EnergyTimer>().timerActive = false;
        }
        triggerATimer();
        redisplayTime();
    }





}
