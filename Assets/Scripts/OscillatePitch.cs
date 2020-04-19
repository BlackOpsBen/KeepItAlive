using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatePitch : MonoBehaviour
{
    [SerializeField] private float minPitch = 2f;
    [SerializeField] private float maxPitch = 45f;
    [SerializeField] private float multiplier = 0.2f;
    private float counter = 0f;

    private void Update()
    {
        counter += Time.deltaTime;
        float sinCounter = Mathf.Sin(counter * multiplier);
        float t = Mathf.InverseLerp(-1f, 1f, sinCounter);
        float oscX = Mathf.Lerp(minPitch, maxPitch, t);
        transform.localEulerAngles = new Vector3(oscX, 0f, 0f);
    }
}
