using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnergyTimeManager : MonoBehaviour
{

    // Use this for initialization

    public double itmTime;
    long temp;
    DateTime oldDate;
    DateTime currentDate;
    DateTime endTime, curTime;
    TimeSpan timeLeft;
    public Text timerEnergy;
    private string egName;
    private IEnumerator coroutine;
    DateChecker dateCheckerScript;
    public EnergyManager egManagerScript;
    bool isFirstTimer;
    public double secsLeftEnergy;
    EnergyTimer latestTimer;
    [SerializeField]
    GameObject refillAmountObj;
    void Start()
    {

        dateCheckerScript = gameObject.GetComponent<DateChecker>();
        egManagerScript = gameObject.GetComponent<EnergyManager>();       //Store the current time when it starts
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
        if (egManagerScript.energyLeft < egManagerScript.energyMaxValue)
        {
            // Get current time in minutes 
            System.DateTime today = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(0, 0, Convert.ToInt32(itmTime), 0);
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
        /*   if (PlayerPrefs.HasKey("timeLeft"))
           {
               //do nothing
           }
           else
           {
               //PlayerPrefs.SetString("")
           } */

        if (PlayerPrefs.HasKey("endTime" + egName))
        {
            string dT = PlayerPrefs.GetString("endTime" + egName);
            endTime = Convert.ToDateTime(dT);
            print("ENDTIME: " + endTime);
            regenerationTimeChecker();
        }


    }

    void regenerationTimeChecker()
    {
        dateCheckerScript.datevalue1 = endTime;
        dateCheckerScript.itemName = egName;
        dateCheckerScript.expiryCheck();
    }

    private void findLatestTimer()
    {
        for (int i = 0; i < egManagerScript.energyMaxValue; i++)
        {
            latestTimer = egManagerScript.energyDrinks[i].GetComponent<EnergyTimer>();
            if (latestTimer.timerActive)
            {
                if (latestTimer.secsLeftEnergy >= 0)
                {
                    secsLeftEnergy = latestTimer.secsLeftEnergy;
                }
                else
                {
                    secsLeftEnergy = 0;
                }
                break;
            }


           
        }

    }

    private IEnumerator WaitAndUpdate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            curTime = System.DateTime.Now;
            timeLeft = endTime - curTime;
            findLatestTimer();
          //  secsLeftEnergy = timeLeft.TotalSeconds;
            


            // print("Total Hours: " + secsLeftBoost.ToString());

            string output = String.Format("{0:D2}:{1:D2}", latestTimer.timeLeft.Minutes, latestTimer.timeLeft.Seconds);



            if (secsLeftEnergy <= 0 || egManagerScript.timerCount <= 0 || egManagerScript.energyLeft >= egManagerScript.energyMaxValue)
            {
                timerEnergy.text = "";
                PlayerPrefs.DeleteKey("endTime" + egName);
                if (PlayerPrefs.GetInt("energyLeft") < egManagerScript.energyMaxValue)
                {

                    if (PlayerPrefs.GetInt("energyLeft") < egManagerScript.energyMaxValue) saveEnergyTime();



                }

            }
            else if (secsLeftEnergy <= 60)
            {
                string secsLeftEnergyStr = secsLeftEnergy.ToString().Substring(0, 2);
                if (secsLeftEnergy >= 10) timerEnergy.text = "00:" + secsLeftEnergyStr;
                else
                {
                    secsLeftEnergyStr = secsLeftEnergy.ToString().Substring(0, 1);
                    timerEnergy.text = "00:0" + secsLeftEnergyStr;
                }
            }
            else
            {
                timerEnergy.text = output;
                print("");
            }

            if (PlayerPrefs.GetInt("energyLeft") <= 0)
            {
                refillAmountObj.SetActive(true);
            }
            else
            {
                refillAmountObj.SetActive(false);
            }

        }

    }
}
