using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnergyTimeManager : MonoBehaviour {

	// Use this for initialization

     public double itmTime;
     long temp;
     DateTime oldDate;
     DateTime currentDate;
     DateTime endTime, curTime;
    TimeSpan timeLeft;
    public Text timerEnergy;
     [SerializeField]
     private string egName;
     private IEnumerator coroutine;
     DateChecker dateCheckerScript;
    

	void Start () {
        
        dateCheckerScript = gameObject.GetComponent<DateChecker>();

        //Store the current time when it starts
        currentDate = System.DateTime.Now;

        refreshTime();

        coroutine = WaitAndUpdate(1.0f);
        StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void saveEnergyTime()
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

      private IEnumerator WaitAndUpdate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            curTime = System.DateTime.Now;
            timeLeft = endTime - curTime;
            var secsLeftEnergy = timeLeft.TotalSeconds;



            // print("Total Hours: " + secsLeftBoost.ToString());

            string output = String.Format("{0:D2}:{1:D2}:{2:D2}", timeLeft.Hours, timeLeft.Minutes, timeLeft.Seconds);



            if (secsLeftEnergy <= 0)
            {
                if (SceneManager.GetActiveScene().name == "Stage1") timerEnergy.text = "0 "+egName;
                PlayerPrefs.DeleteKey("endTime"+egName);

            }
            else if (secsLeftEnergy <= 60)
            {
                string secsLeftEnergyStr = secsLeftEnergy.ToString().Substring(0, 2);
                if (secsLeftEnergy >= 10 && SceneManager.GetActiveScene().name == "Stage1") timerEnergy.text = "00:00:" + secsLeftEnergyStr;
                else
                {
                    secsLeftEnergyStr = secsLeftEnergy.ToString().Substring(0, 1);
                    timerEnergy.text = "00:00:0" + secsLeftEnergyStr;
                }
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "Stage1") timerEnergy.text = output;
                print("");
            }


        }

    }
}
