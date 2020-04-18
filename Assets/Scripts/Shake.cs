using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private float shakeMultiplier = 2f;
    [SerializeField] private float shakeDecay = 10f;
    private float shakeIntensity = 0f;

    private Vector3 shakePos;
    void Update()
    {
        if (shakeIntensity > float.Epsilon)
        {
            shakePos.x = Random.Range(-1f, 1f);
            shakePos.y = Random.Range(-1f, 1f);
            shakePos.z = Random.Range(-1f, 1f);
            shakePos *= shakeIntensity;
            transform.localPosition = Vector3.Lerp(Vector3.zero, shakePos, Time.deltaTime * shakeMultiplier);
            shakeIntensity = Mathf.Lerp(shakeIntensity, 0f, Time.deltaTime * shakeDecay);
        }
    }

    public void ShakeCamera(float intensity)
    {
        shakeIntensity = intensity;
    }
}
