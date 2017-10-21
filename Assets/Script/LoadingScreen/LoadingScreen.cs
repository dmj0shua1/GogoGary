using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScreen : MonoBehaviour {

    private bool loadScene = true;

    [SerializeField]
    private int scene;
    [SerializeField]
    private Text loadingText;
    //Scripts
   /* private PlatformGenerator PlatFormGeneratorScript;
    private floorcounter FloorCounterScript;
    private TimeManager TimeManagerScript;
    //value
    public GameObject Platform,FloorCounter,TimeStart;
    public int ObjectiveAmt, FloorAmt, StartingAmt;*/

    void Start() 
    {
        StartCoroutine(LoadNewScene());
        /*PlatFormGeneratorScript = Platform.GetComponent<PlatformGenerator>();
        FloorCounterScript = FloorCounter.GetComponent<floorcounter>();
        TimeManagerScript = TimeStart.GetComponent<TimeManager>();*/
    }
    void Update()
    {
        if (loadScene == true)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
           
        }

        /*PlatFormGeneratorScript.EndGenerate = FloorAmt;
        FloorCounterScript.MainCount = ObjectiveAmt;
        TimeManagerScript.startingTime = StartingAmt;

        print(FloorAmt);
        print(ObjectiveAmt);
        print(StartingAmt);*/

    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);
        AsyncOperation async = Application.LoadLevelAsync(scene);
        while (!async.isDone)
        {
            yield return null;
        }

    }

}
