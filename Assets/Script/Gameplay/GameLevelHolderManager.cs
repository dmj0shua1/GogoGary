using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelHolderManager : MonoBehaviour {
    [SerializeField]
    private PlatformGenerator PlatFormGeneratorScript;
    [SerializeField]
    private floorcounter FloorCounterScript;
    [SerializeField]
    private TimeManager TimeManagerScript;
    [SerializeField]
    private debrisGeneration debrisGenerationScript;
    [SerializeField]
    private PowerupGeneration PowerupGenerationScript;
    [SerializeField]
    private LevelPass LevelPassScript;
    [SerializeField]
    private OjbectTransformPosition ObjectTransformScript;
    public GameObject debriTipsObject, starTipsObject, boltTipsObject,ShakeTipsObject;
    public bool debriTipsShow, starTipsShow, boltTipsShow,ShakeTips;
    [Header("Tutorial")]
    public GameObject SwipeRightObject;
    public GameObject HandRightObject;

    void Awake() 
    {
        PlatFormGeneratorScript = GameObject.Find("PlatformGeneration").GetComponent<PlatformGenerator>();
        FloorCounterScript = GameObject.Find("player").GetComponent<floorcounter>();
        TimeManagerScript = GameObject.Find("countDown").GetComponent<TimeManager>();
        debrisGenerationScript = GameObject.Find("DebrisGeneration").GetComponent<debrisGeneration>();
        PowerupGenerationScript = GameObject.Find("PowerupGeneration").GetComponent<PowerupGeneration>();
        LevelPassScript = GameObject.Find("Holder").GetComponent<LevelPass>();

        PlatFormGeneratorScript.EndGenerate =LevelPassScript.FloorAmt;
        FloorCounterScript.MainCount = LevelPassScript.ObjectiveAmt;
        TimeManagerScript.startingTime = LevelPassScript.StartingAmt;
        debrisGenerationScript.randomDebrisThreshold = LevelPassScript.DebrisAmt;
        PlatFormGeneratorScript.timeThreshold = LevelPassScript.TimeAmt;
        FloorCounterScript.halfFloorPoint = LevelPassScript.HalfObjectiveAmt;
        PlatFormGeneratorScript.powerupThreshold = LevelPassScript.PowerupAmt;
        debrisGenerationScript.IsActivate = LevelPassScript.isActivateTipsAmt;
        PlatFormGeneratorScript.AmountRescuePoint = LevelPassScript.RescuePointAmt;
        debriTipsShow = LevelPassScript.debriTipsAmt;
        starTipsShow = LevelPassScript.starTipsAmt;
        ShakeTips = LevelPassScript.shakeTipsAmt;
        boltTipsShow = LevelPassScript.boltTipsAmt;

        if (debriTipsShow)
        {
            debriTipsObject.SetActive(true);
           
        }
        else if (starTipsShow)
        {
            starTipsObject.SetActive(true);
        }
        else if (ShakeTips)
        {
            ShakeTipsObject.SetActive(true);
        }
         else if (boltTipsShow)
        {
            boltTipsObject.SetActive(true); 
        }
        else if (LevelPassScript.UnlockLevelAmt == 1)
        {
           ObjectTransformScript.IsActivate = true;
           SwipeRightObject.SetActive(true);
           HandRightObject.SetActive(true);

        }
    }

}
