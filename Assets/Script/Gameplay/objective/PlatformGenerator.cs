 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
	//floors
	public GameObject floor;
	public Transform generationPoint;
	public float distanceBetween;
	public ObjectPooler[] theObjectPools;
    [SerializeField]
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
    public floorcounter FloorCounterScript;
    [Header("RescuePointGeneration")]
    public float RescuePointThreshold;
    public float RescuePointheight;
    public int SetRescuePoint;
    public int AmountRescuePoint;
    public ObjectPooler[] RescuePointPooler;
    public int RescueSelector;
    public int prevRescue;
    public GameObject NewHolderOfPlatform;
    private DebriTrigger DebriTriggerScript;
    [Header("RescueNewGenerate")]
    public int RescueHolderDivided;
    [Header("ShakeGenerate")]
    public LevelPass LevelPassScript;
    private testingcamerashake TestingCameraShakeScript;
    public bool isShake;

	void Start()
	{
		platFormHeight = floor.GetComponent<BoxCollider2D>().size.y;
		WallGeneratorScript = GameObject.Find ("WallGeneration").GetComponent<WallGenerator> ();
        floorSelector = Random.Range(0, theObjectPools.Length);
        PrevFloor = floorSelector;
        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        TestingCameraShakeScript = GameObject.Find("camerashaketest").GetComponent<testingcamerashake>();
        RescueSelector = Random.Range(0, RescuePointPooler.Length);
        prevRescue = RescueSelector;
        if (LevelPassScript.isShakeActivateAmt == true)
        {
            isShake = true;
            //BlackOutObject.SetActive(true);

        }
	}
    //note 13.7 DistanceBetween
	void Update()
	{
        if (IsGenerate)
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
                //
                DebriTriggerScript = newPlatform.gameObject.GetComponent<DebriTrigger>();
                DebriTriggerScript.IsTrigger = true;
                //
                newPlatform.SetActive(true);
                //print(floorSelector);
                NewHolderOfPlatform = theObjectPools[floorSelector].GetPooledObject();
                FloorCounter();
                //hourglassgenerate

                //if (Random.Range(0f, 100f) < timeThreshold)
                //{
                if (Counts %timeThreshold ==0)
                {
                    GameObject newTime = timePooler.GetPooledObject();
                    float BoltXposition = Random.Range(8, 12);
                    Vector3 BoltPosition = new Vector3(BoltXposition, timeHeight, 0f);
                    newTime.transform.position = transform.position + BoltPosition;
                    newTime.transform.rotation = transform.rotation;
                    newTime.SetActive(true);   
                }
                //}
                //powerupgeneration
                if (FloorCounterScript.countFloor <= FloorCounterScript.halfFloorPoint)
                {
                    if (Random.Range(0f, 100f) < powerupThreshold)
                    {
                        GameObject newPowerup = powerupPooler.GetPooledObject();
                        float debrisXposition = Random.Range(0, 10);
                        Vector3 debrisPosition = new Vector3(debrisXposition, PowerupsHeight, 0f);
                        newPowerup.transform.position = transform.position + debrisPosition;
                        newPowerup.transform.rotation = transform.rotation;
                        newPowerup.SetActive(true);
                        if (setPowerups == amountPowerups)
                        {
                            powerupThreshold = 0;
                            newPowerup.SetActive(false);
                        }
                        else
                        {
                            setPowerups++;
                        }
                    }
                }
            //newrrescuegeneration----------------------------
                        RescueHolderDivided = EndGenerate / 5;
                        if (Counts % RescueHolderDivided ==0)
                        {
                            FloorCounterScript.MainFloorDecreaseDivided = FloorCounterScript.MainFloorHolderDivided;
                            GameObject newRescue = RescuePointPooler[RescueSelector].GetPooledObject();
                            float RescueXposition = Random.Range(8, 12);
                            Vector3 rescuePosition = new Vector3(RescueXposition, RescuePointheight, 0f);
                            newRescue.transform.position = transform.position + rescuePosition;
                            newRescue.transform.rotation = transform.rotation;
                            newRescue.SetActive(true);

                            if (SetRescuePoint == AmountRescuePoint)
                            {
                                newRescue.SetActive(false);
                            }
                            else
                            {
                                SetRescuePoint++;
                            }
                        }
            //----------------------------------------------
                        if (isShake)
                        {
                            if (Counts % 10 == 0)
                            {
                                TestingCameraShakeScript.IsActiveShake = true;
                                if (TestingCameraShakeScript.shakeDuration == 0)
                                {
                                    TestingCameraShakeScript.shakeDuration = 1f;
                                }
                            }  
                        }
            //ShakeGenerate
            //end
            }
        }
	}
	private void FloorCounter()
	{
		//floor limit codes
		if (Counts == EndGenerate) {
            IsGenerate = false;
			WallGeneratorScript.enabled = false;
			transform.position = new Vector3 (transform.position.x,transform.position.y + platFormHeight+ -distanceBetween,0);
			Instantiate (EndGameSprite, transform.position, transform.rotation);
		
		} else {Counts++;}
	}
   
}
