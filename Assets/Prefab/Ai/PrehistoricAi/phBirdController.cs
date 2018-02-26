using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phBirdController : MonoBehaviour {

    private playercontroller ThePlayer;
    public Transform GoRightObject;
    public Transform GoLeftObject;

    public float moveSpeed;
    public float playerRange;

    public LayerMask playerLayer;
    
    public bool playerInRange;
    public bool facingAway;
    public bool followOnLookAway;
    public bool On;
    private SpriteRenderer mySpriteRenderer;
    private PhBirdManager phBirdManagerScript;
    public float EffectLengthCounter;
    public bool effectMode;
    public bool Activate;
    //
    public float posX1;
    public float posY1;
    public float posX2;
    public float posY2;
    public float _moveSpeed;
    public bool moveRight;
    public Transform BirdTransform;
    public float DistancePos;
    public bool action;
    [SerializeField]
    private playercontroller PlayerControllerScript;
    private Animator MyAnimation;
    public Collider2D MainCollider;
    public bool isCollide;

    public AudioSource ph_BirdAttack;
    public bool isPlayBirdAttackSfx;

    //function1
    /*void Start() 
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        ThePlayer = FindObjectOfType<playercontroller>();
        phBirdManagerScript = GameObject.Find("BirdManager").GetComponent<PhBirdManager>();
        Activate = true;
    }

    void Update() 
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        
        if (!followOnLookAway)
        {
            if (playerInRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, moveSpeed * Time.deltaTime);
                return;
            }
        }

        if ((ThePlayer.transform.position.x < transform.position.x && ThePlayer.transform.localScale.x < 0) || (ThePlayer.transform.position.x > transform.position.x && ThePlayer.transform.localScale.x > 0))
        {
            facingAway = true;
            mySpriteRenderer.flipX = true;
        }
        else
        {
            facingAway = false;
            mySpriteRenderer.flipX = false;
        }

        if (playerInRange && facingAway)
        {
            transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, moveSpeed * Time.deltaTime);
         
            
        }
        if (!Activate)
        {
            //transform.position += Vector3.up * moveSpeed;
        StartCoroutine(isMoveEnabled());
        }
    }

    void OnDrawGizmosSelected()
    {
        if (On)
        {
            Gizmos.DrawSphere(transform.position, playerRange);
        }
     
    }

    public void BirdAttackMethod() 
    {
        if (Activate)
        {
            phBirdManagerScript.ActivateBirdeffect(effectMode, EffectLengthCounter);
            Activate = false;
            playerRange = 0;
          
        }
      
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            BirdAttackMethod();

        }
    }



    IEnumerator isMoveEnabled()
    {
        yield return new WaitForSeconds(0.8f);
        transform.position += Vector3.up * Time.deltaTime*moveSpeed;
      
    }*/
    //
    void Start() 
    {
        action = true;
        MyAnimation = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        phBirdManagerScript = GameObject.Find("BirdManager").GetComponent<PhBirdManager>();
        GoRightObject = GameObject.Find("GoRight").GetComponent<Transform>();
        GoLeftObject = GameObject.Find("GoLeft").GetComponent<Transform>();
        PlayerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
        MainCollider = GetComponent<Collider2D>();
        ph_BirdAttack = GameObject.Find("ph_birdAttack").GetComponent<AudioSource>();
    }
    void Update() 
    {
        DistancePos = BirdTransform.transform.position.x;
        
            if (DistancePos > 21)
            {
                StartCoroutine(isMoveTrue());
            }
            else if (DistancePos < -16)
            {
                StartCoroutine(isMovefalse());
            }
            if (!moveRight)
            {
                transform.localScale = new Vector3(posX1, posY1, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(_moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            }
            else if (moveRight)
            {
                transform.localScale = new Vector3(posX2, posY2, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-_moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            }
            if (_moveSpeed == 0)
            {
                StartCoroutine(isGoAway());
            }
            if (isCollide)
            {
                MainCollider.enabled = true;
            }
    }

    IEnumerator isGoAway()
    {
        yield return new WaitForSeconds(0.8f);
        //transform.position += Vector3.up * Time.deltaTime * 20;
        if (moveRight)
        {
            mySpriteRenderer.flipX = true;
            transform.position = Vector3.MoveTowards(transform.position, GoRightObject.transform.position, 30 * Time.deltaTime);
        } else if (!moveRight)
        {
            mySpriteRenderer.flipX = true;
            transform.position = Vector3.MoveTowards(transform.position, GoLeftObject.transform.position, 30 * Time.deltaTime);
        }
  
    }
    IEnumerator isMoveTrue()
    {
        yield return new WaitForSeconds(0.1f);
        moveRight = true;
    }

    IEnumerator isMovefalse()
    {
        yield return new WaitForSeconds(0.1f);
        moveRight = false;
    }
    IEnumerator isCollideTime()
    {
        yield return new WaitForSeconds(0.2f);
        isCollide = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayBirdAttackSfx = true;
            if (PlayerPrefs.GetInt("SoundChecker") == 0)
            {
                if (isPlayBirdAttackSfx)
                {
                    ph_BirdAttack.Play();
                    isPlayBirdAttackSfx = false;
                }
               
            }
            /*if (PlayerControllerScript.grounded || !PlayerControllerScript.grounded)
            {
                //AttackMethod();
                //_moveSpeed = 0;
                //MyAnimation.SetBool("isAttack", false);
                float PlayerTransform = other.gameObject.transform.position.x;
                float MummyTransform = gameObject.transform.position.x;
                if (PlayerTransform > MummyTransform)
                {
                    //rightmummy
                    AttackMethod();
                    _moveSpeed = 0;
                    moveRight = false;

                }
                else
                {
                    //leftMummy
                    AttackMethod();
                    _moveSpeed = 0;
                    moveRight = true;
                }

            }*/

        }
        if (other.gameObject.CompareTag("HitBoxCam"))
        {
            gameObject.SetActive(false);
  

       }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
         
            if (PlayerControllerScript.grounded)
            {
                MyAnimation.SetBool("isAttack", false);
                PlayerControllerScript.MummyCollide = false;
            }
            //
            if (PlayerControllerScript.grounded || !PlayerControllerScript.grounded)
            {
                //AttackMethod();
                //_moveSpeed = 0;
                //MyAnimation.SetBool("isAttack", false);
                float PlayerTransform = other.gameObject.transform.position.x;
                float MummyTransform = gameObject.transform.position.x;
                if (PlayerTransform > MummyTransform)
                {
                    //rightmummy
                    AttackMethod();
                    _moveSpeed = 0;
                    moveRight = false;
               

                }
                else
                {
                    //leftMummy
                    AttackMethod();
                    _moveSpeed = 0;
                    moveRight = true;
                   
                }

            }
            //
        }
        if (other.gameObject.CompareTag("Hitbox"))
        {
            MainCollider.enabled = false;
            isCollide = false;
        
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        MyAnimation.SetBool("isAttack", true);
        PlayerControllerScript.MummyCollide = true;
        StartCoroutine(isCollideTime());
       
    }

    public void AttackMethod() 
    {
        phBirdManagerScript.ActivateBirdeffect(effectMode, EffectLengthCounter);
        //PlayerControllerScript.MummyCollide = false;
    }
}
