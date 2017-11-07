using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private TimeManager TimeManagerScript;
    private FireAi FireAIscript;
    private Animator MyAnimation;
    private floorcounter FloorCounterScript;
    private PlusSpeedManager PlusSpeedManagerScript;
    private PowerupManager PowerupManagerScript;
    private SwipeTest SwipeTestScript;
    [SerializeField]
    private LevelPass LevelPassScript;
    public bool addSpeed;
    public bool addStar;

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
	void start()
	{	
		ifRight = true;
     
	}
	private void Awake()
	{
        MyAnimation = GetComponent<Animator>();
        currentSpeed = moveSpeed;
        isCountDownSwipe = true;
        FloorCounterScript = GetComponent<floorcounter>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		TimeManagerScript = GameObject.Find ("countDown").GetComponent<TimeManager> ();
        FireAIscript = GameObject.Find("Fire").GetComponent<FireAi>();
        PlusSpeedManagerScript = GameObject.Find("plusspeedManager").GetComponent<PlusSpeedManager>();
        PowerupManagerScript = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        SwipeTestScript = GameObject.Find("Swipe").GetComponent<SwipeTest>();
        SimpleAdScript = GameObject.Find("SimpleAd").GetComponent<SimpleAd>();
       
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
        GaryHop();
        HitOnDebris();
        }
        GetStarAnimation();
        GetBoltAnimation();
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
           
        }
        else
        {
            print("true");
            //PlusSpeedManagerScript.addSpeedActive = true;
            
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
        MyAnimation.SetBool("addspeed", !addSpeed);
        if (PlusSpeedManagerScript.addSpeedActive == true)
        {
            addSpeed = true;
        }
        else
        {
            addSpeed = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("FireMain"))
        {
            FloorCounterScript.isNoFunction = false;
            TimeManagerScript.isStopMainTime = false;
            FireAIscript.minSpeed = 50;
            ViewPanel.SetActive(true);
            PauseButton.SetActive(false);
            SimpleAdScript.gameOverAd();
            //booSFX.Play();
            StartCoroutine(StopFireAnimation());
            PlayerScript.enabled = false;
             if (PlayerPrefs.HasKey("Building_L" + LevelPassScript.UnlockLevelAmt.ToString()))
            {
                PlayerPrefs.SetInt("Building_L" + LevelPassScript.UnlockLevelAmt.ToString(), LevelPassScript.RescuePointAmtCopy);
            }
        }
        if (other.CompareTag("bolt"))
        {
            BoltSfx.Play();
        }

        if (other.CompareTag("Powerup"))
        {
            StarSfx.Play();
        }
        if (other.CompareTag("Man") || other.CompareTag("Woman"))
        {
            Yes_rescue.Play();
        } if (other.gameObject.CompareTag("EventBox"))
        {

            Player_Gary.bodyType = RigidbodyType2D.Static;
            MyAnimation.enabled = false;
            HandLeftIcon.SetActive(true);
            //G1Object.SetActive(true);
            SwipeAgainText.SetActive(true);
            isCountDownSwipe = false;
            StartCoroutine(StopEventBox());
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("debris"))
        {
            if (addStar == true)
            {
                Debri_destroy.Play();
            }
        }
        if (other.gameObject.CompareTag("EventBox3"))
        {
            SwipeTestScript.isSwipe = false;
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        //SwipeLeftObject.SetActive(false);
        SwipeTestScript.isSwipe = true;
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
    
}