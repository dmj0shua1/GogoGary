using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCameraView : MonoBehaviour {
    public Text LevelNumberText;
    //public Text NumberOfPeopleText;
    public GameObject[] BuildingButtons;
    //public int[] BuildingButtonNum;
    public GameObject target;

    public int ButtonNumberHolder;
    //
    public float speed = 1;
    private Animator MyAnimation;
    public GameObject LevelPanelObject;
    public GameObject PanelDisabled;
    public bool IsActivate;
    private LevelValueHolder LevelValueHolderScript;
    public int LevelStatusHolder;
    public RectTransform ScrollRectMap;
    [SerializeField]
    private MainHolder MainHolderScript;
    public Text NumberOfPeopleText;
    public GameObject TotalRescueObject;
    public GameObject MainMenuObject;
    public GameObject BackBtnObject;
    void Awake() 
    {
    }
  
    void Start() 
    {
        MyAnimation = GetComponent<Animator>();
        MainHolderScript = GameObject.Find("LevelButton1").GetComponent<MainHolder>();
   
    }
    
    public void NumberQue(int BuildingNumber) 
    {
      
     
        ButtonNumberHolder = BuildingNumber;
        MyAnimation.SetBool("IsZoom", true);
        target = BuildingButtons[ButtonNumberHolder];

        StartCoroutine(LoadNewScene());
        TotalRescueObject.SetActive(false);
        MainMenuObject.SetActive(false);
    }
    public void testCheckerRescue() 
    {
        if (PlayerPrefs.HasKey("Building_L" + LevelStatusHolder.ToString()))
        {
            NumberOfPeopleText.text = "" + PlayerPrefs.GetInt("Building_L" + LevelStatusHolder.ToString());
        }
    }
    public void LevelStatusPassToMainHolder() 
    {
        MainHolderScript.LevelStatusPass = LevelStatusHolder;
    }
    public void LevelStatusPass(int StatusNumber) 
    {
        LevelStatusHolder = StatusNumber;
        LevelNumberText.text = "" + LevelStatusHolder;
    }
    public void BackButtonCamera(int CanvasNumber) 
    {
        if (LevelStatusHolder >= 14)
        {
            ScrollRectMap.GetComponent<RectTransform>().localPosition = new Vector3(-10, -716, 0);
        }
        ButtonNumberHolder = CanvasNumber;
        MyAnimation.SetBool("IsZoom", false);
        target = BuildingButtons[ButtonNumberHolder];
        LevelPanelObject.SetActive(false);
        PanelDisabled.SetActive(false);
        TotalRescueObject.SetActive(true);
        MainMenuObject.SetActive(true);


    }
   
    public void BackCameraPosition() 
    {
       //diginagamit
        /*if (LevelStatusHolder == 14)
        {
            transform.Translate(330, -207,-10);
            ScrollRectMap.GetComponent<RectTransform>().localPosition = new Vector3(-10, -716, 0);
        }*/
    }
    public void NextButton() 
    {
       
        if (PlayerPrefs.HasKey("Building_L" + LevelStatusHolder.ToString()))
        {
            NumberOfPeopleText.text = "" + PlayerPrefs.GetInt("Building_L" + LevelStatusHolder.ToString());
        }
        if (ButtonNumberHolder <= 23)
        {
            LevelStatusHolder = LevelStatusHolder + 1;
            LevelNumberText.text = "" + LevelStatusHolder;
            ButtonNumberHolder = ButtonNumberHolder + 1;
            target = BuildingButtons[ButtonNumberHolder];
            MainHolderScript.LevelStatusPass = LevelStatusHolder;
            LevelValueHolderScript = target.GetComponent<LevelValueHolder>();
            LevelValueHolderScript.PassValue();
            //LevelStatusHolder = LevelStatusHolder - 1;
            //ButtonNumberHolder = ButtonNumberHolder - 1;
        }
       
    }
    public void backButton()
    {
        if (ButtonNumberHolder >=1)
        {
            LevelStatusHolder = LevelStatusHolder - 1;
            ButtonNumberHolder = ButtonNumberHolder - 1;
        }
        
        LevelNumberText.text = "" + LevelStatusHolder;

        target = BuildingButtons[ButtonNumberHolder];
        MainHolderScript.LevelStatusPass = LevelStatusHolder;
        LevelValueHolderScript = target.GetComponent<LevelValueHolder>();
        LevelValueHolderScript.PassValue();
        if (PlayerPrefs.HasKey("Building_L" + LevelStatusHolder.ToString()))
        {
            NumberOfPeopleText.text = "" + PlayerPrefs.GetInt("Building_L" + LevelStatusHolder.ToString());
        }
    }
 
    void Update()
    {
        MoveTowardsTarget();
        
      
 
    }
    //move towards a target at a set speed.
    private void MoveTowardsTarget()
    {
        //the speed, in units per second, we want to move towards the target

        //move towards the center of the world (or where ever you like)
        Vector3 targetPosition = target.transform.position;

        Vector3 currentPosition = this.transform.position;
        //first, check to see if we're close enough to the target
        if (Vector3.Distance(currentPosition, targetPosition) > .1f)
        {
            Vector3 directionOfTravel = targetPosition - currentPosition;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();
            //scale the movement on each axis by the directionOfTravel vector components

            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (0),
                Space.World);
        }
    }
    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(1);
        LevelPanelObject.SetActive(true);
    }
}
