using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class debrisGeneration : MonoBehaviour {

	public GameObject debris;
	public Transform generationPoint;
	public float distanceBetween;
	public ObjectPooler[] theObjectPools;

	public float randomDebrisThreshold;
	public ObjectPooler debrisPool;
    public bool IsActivate;
    public bool IsDebriActivate;
	private int debrisSelector;
	private float debrisHeight;

    private LevelPass MainHolderScript;
    public floorcounter FloorCounterScript;
    private debrisZone DebriZoneScript;
    private SlowMovement SlowMovementScript;
    public AudioSource FallingDebri;
    //debrisXPosition
    public int DebrisPos1, DebrisPos2;
	void Start()
	{
		debrisHeight = debris.GetComponent<BoxCollider2D>().size.y;
        MainHolderScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();
        int Randomdebri = Random.Range(6, 10);
        if (MainHolderScript.isActivateTipsAmt == true)
        {
            IsActivate = true; 
        }
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "GGGPYRAMID" || sceneName == "GGG" || sceneName == "GGGPREHISTORIC")
        {
            DebrisPos1 = -10;
            DebrisPos2 = 10;
        }
        else if (sceneName == "GGGICEAGE")
        {
            DebrisPos1 = -1;
            DebrisPos2 = /*5;*/ Randomdebri;
        }     
	}
	void Update()
	{	
		DebriGeneration ();
        DebriCheckerMethod();
	}
    private void DebriCheckerMethod() 
    {
        if (FloorCounterScript.CountFloorPlus == FloorCounterScript.CheckCountPlus)
        {
            IsDebriActivate = true;
        }
    }

	private void DebriGeneration()
	{
            //if (FloorCounterScript.CountFloorPlus >= FloorCounterScript.CheckCountPlus)
            //{
        if (IsDebriActivate)
        {
            if (transform.position.y > generationPoint.position.y)
            {
                //debrisSelector = Random.Range(0, theObjectPools.Length);
                transform.position = new Vector3(transform.position.x, transform.position.y + debrisHeight + -distanceBetween, 0);

                if (Random.Range(0f, 100f) < randomDebrisThreshold)
                {
                    GameObject newDebris = debrisPool.GetPooledObject();
                    //float debrisXposition = Random.Range(-10, 10);
                    float debrisXposition = Random.Range(DebrisPos1, DebrisPos2);
                    Vector3 debrisPosition = new Vector3(debrisXposition, debrisHeight, 0f);
                    newDebris.transform.position = transform.position + debrisPosition;
                    newDebris.transform.rotation = transform.rotation;
                    DebriZoneScript = newDebris.gameObject.GetComponent<debrisZone>();
                    DebriZoneScript.MainDebCollider.enabled = false;
                    DebriZoneScript.deb.enabled = true;
                    SlowMovementScript = newDebris.gameObject.GetComponent<SlowMovement>();
                    SlowMovementScript.isDebriGround = false;
                    //SlowMovementScript.isDebriGround = false;

                    if (PlayerPrefs.GetInt("SoundChecker") == 0)
                    {
                        FallingDebri.Play();
                    }
                    //SlowMovementScript = newDebris.gameObject.GetComponent<SlowMovement>();
                    //SlowMovementScript.MyAnimation.SetBool("DestroyDeb", !SlowMovementScript.DestroyBool);


                    DebriZoneScript.DebrisBodyType.bodyType = RigidbodyType2D.Dynamic;
                    newDebris.SetActive(true);
                }


            }  
        }
            
      //}
	}
		
}


