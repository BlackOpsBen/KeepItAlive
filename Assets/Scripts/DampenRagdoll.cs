using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampenRagdoll : MonoBehaviour
{
    [SerializeField] private float smoothness = 5f;
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * smoothness);
    }
}
