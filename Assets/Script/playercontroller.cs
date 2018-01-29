using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour {

	public float moveSpeed;
	public bool ifRight;
	public bool Check1;

	public bool grounded;
	private SpriteRenderer mySpriteRenderer;

	public bool OnDebris;
	public float DecreaseSpeed;
	private float currentSpeed;

    public bool isAllMove;
    public GameObject ViewPanel;
    public GameObject PauseButton;
    public GameObject FloorSystemPanel;

	private TimeManager TimeManagerScript;
    private FireAi FireAIscript;
    private Animator MyAnimation;
    private floorcounterEl FloorCounterScript;
    private PlusSpeedManager PlusSpeedManagerScript;
    private PowerupManager PowerupManagerScript;
    private SwipeTest SwipeTestScript;
    [SerializeField]
    private LevelPass LevelPassScript;
    public bool addSpeed;
    public bool addStar;
    public bool addStar2;

    public AudioSource BoltSfx;
    public AudioSource StarSfx;
    //public AudioSource HopSfx;
    public AudioSource Debri_destroy;
    public AudioSource Yes_rescue;
    //public AudioSource booSFX;
    [SerializeField]
    private playercontroller PlayerScript;
    public GameObject temp;
    public GameObject EventBox;
    public GameObject EventBox4;
    public GameObject HandLeftIcon;
    //public GameObject G1Object;
    public GameObject SwipeAgainText;
    //public GameObject HandRightIcon;
    public GameObject Go_Object;
    public bool isCountDownSwipe;
    public Rigidbody2D Player_Gary;
    public bool isCheckBolt;
    SimpleAd SimpleAdScript;
    PointManager PointManagerScript;
    public bool isDebriGround;
    private LevelValueHolder LevelValueHolderScript;
    private GameLevelHolderManager GameLevelHolderManagerScript;
    private floorcounter MainFloorCounterScript;
    ScoreManager scoreManagerScript;

    public bool MummyCollide;
    private CameraFollow CameraFollowScript;
    [Header("WalkThroughwalls")]
    private WalkThroughWalls WalkThroughWallsScript;
    private PlatformGenerator PlatformGeneratorScript;
    private Animator MyAnimationWallofDeath;
	void start()
	{	
		ifRight = true;
     
	}
	private void Awake()
	{
        addStar2 = true;
        MyAnimation = GetComponent<Animator>();
        currentSpeed = moveSpeed;
        isCountDownSwipe = true;
        FloorCounterScript = GetComponent<floorcounterEl>();
        MainFloorCounterScript = GetComponent<floorcounter>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
      
		TimeManagerScript = GameObject.Find ("countDown").GetComponent<TimeManager> ();
        FireAIscript = GameObject.Find("Fire").GetComponent<FireAi>();
        PlusSpeedManagerScript = GameObject.Find("plusspeedManager").GetComponent<PlusSpeedManager>();
        PowerupManagerScript = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        SwipeTestScript = GameObject.Find("Swipe").GetComponent<SwipeTest>();
        SimpleAdScript = GameObject.Find("SimpleAd").GetComponent<SimpleAd>();
        PointManagerScript = GameObject.Find("PointManager").GetComponent<PointManager>();
        GameLevelHolderManagerScript = GameObject.Find("GameLevelManager").GetComponent<GameLevelHolderManager>();
        CameraFollowScript = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        WalkThroughWallsScript = GameObject.Find("player").GetComponent<WalkThroughWalls>();
        PlatformGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
        if (SceneManager.GetActiveScene().name == "GGGPYRAMID") MyAnimationWallofDeath = GameObject.Find("WallOfDeath").GetComponent<Animator>();

      if (SceneManager.GetActiveScene().name == "Endless")  scoreManagerScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
       
	}
	void Update ()
	{
        if (isAllMove) { 
		if (grounded = GetComponent<Rigidbody2D>().IsTouchingLayers (LayerMask.GetMask("Ground")))
        {
            MyAnimation.SetBool("Check1", Check1);
            if (Check1)
            {

                if (ifRight)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                    mySpriteRenderer.flipX = false;
                    /*
                    if ( Player_Gary.bodyType == RigidbodyType2D.Static)
                    {
                        EventBox.SetActive(false);
                        Player_Gary.bodyType = RigidbodyType2D.Dynamic; 
                    }*/
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                    mySpriteRenderer.flipX = true;
                }

            }
            else
            {

            }
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            //SwipeTestScript.isSwipe = true;
         
		}
		else {
            //HopSfx.Play();
            //SwipeTestScript.isSwipe = false;
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			}
        GaryDefend();
        GaryHop();
        HitOnDebris();
        BoltToStar();
        StarToBolt();
   
        }
        GetStarAnimation();
        GetBoltAnimation();
        ContinueBoltAnimation();
        CotinueBoltEffect();
        if (!isCountDownSwipe)
        {
            StartCoroutine(ReadyToSwipe());
            /*if (isCheckBolt == false)
            {
                if (PlusSpeedManagerScript.SpeedTimeLength >=0)
                {
                    PlusSpeedManagerScript.addSpeedActive = true;
                }    
            }*/
            /*if (ifRight == true)
            {
                MyAnimation.enabled = true;
                Player_Gary.bodyType = RigidbodyType2D.Dynamic;
                HandLeftIcon.SetActive(false);
                //G1Object.SetActive(false);
                SwipeAgainText.SetActive(false);
            }*/ 
        } 
	}
    public void GaryHop() 
    {
        MyAnimation.SetBool("Grounded", grounded);
        if (OnDebris)
        {
            moveSpeed = DecreaseSpeed;
            PlusSpeedManagerScript.addSpeedActive = false;
        }
    }
    public void BoltToStar() 
    {
        if (PowerupManagerScript.powerupActive == true)
        {
            PlusSpeedManagerScript.addSpeedActive = false;
            addSpeed = false;
        }
    }
    public void StarToBolt()
    {
        if (PlusSpeedManagerScript.addSpeedActive == true)
        {

            PowerupManagerScript.powerupActive = false;
            
        }
    }
    public void HitOnDebris()
    {
        MyAnimation.SetBool("OnDebris", !OnDebris);
        if (!OnDebris)
        {
            moveSpeed = currentSpeed;
         
            if (PlusSpeedManagerScript.SpeedTimeLength >0)
            {
           
                PlusSpeedManagerScript.addSpeedActive = true;
            }
            else
            {
                addSpeed = false; 
            }
           
        }

        else  
        {
            print("true");

        }

   
   }

    public void GetStarAnimation() 
    {
        MyAnimation.SetBool("addstar", !addStar);
        if (PowerupManagerScript.powerupActive == true)
        {
            addStar = true;
        }
        else
        {
            addStar = false;
        }
    }
    public void GetBoltAnimation()
    {

        if (PlusSpeedManagerScript.addSpeedActive == true)
        {
            addSpeed = true;

        }
    }
    public void ContinueBoltAnimation()
    {
        if (addSpeed ==true)
        {
            MyAnimation.SetBool("addspeed", false);
        }
        else if (addSpeed == false)
        {
            MyAnimation.SetBool("addspeed", true);
        }
       
       
    }
    public void CotinueBoltEffect() 
    {
      
    }
    public void GaryDefend() 
    {
        if (SceneManager.GetActiveScene().name == "GGGPYRAMID") 
        {
            MyAnimation.SetBool("isDefend", MummyCollide);
        }
        else if (SceneManager.GetActiveScene().name == "GGGPREHISTORIC")
        {
            MyAnimation.SetBool("isDefend", MummyCollide);
        }
     
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("FireMain"))
        {

            if (SceneManager.GetActiveScene().name == "Endless") FloorCounterScript.isNoFunction_el = false;
            TimeManagerScript.isStopMainTime = false;
            FireAIscript.minSpeed = 50;
            StartCoroutine(StopFireAnimation());         
            StartCoroutine(GameOverCount());
            StartCoroutine(GameOverDelay());
            //ViewPanel.SetActive(true);
            MainFloorCounterScript.isNoFunction = false; 
            PauseButton.SetActive(false);
            SimpleAdScript.gameOverAd();
            //booSFX.Play();
            CameraFollowScript.isFollow = false;
            grounded = false;
            isAllMove = false;
            /*if (SceneManager.GetActiveScene().name == "GGGPYRAMID") 
            {
                MyAnimationWallofDeath.SetBool("isIdle", true);
                PointManagerScript.wallofdeathparticle1.SetActive(false);
                PointManagerScript.wallofdeathparticle2.SetActive(false);
            }*/
              
          
            //PlayerScript.enabled = false;
             if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
            {
                PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), LevelPassScript.RescuePointAmtCopy);
            }
            //completelevel
             /*if (PlayerPrefs.GetInt("CompleteLevelCounter") >=1)
             {
                 PlayerPrefs.SetInt("CompleteLevelCounter", PlayerPrefs.GetInt("CompleteLevelCounter") - 1);
             }*/
             
            //
             LevelPassScript.TargetLevel = LevelPassScript.ButtonNextLevel[LevelPassScript.CurrentButtonPassAmt];
             LevelValueHolderScript = LevelPassScript.TargetLevel.GetComponent<LevelValueHolder>();
             LevelPassScript.FireTriggerAmt = LevelValueHolderScript.FireTriggerValue;
            
        }
        if (other.CompareTag("bolt")&& PlayerPrefs.GetInt("SoundChecker")==0)
        {
            BoltSfx.Play();
        }

        if (other.CompareTag("Powerup") && PlayerPrefs.GetInt("SoundChecker") == 0)
        {
            StarSfx.Play();
        }
        if (PlayerPrefs.GetInt("SoundChecker") == 0)
        {
            if (other.CompareTag("Man") || other.CompareTag("Woman"))
            {
                Yes_rescue.Play();
            }   
        }
       
        if (other.gameObject.CompareTag("EventBox"))
        {

            Player_Gary.bodyType = RigidbodyType2D.Static;
            MyAnimation.enabled = false;
            HandLeftIcon.SetActive(true);
            //G1Object.SetActive(true);
            SwipeAgainText.SetActive(true);
            isCountDownSwipe = false;
            StartCoroutine(StopEventBox());
        }
        if (other.gameObject.CompareTag("StopCamera"))
        {   //runtooverlaydoor
            if (SceneManager.GetActiveScene().name == "GGGPYRAMID") MyAnimationWallofDeath.SetBool("isIdle", true);
            FireAIscript.StartFire = false;
            SwipeTestScript.enabled = false;
            PointManagerScript.completeLevelCounterMethod();
            if (ifRight == true)
            {
                ifRight = false;
            }
            if (SceneManager.GetActiveScene().name == "GGGPYRAMID")
            {
                MyAnimationWallofDeath.SetBool("isIdle", true);
                PointManagerScript.wallofdeathparticle1.SetActive(false);
                PointManagerScript.wallofdeathparticle2.SetActive(false);
                PointManagerScript.FireSfx.enabled = false;
            }
            print("stopcam");
        }
        /*if (other.gameObject.CompareTag("pyMummy"))
        {
            MummyCollide = false;
        }*/
        if (SceneManager.GetActiveScene().name == "GGGPYRAMID" || SceneManager.GetActiveScene().name == "GGGPREHISTORIC") 
        {
            if (other.gameObject.CompareTag("Hitbox"))
            {
                if (!WalkThroughWallsScript.isChange)
                {
                    WalkThroughWallsScript.isChange = true;
                }
            }
        }
        if (other.CompareTag("debris") && PlayerPrefs.GetInt("SoundChecker") == 0)
        {
            if (addStar && addStar2)
            {
                Debri_destroy.Play();
                addStar2 = false;
            }
        }
       
    }
    void OnTriggerStay2D(Collider2D other)
    {
       
        /*if (other.CompareTag("debris") && PlayerPrefs.GetInt("SoundChecker") == 0)
        {
            if (addStar == true)
            {
                Debri_destroy.Play();
            }
        }*/
        if (other.gameObject.CompareTag("EventBox3"))
        {
            SwipeTestScript.isSwipe = false;
        }
        if (other.gameObject.CompareTag("DoorObjective"))
        {
            PointManagerScript.FloorObjective();
            GameLevelHolderManagerScript.RescueUnlockChecker();
            mySpriteRenderer.enabled = false;
        }
        
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        //SwipeLeftObject.SetActive(false);
        SwipeTestScript.isSwipe = true;
        //MummyCollide = false;
       
    }
    IEnumerator StopFireAnimation()
    {
        yield return new WaitForSeconds(1);
        FireAIscript.StartFire = false;
    }
    IEnumerator StopEventBox()
    {
        yield return new WaitForSeconds(1);
        EventBox.SetActive(false);
    }
    IEnumerator StopEventBox4()
    {
        yield return new WaitForSeconds(3);
        isAllMove = true;
        EventBox4.SetActive(false);
    }
    IEnumerator ReadyToSwipe()
    {
        yield return new WaitForSeconds(1);
        if (ifRight == true)
        {
            MyAnimation.enabled = true;
            Player_Gary.bodyType = RigidbodyType2D.Dynamic;
            HandLeftIcon.SetActive(false);
            //G1Object.SetActive(false);
            SwipeAgainText.SetActive(false);
        }
    }
       IEnumerator GameOverCount()
    {

        if (SceneManager.GetActiveScene().name == "Endless")
        {
            scoreManagerScript.saveHighscore();
            yield return new WaitForSeconds(0.3f);
            ViewPanel.SetActive(true);
            FloorSystemPanel.SetActive(false);
            scoreManagerScript.animateScore();
        } 
    }

       IEnumerator GameOverDelay()
       {

           if (SceneManager.GetActiveScene().name == "GGG" || SceneManager.GetActiveScene().name == "GGGPYRAMID" || SceneManager.GetActiveScene().name == "GGGPREHISTORIC")
           { 
               yield return new WaitForSeconds(0.7f);
               ViewPanel.SetActive(true); 
           }
           if (SceneManager.GetActiveScene().name == "GGGPYRAMID")
           {
               MyAnimationWallofDeath.SetBool("isIdle", true);
               PointManagerScript.wallofdeathparticle1.SetActive(false);
               PointManagerScript.wallofdeathparticle2.SetActive(false);
               PointManagerScript.FireSfx.enabled = false;
           }
       }

    
}
