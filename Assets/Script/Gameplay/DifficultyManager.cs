﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    [Header("Debris")]
    [SerializeField]
    private int debrisInitialAmt;
    [SerializeField]
    private int debrisStartAt;
    [Space]
    [SerializeField]
    private int debrisDiffFrequency;
    [SerializeField]
    private int debrisIncreaseAmt;
    [SerializeField]
    private int debrisAmountLimit;
    [SerializeField]
    private int debrisDiffCounter;
    [Space]
    [Header("Bolt")]
    [SerializeField]
    private int boltInitialAmt;
    [SerializeField]
    private int boltStartAt;
    [Space]
    [SerializeField]
    private int boltDiffFrequency;
    [SerializeField]
    private int boltIncreaseAmt;
    [SerializeField]
    private int boltAmountLimit;
    [SerializeField]
    private int boltDiffCounter;
    [Space]
    [Header("Powerup")]
    [SerializeField]
    private int powerupInitialAmt;
    [SerializeField]
    private int powerupStartAt;
    [Space]
    [SerializeField]
    private int powerupDiffFrequency;
    [SerializeField]
    private int powerupIncreaseAmt;
    [SerializeField]
    private int powerupAmountLimit;
    [SerializeField]
    private int powerupDiffCounter;
    [Space]
    [Header("Rescue")]
    [SerializeField]
    private int rescueInitialAmt;
    [SerializeField]
    private int rescueStartAt;
    [Space]
    [SerializeField]
    private int rescueDiffFrequency;
    [SerializeField]
    private int rescueIncreaseAmt;
    [SerializeField]
    private int rescueAmountLimit;
    [SerializeField]
    private int rescueDiffCounter;
    [Space]
    [Header("Fire")]
    [SerializeField]
    private int fireInitialAmtMin;
    [SerializeField]
    private int fireInitialAmtMax;
    [SerializeField]
    private int fireStartAt;
    [Space]
    [SerializeField]
    private int fireDiffFrequency;
    [Space]
    [SerializeField]
    private int fireMinIncreaseAmt;
    [SerializeField]
    private int fireMaxIncreaseAmt;
    [Space]
    [SerializeField]
    private int fireAmountMinLimit;
    [SerializeField]
    private int fireAmountMaxLimit;
    [Space]
    [SerializeField]
    private int fireDiffCounter;
    [Space]
    [Header("Player")]
    [SerializeField]
    private int playerInitialAmt;
    [SerializeField]
    private int playerStartAt;
    [Space]
    [SerializeField]
    private int playerDiffFrequency;
    [SerializeField]
    private int playerIncreaseAmt;
    [SerializeField]
    private int playerAmountLimit;
    [SerializeField]
    private int playerDiffCounter;
    [Space]
    [Header("Floor bg colors")]
    [SerializeField]
    private byte[] colorR;
    [SerializeField]
    private byte[] colorG;
    [SerializeField]
    private byte[] colorB;
    [Space]
    [SerializeField]
    private int colorChangeFrequency;
    [SerializeField]
    private int colorChangeCounter;
    Camera MainCamera;


    bool debrisActivate, boltActivate, rescueActivate, playerActivate, fireActivate, powerupActivate;

    debrisGeneration debrisGenScript;
    InfiniteGeneratorEndless infGenElScript;
    playercontroller playerControllerScript;
    FireAi fireAiScript;
    floorcounterEl flrCounterScript;
    // Use this for initialization
    void Start()
    {
        debrisGenScript = GameObject.Find("DebrisGeneration").GetComponent<debrisGeneration>();
        infGenElScript = GameObject.Find("PlatformGeneration").GetComponent<InfiniteGeneratorEndless>();
        playerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
        fireAiScript = GameObject.Find("Fire").GetComponent<FireAi>();
        flrCounterScript = GameObject.Find("player").GetComponent<floorcounterEl>();
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        //set Initial Amounts
        debrisGenScript.randomDebrisThreshold = debrisInitialAmt;
        infGenElScript.boltThreshold = boltInitialAmt;
        infGenElScript.powerupThreshold = powerupInitialAmt;
        infGenElScript.rescueThreshold = rescueInitialAmt;
        playerControllerScript.moveSpeed = playerInitialAmt;
        fireAiScript.minSpeed = fireInitialAmtMin;
        fireAiScript.maxSpeed = fireInitialAmtMax;

        int chosenColor = Random.Range(0, colorR.Length);
        infGenElScript.ColorR = colorR[chosenColor];
        infGenElScript.ColorG = colorG[chosenColor];
        infGenElScript.ColorB = colorB[chosenColor];
        MainCamera.backgroundColor = new Color32(colorR[chosenColor], colorG[chosenColor], colorB[chosenColor],255);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkScore()
    {
        debrisDifficulty();
        boltDifficulty();
        rescueDifficulty();
        playerDifficulty();
        //fireDifficulty();
        powerupDifficulty();
        colorChange();
    }

    private void debrisDifficulty()
    {
        if (flrCounterScript.countFloor_el >= debrisStartAt && !debrisActivate)
        {
            debrisGenScript.randomDebrisThreshold += debrisIncreaseAmt;
            debrisActivate = true;
        }
        if (debrisActivate)
        {
            //is the counter and frequency same?
            if (debrisDiffCounter < debrisDiffFrequency)
            {
                //Not the same
                debrisDiffCounter++;
            }
            else
            {

                //Yes but Is it below limit
                if (debrisGenScript.randomDebrisThreshold < debrisAmountLimit)
                {
                    //Yes, make it harder
                    debrisGenScript.randomDebrisThreshold += debrisIncreaseAmt;
                }
                //reset counter
                debrisDiffCounter = 0;
            }
        }

    }

    private void boltDifficulty()
    {
        if (flrCounterScript.countFloor_el >= boltStartAt && !boltActivate)
        {
            infGenElScript.boltThreshold += boltIncreaseAmt;
            boltActivate = true;
        }
        if (boltActivate)
        {
            //is the counter and frequency same?
            if (boltDiffCounter < boltDiffFrequency)
            {
                //Not the same
                boltDiffCounter++;
            }
            else
            {
                //Yes but Is it below limit
                if (infGenElScript.boltThreshold < boltAmountLimit)
                {
                    //Yes, make it harder
                    infGenElScript.boltThreshold += boltIncreaseAmt;
                }
                //reset counter
                boltDiffCounter = 0;
            }
        }

    }

    private void rescueDifficulty()
    {
        if (flrCounterScript.countFloor_el >= rescueStartAt && !rescueActivate)
        {
            infGenElScript.rescueThreshold += rescueIncreaseAmt;
            rescueActivate = true;
        }
        if (rescueActivate)
        {
            //is the counter and frequency same?
            if (rescueDiffCounter < rescueDiffFrequency)
            {
                //Not the same
                rescueDiffCounter++;
            }
            else
            {
                //Yes but Is it below limit
                if (infGenElScript.rescueThreshold < rescueAmountLimit)
                {
                    //Yes, make it harder
                    infGenElScript.rescueThreshold += rescueIncreaseAmt;
                }
                //reset counter
                rescueDiffCounter = 0;
            }
        }
    }

    private void playerDifficulty()
    {
        if (flrCounterScript.countFloor_el >= playerStartAt && !playerActivate)
        {
            playerControllerScript.moveSpeed += playerIncreaseAmt;
            playerActivate = true;
        }
        if (playerActivate)
        {
            //is the counter and frequency same?
            if (playerDiffCounter < playerDiffFrequency)
            {
                //Not the same
                playerDiffCounter++;
            }
            else
            {
                //Yes but Is it below limit
                if (playerControllerScript.moveSpeed < playerAmountLimit)
                {
                    //Yes, make it harder
                    playerControllerScript.moveSpeed += playerIncreaseAmt;
                }
                //reset counter
                playerDiffCounter = 0;
            }
        }
    }


    /*private void fireDifficulty()
    {
        if (flrCounterScript.countFloor_el >= fireStartAt && !fireActivate)
        {
            fireAiScript.minSpeed += fireMinIncreaseAmt;
            fireActivate = true;
        }
        if (fireActivate)
        {
            //is the counter and frequency same?
            if (fireDiffCounter < fireDiffFrequency)
            {
                //Not the same
                fireDiffCounter++;
            }
            else
            {
                //Yes but Is it below limit
                if (fireAiScript.minSpeed < fireAmountMinLimit)
                {
                    //Yes, make it harder
                    fireAiScript.minSpeed += fireMinIncreaseAmt;
                }

                //Yes but Is it below limit
                if (fireAiScript.maxSpeed < fireAmountMaxLimit)
                {
                    //Yes, make it harder
                    fireAiScript.maxSpeed += fireMaxIncreaseAmt;
                }



                //reset counter
                fireDiffCounter = 0;
            }
        }
    }*/

    private void powerupDifficulty()
    {
        if (flrCounterScript.countFloor_el >= powerupStartAt && !powerupActivate)
        {
            infGenElScript.powerupThreshold += powerupIncreaseAmt;
            powerupActivate = true;
        }
        if (powerupActivate)
        {
            //is the counter and frequency same?
            if (powerupDiffCounter < powerupDiffFrequency)
            {
                //Not the same
                powerupDiffCounter++;
            }
            else
            {
                //Yes but Is it below limit
                if (infGenElScript.powerupThreshold < powerupAmountLimit)
                {
                    //Yes, make it harder
                    infGenElScript.powerupThreshold += powerupIncreaseAmt;
                }
                //reset counter
                powerupDiffCounter = 0;
            }
        }
    }

    private void colorChange()
    {
        if (colorChangeCounter < colorChangeFrequency)
        {
            colorChangeCounter++;
        }
        else
        {
            int chosenColor = Random.Range(0, colorR.Length);
            infGenElScript.ColorR = colorR[chosenColor];
            infGenElScript.ColorG = colorG[chosenColor];
            infGenElScript.ColorB = colorB[chosenColor];
            colorChangeCounter = 0;
        }
    }


}
