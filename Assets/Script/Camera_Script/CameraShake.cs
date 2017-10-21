using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float shakeStrength;
    public float shakeDecay;
    public bool IsShake;
    float shake_decay;
    float shake_intensity;

    Vector3 originPosition;
    Quaternion originRotation;
    Transform _transform;

    void OnEnable()
    {
        _transform = transform;
    }

    IEnumerator ShakeIt()
    {
        while (shake_intensity > 0f)
        {
            _transform.localPosition = originPosition + Random.insideUnitSphere * shake_intensity;
            _transform.localRotation = new Quaternion(
                originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
                /*originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .0f*/0,
                /*originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .0f*/0);
            shake_intensity -= shakeDecay;
            yield return null;
        }

        ShakingStopped();

        yield return null;
    }

    void ShakingStopped()
    {
        _transform.localPosition = originPosition;
        _transform.localRotation = originRotation;
    }

    public void Shake()
    {
        
        if (IsShake)
        {
            IsShake = false;
            originPosition = _transform.localPosition;
            originRotation = _transform.localRotation;

            shake_intensity = shakeStrength;
            StartCoroutine("ShakeIt");  
        }
    }

}