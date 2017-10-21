using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLoad : MonoBehaviour {
    private MainHolder MainholderScript;
    private LevelValueHolder LevelValueHolderScript;
    public GameObject TargetHolder;
	void Start () {
        MainholderScript = GameObject.Find("Holder").GetComponent<MainHolder>();
	}
    public void NextLevelButton() 
    {
        
 
    }
	void Update () {
		
	}
    public void select(int SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
