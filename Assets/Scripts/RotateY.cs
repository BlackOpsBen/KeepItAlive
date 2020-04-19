using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    void Update()
    {
        float newY = transform.localEulerAngles.y + Time.deltaTime * speed;
        transform.localEulerAngles = new Vector3(0f, newY, 0f);
    }
}
