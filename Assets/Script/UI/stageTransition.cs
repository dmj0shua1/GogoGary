using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageTransition : MonoBehaviour {

    public string SceneToGo;
    public float animDelay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeSceneWithDelay()
    {
        Invoke("changeScene", animDelay);
    }

    private void changeScene()
    {
        SceneManager.LoadScene(SceneToGo);
    }
}
