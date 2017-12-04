using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAi : MonoBehaviour {

	private TimeManager TimeManagerScript;
	public Rigidbody2D fireRigidbody;

	public float FireSpeed;

	public Transform Fire;
	public bool StartFire;
	public bool hittingplayer;
	public float PointLength;
	public LayerMask playerMask;

	public float minSpeed;
	public float maxSpeed;
	private playercontroller playerControllerScript;
    private PowerupManager PowerupManagerScript;
    private floorcounterEl FloorCounterScript;
    private PlatformGenerator PlatformGeneratorScript;
    AudioSource FireAudioSource;

//[SerializeField]
    //private AudioSource FireSoundEffect;
	void Start()
	{
		TimeManagerScript = GameObject.Find ("countDown").GetComponent<TimeManager> ();
		playerControllerScript = GameObject.Find ("player").GetComponent<playercontroller> ();
        PowerupManagerScript = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounterEl>();
        PlatformGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
        FireAudioSource = GameObject.Find("Fire").GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("SoundChecker")==0)
        {
            FireAudioSource.Play();

        }
        

        
	}
	void Update()
	{
		FireAction ();
    }

	private void FireAction()
	{
		
		if (StartFire) {
            
			Fire.Translate (Vector3.down * FireSpeed * Time.deltaTime);
			hittingplayer = Physics2D.OverlapCircle (Fire.position,PointLength,playerMask);
			if (hittingplayer) {
				FireSpeed = minSpeed;
			}else if (!hittingplayer){
				FireSpeed = maxSpeed;
			}
           
		}

	}
    
}
		


