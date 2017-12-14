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

    
	void Start () {
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
}
