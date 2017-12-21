using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnergyTimer : MonoBehaviour
{

    // Use this for initialization

    public double itmTime;
    long temp;
    DateTime oldDate;
    DateTime currentDate;
    DateTime endTime, curTime;
    public TimeSpan timeLeft;
    private string egName;
    private IEnumerator coroutine;
    DateChecker dateCheckerScript;
    EnergyManager egManagerScript;
    public GameObject egManagerObj;
    public bool timerActive;
    EnergyTimeManager egTimeManager;
    public System.DateTime datevalue1;
    public double secsLeftEnergy;
    double addTimeNewTimer;
    void Start()
    {

        dateCheckerScript = gameObject.GetComponent<DateChecker>();
        egManagerScript = egManagerObj.GetComponent<EnergyManager>();       //Store the current time when it starts
        egTimeManager = GameObject.Find("Energy").GetComponent<EnergyTimeManager>();
        currentDate = System.DateTime.Now;
        egName = gameObject.name;
        refreshTime();

        coroutine = WaitAndUpdate(1.0f);
        StartCoroutine(coroutine);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void saveEnergyTime()
    {
        if (egManagerScript.timerCount >= 2)
        {
            addTimeNewTimer = egManagerScript.energyDrinks[egManagerScript.timerCount - 1].GetComponent<EnergyTimer>().secsLeftEnergy;
        }
        else
        {
            addTimeNewTimer = egTimeManager.secsLeftEnergy;
        }

        if (egManagerScript.energyLeft < egManagerScript.energyMaxValue)
        {
            // Get current time in minutes 
            System.DateTime today = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(0, 0, Convert.ToInt32(itmTime), 0 + Convert.ToInt32(addTimeNewTimer));
            System.DateTime result = today.Add(duration);

            //Save the expiration [itmTime] minutes from now
            PlayerPrefs.SetString("endTime" + egName, result.ToString());

            currentDate = System.DateTime.Now;
            refreshTime();
        }

    }



    public void refreshTime()
    {
        //Grab the old time from the player prefs as a long
        if (PlayerPrefs.HasKey("sysString"))
        {
            temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
        }
        else
        {
            PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());

        }

        //Convert the old time from binary to a DataTime variable
        oldDate = DateTime.FromBinary(temp);
        print("oldDate: " + oldDate);

        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDate);
        //    print("Difference: " + difference);
        //check if timeleft is present
        if (PlayerPrefs.HasKey("endTime" + egName))
        {
            string dT = PlayerPrefs.GetString("endTime" + egName);
            endTime = Convert.ToDateTime(dT);
            print("ENDTIME: " + endTime);
            timerActive = true;
            expiryCheck();
        }
    }


    private IEnumerator WaitAndUpdate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            curTime = System.DateTime.Now;
            timeLeft = endTime - curTime;
            secsLeftEnergy = timeLeft.TotalSeconds;

            if (secsLeftEnergy <= 0 && PlayerPrefs.HasKey("endTime" + egName) && egManagerScript.energyLeft < egManagerScript.energyMaxValue)
            {
                egManagerScript.timerCount--;
                PlayerPrefs.SetInt("timerCount", egManagerScript.timerCount);
                PlayerPrefs.DeleteKey("endTime" + egName);
                timerActive = false;
                egManagerScript.increaseEnergy();


                if (egManagerScript.energyLeft < egManagerScript.energyMaxValue)
                {
                    egManagerScript.triggerATimer();
                }

            }
        }

    }

    private void expiryCheck()
    {
        System.DateTime datevalue2 = System.DateTime.Now;
        double hours = (endTime - datevalue2).TotalHours;

        if (hours <= 0)
        {

            //   PlayerPrefs.DeleteKey("endTime" + egName);
            print(egName + " is Expired!!");
            print("HOURS: " + hours);

            if (egManagerScript.energyLeft < egManagerScript.energyMaxValue)
            {

                timerActive = false;
                egManagerScript.energyLeft++;
                egManagerScript.redisplayTime();
            }

        }


    }

    public void startTimer()
    {
        if (PlayerPrefs.GetInt("energyLeft") < egManagerScript.energyMaxValue) saveEnergyTime();

    }




}
