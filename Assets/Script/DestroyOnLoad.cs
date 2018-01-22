using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLoad : MonoBehaviour {

    public GameObject MainHolderScript;

    void Start()
    {
        MainHolderScript = GameObject.Find("Holder");
    }

    public void DestroyHolder()
    {
        Destroy(MainHolderScript);
    }
}
