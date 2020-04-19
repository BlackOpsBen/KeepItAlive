using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] GameObject footStepSoundObject;
    public void FootStep()
    {
        Instantiate(footStepSoundObject, transform.position, Quaternion.identity);
    }
}
