using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitch : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float pitchShiftMax = 0.1f;
    void Awake()
    {
        audioSource.pitch += UnityEngine.Random.Range(-pitchShiftMax, pitchShiftMax);
    }
}
