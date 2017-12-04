using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

    public Text TextHolder;
    public string Chinese;
    public string English;
    void Update() 
    {
        if (PlayerPrefs.GetInt("LanguageNumber") == 1)
        {
            TextHolder.GetComponent<Text>().text = Chinese;
        }
        else if (PlayerPrefs.GetInt("LanguageNumber") == 0)
        {
            TextHolder.GetComponent<Text>().text = English;
        }
    }
   
}
