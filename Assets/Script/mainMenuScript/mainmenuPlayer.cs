using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuPlayer : MonoBehaviour {

	public float moveSpeed;
	public bool ifRight;
	public bool Check1;

	public bool grounded;
    [SerializeField]
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
    [SerializeField]
    private LevelPass LevelPassScript;
    public bool addSpeed;
    public bool addStar;

    public AudioSource BoltSfx;
    public AudioSource StarSfx;
    public AudioSource HopSfx;

	void start()
	{

     
	}
	private void Awake()
	{

        FireAIscript = GameObject.Find("Fire").GetComponent<FireAi>();
        MyAnimation = GetComponent<Animator>();
        StartCoroutine(IfireStart());
        ifRight = true;
    
	}
    void Update()
    {
                if (grounded = GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
                {
                    if (ifRight)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                        mySpriteRenderer.flipX = true;
                        StartCoroutine(ifRightSwitch());
                    }
                    else
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                        mySpriteRenderer.flipX = false;
                        StartCoroutine(ifNotRightSwitch());
                    }
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;  
                }
    }

    
    IEnumerator ifRightSwitch()
    {
        yield return new WaitForSeconds(1f);
        ifRight = false;
    }
    IEnumerator ifNotRightSwitch()
    {
        yield return new WaitForSeconds(1f);
        ifRight = true;
    }
    IEnumerator IfireStart()
    {
        yield return new WaitForSeconds(1f);
        FireAIscript.StartFire = true;
    }
  
}