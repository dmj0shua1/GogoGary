using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjbectTransformPosition : MonoBehaviour {
        
    public GameObject tutorialFloors;
    public float PosX;
    public float PosY;
    public bool IsActivate;
    [SerializeField]
    private LevelPass LevelpassScript;
    [SerializeField]
    private GameLevelHolderManager GamelLevelHolderManagerScript;
    [SerializeField]
    private playercontroller PlayerControllerScript;
    [SerializeField]
    private SwipeTest SwipeTestScript;
    void Awake() 
    {
      
    } 
    void Start()
    {
        LevelpassScript = GameObject.Find("Holder").GetComponent<LevelPass>();
        GamelLevelHolderManagerScript = GameObject.Find("GameLevelManager").GetComponent<GameLevelHolderManager>();
        PlayerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
        SwipeTestScript = GameObject.Find("Swipe").GetComponent<SwipeTest>();


        if (IsActivate)
        {
            tutorialFloors.SetActive(true);
            GameObject.Find("PlatformGeneration").transform.position = new Vector3(PosX,PosY,0);
            //transform.position = new Vector3(0,0,0);
        }
        //VectorObject = GameObject.Find("PlatformGeneration").transform.position;
    
    }
    void Update() 
    {
        if (PlayerControllerScript.Check1 == true)
        {
            GamelLevelHolderManagerScript.SwipeRightObject.SetActive(false);
            GamelLevelHolderManagerScript.HandRightObject.SetActive(false);
        } 
    }

    public void SwipeLeftMethod()
    {
        PlayerControllerScript.isAllMove = true;
        PlayerControllerScript.HandLeftIcon.SetActive(false);
        //PlayerControllerScript.G1Object.SetActive(false);
 
    }

    public void TestActive() {
     
      
    }

}
