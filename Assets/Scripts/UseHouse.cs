using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHouse : MonoBehaviour
{
    [SerializeField] private float feedbackIntensity = 20f;
    public void OnUseBuilding()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        Debug.Log(gameObject.name + " used!");
    }
}
