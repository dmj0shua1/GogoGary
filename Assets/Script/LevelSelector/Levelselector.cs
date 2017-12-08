using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levelselector : MonoBehaviour {

    public Button[] levelButtons;
    public GameObject MainHolderScript;
    //public int levelReached;

    void Start() 
    {
        MainHolderScript = GameObject.Find("Holder");
    }
    public void select(int levelname)
    {
        SceneManager.LoadScene(levelname);
        Destroy(MainHolderScript);
      
    }
    public void selectstring(string levelname)
    {
        SceneManager.LoadScene(levelname);


    }


   
}
