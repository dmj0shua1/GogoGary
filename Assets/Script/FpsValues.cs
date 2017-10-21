using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsValues : MonoBehaviour {

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 30;
    }
}
