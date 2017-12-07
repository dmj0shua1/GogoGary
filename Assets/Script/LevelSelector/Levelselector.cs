using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levelselector : MonoBehaviour {

    public Button[] levelButtons;
    //public int levelReached;

    void Start() 
    {
    }
    public void select(int levelname)
    {
        SceneManager.LoadScene(levelname);

      
    }
    public void selectstring(string levelname)
    {
        SceneManager.LoadScene(levelname);


    }


   
}
