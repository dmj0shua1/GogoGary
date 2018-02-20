﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingcamerashake : MonoBehaviour {
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;
    // How long the object should shake for.
    public float shakeDuration;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount ;
    public float decreaseFactor;

    public bool IsActiveShake;

    public Vector3 originalPos;
    public Vector3 MovePos;
    // 

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
       
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
      
    }

    void Update()
    {
       
        if (IsActiveShake)
        {
            //MovePos = camTransform.localPosition;
            if (shakeDuration > 0)
            {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            //camTransform.localPosition = MovePos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
            //camTransform2.localPosition = MovePos;
            IsActiveShake = false;
            }
        }
    }

}
