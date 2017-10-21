using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisGeneration : MonoBehaviour {

	public GameObject debris;
	public Transform generationPoint;
	public float distanceBetween;
	public ObjectPooler[] theObjectPools;

	public float randomDebrisThreshold;
	public ObjectPooler debrisPool;
    public bool IsActivate;
	private int debrisSelector;
	private float debrisHeight;

    private LevelPass MainHolderScript;
    public floorcounter FloorCounterScript;
    private debrisZone DebriZoneScript;

	void Start()
	{
		debrisHeight = debris.GetComponent<BoxCollider2D>().size.y;
        MainHolderScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();

        if (MainHolderScript.isActivateTipsAmt == true)
        {
            IsActivate = true; 
        }
	}
	void Update()
	{	
		DebriGeneration ();
	}

	private void DebriGeneration()
	{
        if (IsActivate)
        {
            if (FloorCounterScript.CountFloorPlus >= FloorCounterScript.CheckCountPlus)
            {
            if (transform.position.y > generationPoint.position.y)
            {
                //debrisSelector = Random.Range(0, theObjectPools.Length);
                transform.position = new Vector3(transform.position.x, transform.position.y + debrisHeight + -distanceBetween, 0);

                if (Random.Range(0f, 100f) < randomDebrisThreshold)
                {
                    GameObject newDebris = debrisPool.GetPooledObject();
                    float debrisXposition = Random.Range(-10,10);
                    Vector3 debrisPosition = new Vector3(debrisXposition, debrisHeight, 0f);
                    newDebris.transform.position = transform.position + debrisPosition;
                    newDebris.transform.rotation = transform.rotation;
                    DebriZoneScript = newDebris.gameObject.GetComponent<debrisZone>();
                    DebriZoneScript.MainDebCollider.enabled = false;
                    DebriZoneScript.deb.enabled = true;
                    DebriZoneScript.DebrisBodyType.bodyType = RigidbodyType2D.Dynamic;
                    newDebris.SetActive(true);
                }
            }

        }
      }
	}
		
}


