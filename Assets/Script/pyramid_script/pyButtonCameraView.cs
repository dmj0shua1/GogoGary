using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class pyButtonCameraView : MonoBehaviour {
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
    private pyLevelValueHolder LevelValueHolderScript;
    public int LevelStatusHolder;
    public int LevelDisplayHolder;
    public RectTransform ScrollRectMap;
    [SerializeField]
    private MainHolder MainHolderScript;
    public Text NumberOfPeopleText;
    public GameObject TotalRescueObject;
    public GameObject MainMenuObject;
    public GameObject BackBtnObject;
    public GameObject btnNextStage;
    public GameObject btnPrevStage;
    public GameObject stageLabel;
    public GameObject RescueLevelCheckObject;
    public Button LevelButtonPlay;
    public bool isZoomIn;
    public Animator isInMessage;
    public GameObject buttonZoomOutScreen;
    //stage2
    public GameObject text16Object;
    public GameObject text21Object;
    public GameObject NoticeObject;
    public GameObject CloseButtonObject;
    public Button isBackButton;
    public Button isNextButton;


    void Awake() 
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage1")
        {
            testCheckerRescue();
        }*/
   
    }
  
    void Start() 
    {
        MyAnimation = GetComponent<Animator>();
        MainHolderScript = GameObject.Find("LevelButton1").GetComponent<MainHolder>();
          
    }
 
    public void RescueCheckerLevelMethod() 
    {
        if (PlayerPrefs.GetInt("UnlockLevels") == 41)
        {
            if (LevelStatusHolder >= 41)
            {

                if (PlayerPrefs.GetInt("pyTotalRescuePoints") != 45)
                {

                    isInMessage.SetBool("isIn", true);
                    RescueLevelCheckObject.SetActive(true);
                    LevelButtonPlay.interactable = false;
                    text16Object.SetActive(true);
                    if (PlayerPrefs.GetInt("pyisNotice") != 2)
                    {
                        PlayerPrefs.SetInt("pyisNotice", 1);
                    }
                }
                else
                {
                    isInMessage.SetBool("isIn", false);
                    PlayerPrefs.SetInt("pyisNotice", 0);
                    NoticeObject.SetActive(false);
                }
            }

            else
            {
                isInMessage.SetBool("isIn", false);
                //RescueLevelCheckObject.SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt("UnlockLevels") == 46)
        {
            if (LevelStatusHolder >= 46)
            {
                if (PlayerPrefs.GetInt("pyTotalRescuePoints") != 60)
                {
                    isInMessage.SetBool("isIn", true);
                    RescueLevelCheckObject.SetActive(true);
                    LevelButtonPlay.interactable = false;
                    text21Object.SetActive(true);
                    if (PlayerPrefs.GetInt("pyisNotice") != 2)
                    {
                        PlayerPrefs.SetInt("pyisNotice", 1);

                    }
                }
                else
                {
                    isInMessage.SetBool("isIn", false);
                    PlayerPrefs.SetInt("pyisNotice", 0);
                    NoticeObject.SetActive(false);
                }
            }


            else
            {
                isInMessage.SetBool("isIn", false);
                //RescueLevelCheckObject.SetActive(false);
            }
        }
       
        
 
    }
   
    
    public void NumberQue(int BuildingNumber) 
    {
        ButtonNumberHolder = BuildingNumber;
        MyAnimation.SetBool("IsZoom", true);
        target = BuildingButtons[ButtonNumberHolder];
        StartCoroutine(LoadNewScene());
        StartCoroutine(ButtonZoomOutMethod());
        TotalRescueObject.SetActive(false);
        MainMenuObject.SetActive(false);
        btnNextStage.SetActive(false);
        btnPrevStage.SetActive(false);
        stageLabel.SetActive(false);
        isZoomIn = true;
        if (ButtonNumberHolder == 0)
        {
            isBackButton.interactable = false;
        }
        else if (ButtonNumberHolder ==24)
        {
            isNextButton.interactable = false;
        }
       
    }
    IEnumerator ButtonZoomOutMethod()
    {
        yield return new WaitForSeconds(2f);
        buttonZoomOutScreen.SetActive(true);
    }
    public void testCheckerRescue() 
    {
        
        if (PlayerPrefs.HasKey("pyBuilding_L" + LevelStatusHolder.ToString()))
        {
            NumberOfPeopleText.text = "" + PlayerPrefs.GetInt("pyBuilding_L" + LevelStatusHolder.ToString());
        }
    }
    public void LevelStatusPassToMainHolder() 
    {
        MainHolderScript.LevelStatusPass = LevelStatusHolder;
    }
    public void LevelStatusPass(int StatusNumber) 
    {
        LevelStatusHolder = StatusNumber;
        //LevelNumberText.text = "" + LevelStatusHolder;
       //DisplayLevelHolder 
       LevelDisplayHolder = StatusNumber-25;
       LevelNumberText.text = "" + LevelDisplayHolder;

    }
    public void BackButtonCamera(int CanvasNumber) 
    {
        if (LevelStatusHolder >= 39)
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
        btnNextStage.SetActive(true);
        btnPrevStage.SetActive(true);
        stageLabel.SetActive(true);
        isZoomIn = false;
        LevelStatusHolder = 0;
        isInMessage.SetBool("isIn", false);
        buttonZoomOutScreen.SetActive(false);

        if (PlayerPrefs.GetInt("pyisNotice") == 1)
        {
            PlayerPrefs.SetInt("pyisNotice", 2);
            RescueLevelCheckObject.SetActive(false);
        }
        //RescueLevelCheckObject.SetActive(false);
        isBackButton.interactable = true;
        isNextButton.interactable = true;
      
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
       
      
        if (ButtonNumberHolder <= 23)
        {
           //displayLevel
            LevelDisplayHolder = LevelDisplayHolder + 1;
            LevelNumberText.text = "" + LevelDisplayHolder;
            //
            LevelStatusHolder = LevelStatusHolder + 1;
            //LevelNumberText.text = "" + LevelStatusHolder;
            ButtonNumberHolder = ButtonNumberHolder + 1;
            target = BuildingButtons[ButtonNumberHolder];
            MainHolderScript.LevelStatusPass = LevelStatusHolder;
            LevelValueHolderScript = target.GetComponent<pyLevelValueHolder>();
            LevelValueHolderScript.PassValue();
            if (PlayerPrefs.HasKey("pyBuilding_L" + LevelStatusHolder.ToString()))
            {
                NumberOfPeopleText.text = "" + PlayerPrefs.GetInt("pyBuilding_L" + LevelStatusHolder.ToString());
            }
            //LevelStatusHolder = LevelStatusHolder - 1;
            //ButtonNumberHolder = ButtonNumberHolder - 1;
        }
        if (ButtonNumberHolder ==24)
        {
            isNextButton.interactable = false;
        }
        if (isBackButton.interactable == false)
        {
           isBackButton.interactable =true; 
        }

       
    }

    public void backButton()
    {
        if (ButtonNumberHolder >=1)
        {
            //displayLevel
            LevelDisplayHolder = LevelDisplayHolder - 1;
            LevelStatusHolder = LevelStatusHolder - 1;
            ButtonNumberHolder = ButtonNumberHolder - 1;
            
        }
        if(ButtonNumberHolder ==0)
        {
            isBackButton.interactable = false;
        }
        if (isNextButton.interactable == false)
        {
            isNextButton.interactable = true;
        }
     
        LevelNumberText.text = "" + LevelDisplayHolder;
        //
        //LevelNumberText.text = "" + LevelStatusHolder;

        target = BuildingButtons[ButtonNumberHolder];
        MainHolderScript.LevelStatusPass = LevelStatusHolder;
        LevelValueHolderScript = target.GetComponent<pyLevelValueHolder>();
        LevelValueHolderScript.PassValue();
        if (PlayerPrefs.HasKey("pyBuilding_L" + LevelStatusHolder.ToString()))
        {
            NumberOfPeopleText.text = "" + PlayerPrefs.GetInt("pyBuilding_L" + LevelStatusHolder.ToString());
        }
    }
 
    void Update()
    {
        MoveTowardsTarget();
        NoticeSignOn();
    }
    public void NoticeSignOn()
    {
        if (PlayerPrefs.GetInt("pyisNotice") == 2)
        {

            if (!isZoomIn)
            {
                NoticeObject.SetActive(true);
                CloseButtonObject.SetActive(true);
            }
            else
            {

                NoticeObject.SetActive(false);
                RescueLevelCheckObject.SetActive(false);
            }

        }
    }

    public void NoticeEnabled()
    {
        RescueLevelCheckObject.SetActive(true);
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
        RescueCheckerLevelMethod();
    }
}
