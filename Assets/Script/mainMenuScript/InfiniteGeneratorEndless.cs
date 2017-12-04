 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGeneratorEndless : MonoBehaviour {
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
	public ObjectPooler timePooler;
	public float timeThreshold;
	public float timeHeight;
    public int PrevFloor;
    public bool IsGenerate;
    [Header("PowerUpGeneration")]
    public float powerupThreshold;
    public ObjectPooler powerupPooler;
    public float PowerupsHeight;
    public int setPowerups;
    public int amountPowerups;
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


	void Start()
	{
		platFormHeight = floor.GetComponent<BoxCollider2D>().size.y;
		WallGeneratorScript = GameObject.Find ("WallGeneration").GetComponent<WallGenerator> ();
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
                newPlatform.gameObject.tag = "floor";
                newPlatform.SetActive(true);
            
          
              //rescue generator
                //RescueHolderDivided = 30/ 5;
                if (Counts % 10 == 0)
                {
                    FloorCounterScript.MainFloorDecreaseDivided = FloorCounterScript.MainFloorHolderDivided;
                    GameObject newRescue = RescuePointPooler[RescueSelector].GetPooledObject();
                    float RescueXposition = Random.Range(8, 12);
                    Vector3 rescuePosition = new Vector3(RescueXposition, RescuePointheight, 0f);
                    newRescue.transform.position = transform.position + rescuePosition;
                    newRescue.transform.rotation = transform.rotation;
                    newRescue.SetActive(true);

                }

                FloorCounter();
              
                //
            }
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
