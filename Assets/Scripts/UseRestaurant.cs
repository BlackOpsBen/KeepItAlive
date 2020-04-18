using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRestaurant : MonoBehaviour
{
    [SerializeField] private float feedbackIntensity = 10f;
    public void OnUseBuilding()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        Debug.Log(gameObject.name + " used!");
    }
}
