using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGeneratorEndless : MonoBehaviour
{
    //floors
    public GameObject floor;
    public Transform generationPoint;
    public float distanceBetween;
    public ObjectPooler[] theObjectPools;

    private float platFormHeight;
    private int floorSelector;
    [Header("FloorLimitAndExit")]
    public GameObject EndGameSprite;
    public int Counts;
    public int EndGenerate;
    private WallGenerator WallGeneratorScript;
    [Header("BoltGeneration")]
    public ObjectPooler boltPooler;
    public int boltThreshold;
    public float boltHeight;
    public int PrevFloor;
    public bool IsGenerate;
    [Header("PowerUpGeneration")]
    public float powerupThreshold;
    public ObjectPooler powerupPooler;
    public float PowerupsHeight;
   /* public int setPowerups;
    public int amountPowerups;*/
    public floorcounterEl FloorCounterScript;
    [Header("RescuePointGeneration")]
    public float RescuePointThreshold;
    public float RescuePointheight;
    public int SetRescuePoint;
    public int AmountRescuePoint;
    public ObjectPooler[] RescuePointPooler;
    public int RescueSelector;
    public int prevRescue;
    public int RescueHolderDivided;
    public int rescueThreshold;

    private DebriTrigger DebriTriggerScript;
    private bgColorChange bgColorChangeScript;
    [Space]
    [Header("Floor bg colors")]
    public byte ColorR,ColorG,ColorB;

    void Start()
    {
        platFormHeight = floor.GetComponent<BoxCollider2D>().size.y;
        WallGeneratorScript = GameObject.Find("WallGeneration").GetComponent<WallGenerator>();
        floorSelector = Random.Range(0, theObjectPools.Length);
        PrevFloor = floorSelector;
        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounterEl>();
        RescueSelector = Random.Range(0, RescuePointPooler.Length);
        prevRescue = RescueSelector;
        
    }
    //note 13.7 DistanceBetween
    void Update()
    {

        if (transform.position.y > generationPoint.position.y)
        {
            //platform Generate
            while (floorSelector == PrevFloor)
            {
                floorSelector = Random.Range(0, theObjectPools.Length);
            }

            PrevFloor = floorSelector;
            transform.position = new Vector3(transform.position.x, transform.position.y + platFormHeight + -distanceBetween, 0);
            GameObject newPlatform = theObjectPools[floorSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            bgColorChangeScript = newPlatform.gameObject.GetComponent<bgColorChange>();
            bgColorChangeScript.sprRenderer.color = new Color32(ColorR,ColorG,ColorB,255);
            newPlatform.gameObject.tag = "floor";
            newPlatform.SetActive(true);
            DebriTriggerScript = newPlatform.gameObject.GetComponent<DebriTrigger>();
            DebriTriggerScript.IsTrigger = true;
            FloorCounter();
            //rescue generator
            //RescueHolderDivided = 30/ 5;
            if (Counts % rescueThreshold == 0)
            {
                FloorCounterScript.MainFloorDecreaseDivided = FloorCounterScript.MainFloorHolderDivided;
                GameObject newRescue = RescuePointPooler[RescueSelector].GetPooledObject();
                float RescueXposition = Random.Range(1, 12);
                Vector3 rescuePosition = new Vector3(RescueXposition, RescuePointheight, 0f);
                newRescue.transform.position = transform.position + rescuePosition;
                newRescue.transform.rotation = transform.rotation;
                newRescue.SetActive(true);

            }

            if (Counts % boltThreshold == 0)
            {
                GameObject newTime = boltPooler.GetPooledObject();
                float BoltXposition = Random.Range(8, 12);
                Vector3 BoltPosition = new Vector3(BoltXposition, boltHeight, 0f);
                newTime.transform.position = transform.position + BoltPosition;
                newTime.transform.rotation = transform.rotation;
                newTime.SetActive(true);
            }
            //if (powerupThreshold == 75)
            //{
            //PowerUpdHolderDivided = EndGenerate / 2;
            if (Counts % powerupThreshold == 0)
            {


                GameObject newPowerup = powerupPooler.GetPooledObject();
                float PowerUpposition = Random.Range(8, 12);
                Vector3 PowerupPos = new Vector3(PowerUpposition, PowerupsHeight, 0f);
                newPowerup.transform.position = transform.position + PowerupPos;
                newPowerup.transform.rotation = transform.rotation;
                newPowerup.SetActive(true);

            }


            //}


            //
        }
    }

    public void ExtraPowerUps()
    {
        GameObject newPowerup = powerupPooler.GetPooledObject();
        float PowerUpposition = Random.Range(8, 12);
        Vector3 PowerupPos = new Vector3(PowerUpposition, PowerupsHeight, 0f);
        newPowerup.transform.position = transform.position + PowerupPos;
        newPowerup.transform.rotation = transform.rotation;
        newPowerup.SetActive(true);

    }

    private void FloorCounter()
    {
        //floor limit codes
        /*if (Counts == EndGenerate) {
            IsGenerate = false;
            //WallGeneratorScript.enabled = false;
            //transform.position = new Vector3 (transform.position.x,transform.position.y + platFormHeight+ -distanceBetween,0);
            //Instantiate (EndGameSprite, transform.position, transform.rotation);
		
        } else {Counts++;}*/
        Counts++;
    }

}
