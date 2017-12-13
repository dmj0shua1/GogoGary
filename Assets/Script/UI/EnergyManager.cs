using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour {

	// Use this for initialization
    public int energyLeft;
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void decreaseEnergy()
    {
        energyLeft--;
        energyDrinks[energyLeft].GetComponent<SpriteRenderer>().sprite = energySpriteFaded;
    }
}
