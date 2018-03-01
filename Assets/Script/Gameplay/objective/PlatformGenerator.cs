 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int PowerUpdHolderDivided;
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
    [SerializeField]
    private testingcamerashake TestingCameraShakeScript;
    public bool isShake;
    [Header("Blackout")]
    public GameObject blackOutGameObject;
    public Animator blackOutAnimation;
    public int blackOutHolderDivided;
    [Header("FireHalfFloor")]
    private FireAi FireAiScript;
    public int FireHolderDivided;
    [Header("Mummy")]
    public MummyController MummyControllerScript;
    public bool IsGenerateMummy;
    public ObjectPooler mummyPooler;
    public float Mummyheight;
    public int MummyThreshold;
    [SerializeField]
    private debrisGeneration DebriGenerationScript;
    [Header("WalkThrougwalls")]
    private WalkThroughWalls WalkThroughWallsScript;
    public bool isEnabledWalkThrougwall;
    [Header("FloorCompare")]
    public int FirstFloorNumber;
    public int SecondFloorNumber;
    public bool isFloorNumberCount;
    [Header("phBird")]
    public phBirdController phBirdContollerScript;
    public bool IsGeneratephBird;
    public ObjectPooler phBirdPooler;
    public float phbirdheight;
    public int phbirdThreshold;
    [Header("Smudge")]
    public bool isSmudge;
    public GameObject SmudgeObject;
    public int smudgeDivided;
    [Header("Blizzard")]
    public bool isBlizzard;
    public GameObject BlizzardObject;
    public int blizzardDivided;
    [SerializeField]
    private Animator BlizzardAnimation;
    [Header("BigFoot")]
    public bool isBigFoot;
    public ObjectPooler ieBigfootPooler;
    public float ieBigFootheight;
    public int ieBigFootThreshold;
    public ieBigFootManager ieBigFootManagerScript;
    public BigFootController BigFootControllerScript;
    




	void Start()
	{
		platFormHeight = floor.GetComponent<BoxCollider2D>().size.y;
		WallGeneratorScript = GameObject.Find ("WallGeneration").GetComponent<WallGenerator> ();
        floorSelector = Random.Range(0, theObjectPools.Length);
        PrevFloor = floorSelector;
        RescueSelector = Random.Range(0, RescuePointPooler.Length);
        prevRescue = RescueSelector;
        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        TestingCameraShakeScript = GameObject.Find("camerashaketest").GetComponent<testingcamerashake>();
        FireAiScript = GameObject.Find("Fire").GetComponent<FireAi>();
        blackOutAnimation = blackOutGameObject.GetComponent<Animator>();
        DebriGenerationScript = GameObject.Find("DebrisGeneration").GetComponent<debrisGeneration>();
        WalkThroughWallsScript = GameObject.Find("player").GetComponent<WalkThroughWalls>();
        if (SceneManager.GetActiveScene().name == "GGGICEAGE") ieBigFootManagerScript = GameObject.Find("BigFootManager").GetComponent<ieBigFootManager>();
        if (LevelPassScript.isShakeActivateAmt == true)
        {
            isShake = true;
            //BlackOutObject.SetActive(true);

        }
        BlizzardAnimation = GameObject.Find("snow2").GetComponent<Animator>();
      
        
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
                //FloorCompareMethod();
                //FloorCompareChecker();
                transform.position = new Vector3(transform.position.x, transform.position.y + platFormHeight + -distanceBetween, 0);
                GameObject newPlatform = theObjectPools[floorSelector].GetPooledObject();
                newPlatform.transform.position = transform.position;
                newPlatform.transform.rotation = transform.rotation;
                newPlatform.gameObject.tag = "floor";
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
                //if (FloorCounterScript.countFloor <= FloorCounterScript.halfFloorPoint)
                //{
                    //if (Random.Range(0f, 100f) < powerupThreshold)
                   // {
                if (powerupThreshold == 75)
                {
                    PowerUpdHolderDivided = EndGenerate / 2;
                    if (Counts % PowerUpdHolderDivided == 0)
                    {
                        GameObject newPowerup = powerupPooler.GetPooledObject();
                        float PowerUpposition = Random.Range(8, 12);
                        Vector3 PowerupPos = new Vector3(PowerUpposition, PowerupsHeight, 0f);
                        newPowerup.transform.position = transform.position + PowerupPos;
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
               
                    //}
                //}
                //
            //newrrescuegeneration----------------------------

                Scene currentScene = SceneManager.GetActiveScene();
                string sceneName = currentScene.name;
                if (sceneName == "GGG")
                {
                    RescueHolderDivided = EndGenerate / 4;
                    if (Counts % RescueHolderDivided == 0)
                    {
                        if (floorSelector == 0 || floorSelector == 1 || floorSelector == 2 )
                        {
                            while (RescueSelector == prevRescue)
                            {
                                RescueSelector = Random.Range(0, RescuePointPooler.Length);
                            }
                            prevRescue = RescueSelector;
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
                    }
                }
                if (sceneName == "GGGPREHISTORIC" )
                {
                    RescueHolderDivided = EndGenerate / 5;
                    if (Counts % RescueHolderDivided == 0)
                    {
                        if (floorSelector == 0 || floorSelector == 3 || floorSelector == 4)
                        {
                            while (RescueSelector == prevRescue)
                            {
                                RescueSelector = Random.Range(0, RescuePointPooler.Length);
                            }
                            prevRescue = RescueSelector;
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
                    }
                }
                if (sceneName == "GGGICEAGE")
                {
                   
                    RescueHolderDivided = EndGenerate / 5;
                    if (Counts % RescueHolderDivided == 0)
                    {
                        if (floorSelector == 0 || floorSelector == 3 || floorSelector == 2 || floorSelector == 4)
                        {
                            while (RescueSelector == prevRescue)
                            {
                                RescueSelector = Random.Range(0, RescuePointPooler.Length);
                            }
                            prevRescue = RescueSelector;

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
                    }
                }
                if (sceneName == "GGGPYRAMID")
                {

                    RescueHolderDivided = EndGenerate / 5;
                    if (Counts % RescueHolderDivided == 0)
                    {
                        if (floorSelector == 0 || floorSelector == 3 || floorSelector == 4 || floorSelector == 1 )
                        {
                            while (RescueSelector == prevRescue)
                            {
                                RescueSelector = Random.Range(0, RescuePointPooler.Length);
                            }
                            prevRescue = RescueSelector;

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
                    }
                }
                        /*RescueHolderDivided = EndGenerate / 5;
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
                        }*/
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
                //  
                        if (sceneName == "GGGPYRAMID" || sceneName == "GGG")
                        {
                            blackOutHolderDivided = EndGenerate / 3;
                            if (/*Counts % blackOutHolderDivided ==0*/blackOutHolderDivided == FloorCounterScript.countFloor)
                            {
                                blackOutGameObject.SetActive(true);
                                blackOutAnimation.SetBool("IsIdle", true);

                            }
                        }
                        //Mummy  
               
                    if (sceneName == "GGGPYRAMID")
                    {
                        MummyThresholdAdjust();
                    if (LevelPassScript.LevelStatusAmt >= 28)
                    {
                        IsGenerateMummy = true;
                        if (IsGenerateMummy)
                        {
                           
                            if (Counts % MummyThreshold == 0)
                            {
                                GameObject newMummy = mummyPooler.GetPooledObject();
                                float MummyXposition = Random.Range(1, 16);
                                Vector3 MummyPosition = new Vector3(MummyXposition, Mummyheight, 0f);
                                newMummy.transform.position = transform.position + MummyPosition;
                                newMummy.transform.rotation = transform.rotation;
                                MummyControllerScript = newMummy.gameObject.GetComponent<MummyController>();
                                MummyControllerScript.MummyMainCollider.enabled = true;
                                MummyControllerScript.IsMove = true;
                                newMummy.SetActive(true);
                            }
                        }
                    }
                }
                    
                      
                        fireHalfFloorMethod();
                //random gobackagain walk throughwalls
                        if (sceneName == "GGGPYRAMID" || sceneName == "GGGPREHISTORIC" )
                        {
                            if (isEnabledWalkThrougwall)
                            {
                                float WalkthroughWallThreshold = Random.Range(3, 5);
                                if (Counts % WalkthroughWallThreshold == 0)
                                {
                                    WalkThroughWallsScript.isChange = false;
                                } 
                            }
                            
                        }
                //
                        //phbird
                        if (sceneName == "GGGPREHISTORIC")
                       {
                            //MummyThresholdAdjust();
                            PhBirdThresholdAdjust();
                            if (LevelPassScript.LevelStatusAmt >= 53)
                            {
                            IsGeneratephBird = true;
                            if (IsGeneratephBird)
                            {

                            if (Counts % phbirdThreshold == 0)
                            {
                                if (floorSelector == 0 || floorSelector == 2 || floorSelector == 3 || floorSelector == 1)
                                {
                                    GameObject newphbird = phBirdPooler.GetPooledObject();
                                    float phBirdXposition = Random.Range(1, 1);
                                    Vector3 phBirdPosition = new Vector3(phBirdXposition, phbirdheight, 0f);
                                    newphbird.transform.position = transform.position + phBirdPosition;
                                    newphbird.transform.rotation = transform.rotation;
                                    //MummyControllerScript = newMummy.gameObject.GetComponent<MummyController>();
                                    phBirdContollerScript = newphbird.gameObject.GetComponent<phBirdController>();
                                    phBirdContollerScript.isCollide = true;
                                    /*phBirdContollerScript.playerRange = 12;
                                    phBirdContollerScript.Activate = true;*/
                                    phBirdContollerScript._moveSpeed = 30;
                                    newphbird.SetActive(true);
                                }
                            }
                            }
                            }
                        }
                //  
                        if (sceneName == "GGGPREHISTORIC" || sceneName == "GGGICEAGE")
                        {
                          
                            if (isSmudge)
                            {
                                smudgeDivided = EndGenerate / 2;
                                if (/*Counts % smudgeDivided == 0*/smudgeDivided == FloorCounterScript.countFloor)
                                {
                                    SmudgeObject.SetActive(true);
                                }
                            }
                        }
                //
                        if (sceneName == "GGGICEAGE")
                        {

                            if (isBlizzard)
                            {
                                blizzardDivided = EndGenerate / 2;
                                if (/*Counts % smudgeDivided == 0*/blizzardDivided == FloorCounterScript.countFloor)
                                {
                                    BlizzardObject.SetActive(true);
                                    StartCoroutine(BlizzardFade());
                                }

                            } 
                        }
                      
                //
                        if (sceneName == "GGGICEAGE")
                        {
                            IeThresholdAdjust();
                        }

                //bigfoot
                        if (sceneName == "GGGICEAGE")
                        {
                            if (isBigFoot)
                            {
                                if (Counts % ieBigFootThreshold == 0)
                                {
                                    GameObject newIeBigFoot = ieBigfootPooler.GetPooledObject();
                                    float IeBigFootXposition = Random.Range(2, 2);
                                    Vector3 IeBigFootPosition = new Vector3(IeBigFootXposition, ieBigFootheight, 0f);
                                    newIeBigFoot.transform.position = transform.position + IeBigFootPosition;
                                    newIeBigFoot.transform.rotation = transform.rotation;
                                    BigFootControllerScript = newIeBigFoot.gameObject.GetComponent<BigFootController>();
                                    BigFootControllerScript.isEnabled = false;
                                    BigFootControllerScript.BigFootSfx.enabled = true;
                                    //ieBigFootManagerScript.isAnimate = false;
                                    newIeBigFoot.SetActive(true);
                                }
                                /*if (Counts % 10 == 0)
                                {
                                    TestingCameraShakeScript.IsActiveShake = true;
                                    if (TestingCameraShakeScript.shakeDuration == 0)
                                    {
                                        TestingCameraShakeScript.shakeDuration = 1f;
                                    }
                                }*/
                            }
                        }
                //
            }
        }
	}

    public void FloorCompareMethod() 
    {
        if (isFloorNumberCount)
        {
            FirstFloorNumber = PrevFloor;
        }
    }

    public void FloorCompareChecker() 
    {
        if (SecondFloorNumber == 1 && FirstFloorNumber == 2)
        {
            print("gumana");
        }
        else
        {

        }
    }
    public void MummyThresholdAdjust() 
    {

        for (int set1 = 26; set1 <= 27; set1++)
        {
            if (LevelPassScript.LevelStatusAmt == set1)
            {
              MummyThreshold = 0;   
            }
        }
        for (int set2 = 28; set2 <= 32; set2++)
        {
            if (LevelPassScript.LevelStatusAmt == set2)
            {
                MummyThreshold = 5;
            }
        }
        for (int set3 = 33; set3 <= 37; set3++)
        {
            if (LevelPassScript.LevelStatusAmt == set3)
            {
                MummyThreshold = 5;    
            }
        }
        for (int set4 = 38; set4 <= 42; set4++)
        {
            if (LevelPassScript.LevelStatusAmt == set4)
            {
                MummyThreshold = 4;
                DebriGenerationScript.randomDebrisThreshold = 15;
                isEnabledWalkThrougwall = true;
                powerupThreshold = 75;

            }
        }
        for (int set5 = 43; set5 <= 47; set5++)
        {
            if (LevelPassScript.LevelStatusAmt == set5)
            {
                MummyThreshold = 3;
                DebriGenerationScript.randomDebrisThreshold = 20;
                timeThreshold = 10;
                isEnabledWalkThrougwall = true;
                powerupThreshold = 75;
            }
        }
        for (int set6 = 48; set6 <= 50; set6++)
        {
            if (LevelPassScript.LevelStatusAmt == set6)
            {
                MummyThreshold = 3;
                DebriGenerationScript.randomDebrisThreshold = 25;
                timeThreshold = 10;
                isEnabledWalkThrougwall = true;
                powerupThreshold = 75;
            }
        }
     
    }
    public void PhBirdThresholdAdjust()
    {

        for (int set1 = 51; set1 <= 52; set1++)
        {
            if (LevelPassScript.LevelStatusAmt == set1)
            {
                isSmudge = true;
            }
        }
        for (int set2 = 53; set2 <= 57; set2++)
        {
            if (LevelPassScript.LevelStatusAmt == set2)
            {
                phbirdThreshold = 8;
                isSmudge = true;
            }
        }
        for (int set3 = 58; set3 <= 62; set3++)
        {
            if (LevelPassScript.LevelStatusAmt == set3)
            {
                phbirdThreshold = 7;
                isSmudge = true;
            }
        }
        for (int set4 = 63; set4 <= 67; set4++)
        {
            if (LevelPassScript.LevelStatusAmt == set4)
            {
                phbirdThreshold = 6;
                DebriGenerationScript.randomDebrisThreshold = 15;
                isSmudge = true;
                isEnabledWalkThrougwall = true;
                powerupThreshold = 75;
            }
        }
        for (int set5 = 68; set5 <= 72; set5++)
        {
            if (LevelPassScript.LevelStatusAmt == set5)
            {
                phbirdThreshold = 3;
                DebriGenerationScript.randomDebrisThreshold = 20;
                timeThreshold = 10;
                isSmudge = true;
                isEnabledWalkThrougwall = true;
                powerupThreshold = 75;

            }
        }
        for (int set6 = 73; set6 <= 75; set6++)
        {
            if (LevelPassScript.LevelStatusAmt == set6)
            {
                phbirdThreshold = 3;
                DebriGenerationScript.randomDebrisThreshold = 25;
                timeThreshold = 10;
                isSmudge = true;
                isEnabledWalkThrougwall = true;
                powerupThreshold = 75;
            }
        }

    }
    public void IeThresholdAdjust()
    {

        for (int set1 = 76; set1 <= 77; set1++)
        {
            if (LevelPassScript.LevelStatusAmt == set1)
            {
                isBlizzard = true;
            }
        }
        for (int set2 = 78; set2 <= 82; set2++)
        {
            if (LevelPassScript.LevelStatusAmt == set2)
            {
                isBlizzard = true;
                DebriGenerationScript.randomDebrisThreshold = 15;
                //isBigFoot = true;
            }
        }
        for (int set3 = 83; set3 <= 87; set3++)
        {
            if (LevelPassScript.LevelStatusAmt == set3)
            {
                isBlizzard = true;
                DebriGenerationScript.randomDebrisThreshold = 15;
                //isBigFoot = true;
            }
        }
        for (int set4 = 88; set4 <= 92; set4++)
        {
            if (LevelPassScript.LevelStatusAmt == set4)
            {
                isBlizzard = true;
                DebriGenerationScript.randomDebrisThreshold = 15;
                powerupThreshold = 75;
                isBigFoot = true;
            }
        }
        for (int set5 = 93; set5 <= 97; set5++)
        {
            if (LevelPassScript.LevelStatusAmt == set5)
            {
                isBlizzard = true;
                DebriGenerationScript.randomDebrisThreshold = 20;
                powerupThreshold = 75;
                timeThreshold = 10;
                isBigFoot = true;
            }
        }
        for (int set6 = 98; set6 <= 100; set6++)
        {
            if (LevelPassScript.LevelStatusAmt == set6)
            {
                isBlizzard = true;
                DebriGenerationScript.randomDebrisThreshold = 25;
                powerupThreshold = 75;
                timeThreshold = 10;
                isBigFoot = true;
            }
        }

    }
    public void fireHalfFloorMethod() 
    {
        FireHolderDivided = EndGenerate / 2;
        if (PlayerPrefs.GetInt("CompleteLevelCounter") == 0)
        {
            if (LevelPassScript.LevelStatusAmt >= 15)
            {
                {
                    if (FireHolderDivided == FloorCounterScript.countFloor)
                    {
                        FireAiScript.minSpeed = FireAiScript.minSpeed + 1;
                        FireAiScript.maxSpeed = FireAiScript.maxSpeed + 1;
                    }
                }
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
    public void ExtraPowerUps() 
    {
        GameObject newPowerup = powerupPooler.GetPooledObject();
        float PowerUpposition = Random.Range(8, 12);
        Vector3 PowerupPos = new Vector3(PowerUpposition, PowerupsHeight, 0f);
        newPowerup.transform.position = transform.position + PowerupPos;
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
    public void ExtraRescue() 
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
    IEnumerator BlizzardFade()
    {
        yield return new WaitForSeconds(10);
        BlizzardAnimation.SetBool("isFade", false);
    }
   
}
