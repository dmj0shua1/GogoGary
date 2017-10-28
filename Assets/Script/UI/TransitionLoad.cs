using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionLoad : MonoBehaviour {

    private bool loadScene = true;

    [SerializeField]
    private Text loadingText;
    public Image LoadingImage;
    public GameObject transLoad;
    private playercontroller playerControllerScript;
    //ViewPanel
    void Start()
    {
        StartCoroutine(LoadNewScene());
        playerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
        playerControllerScript.isAllMove = false;
    }

    void Update()
    {
        if (loadScene == true)
        {
            //loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
            LoadingImage.color = new Color(LoadingImage.color.r,LoadingImage.color.g,LoadingImage.color.b,Mathf.PingPong(Time.time,1));

        }  
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);
        transLoad.SetActive(false);
        playerControllerScript.isAllMove = true;

    }
}
