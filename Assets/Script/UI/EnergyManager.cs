using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour {

	// Use this for initialization
    public int energyLeft,energyMaxValue;
    [SerializeField]
    GameObject[] energyDrinks;
    [Space]
    [SerializeField]
    Sprite energySpriteColored;
    [SerializeField]
    Sprite energySpriteFaded;
    Levelselector lvlSelectorScript;
    [Space]
    [SerializeField]
    string sceneToGo;
	void Start () {
        lvlSelectorScript = GameObject.Find("LevelSelect").GetComponent<Levelselector>();

        if (!PlayerPrefs.HasKey("energyLeft")) PlayerPrefs.SetInt("energyLeft", 5);
        energyLeft = PlayerPrefs.GetInt("energyLeft");

        energyInitialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void decreaseEnergy()
    {
        energyLeft--;
        PlayerPrefs.SetInt("energyLeft", energyLeft);
        energyInitialize();
    }

    private void energyInitialize()
    {
        energyLeft = PlayerPrefs.GetInt("energyLeft");
        int energyCheck = energyMaxValue;

        while (energyCheck > energyLeft)
        {
            energyCheck--;
            energyDrinks[energyCheck].GetComponent<Image>().sprite = energySpriteFaded;
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
}
