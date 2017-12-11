using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text lblHScore, txtHScore, lblScore1, lblScore2, txtScore;
    floorcounterEl flrCounterScript;
    public int rescueCounter;

    private IEnumerator animScore;
    public Text txtFloors, txtRescues;
    int incFloors, incRescues,incScore,playerScore,hscore;
    // Use this for initialization
    void Start()
    {
        flrCounterScript = GameObject.Find("player").GetComponent<floorcounterEl>();

        if (!PlayerPrefs.HasKey("Hscore")) PlayerPrefs.SetInt("Hscore", 000);

        animScore = animScoreCor(0.001f);
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void saveHighscore()
    {
        playerScore = flrCounterScript.countFloor_el;
        hscore = PlayerPrefs.GetInt("Hscore");

        if (playerScore <= hscore)
        {
            //display hscore and current score
            txtHScore.text = hscore.ToString();
       //     txtScore.text = playerScore.ToString();
        }
        else
        {
            //save score
            PlayerPrefs.SetInt("Hscore", playerScore);
            //new highscore!
            lblHScore.gameObject.SetActive(false);
            txtHScore.gameObject.SetActive(false);
            lblScore1.gameObject.SetActive(false);
            lblScore2.gameObject.SetActive(true);
      //      txtScore.text = playerScore.ToString();
        }


    }

    public void animateScore()
    {
        StartCoroutine(animScore);
    }

    private IEnumerator animScoreCor(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            if (incScore < playerScore)
            {
                incScore++;
                txtScore.text = incScore.ToString();
            }

            if (incFloors < (playerScore - rescueCounter))
            {
                incFloors++;
                txtFloors.text = incFloors.ToString();
            }

            if (incRescues < rescueCounter)
            {
                incRescues++;
                txtRescues.text = incRescues.ToString();
            }
        }
    }
}