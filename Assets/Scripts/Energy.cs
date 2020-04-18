using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private float energyCap = 10f;
    [SerializeField] private float currentEnergy;

    private void Awake()
    {
        currentEnergy = energyCap;
    }

    public void SetEnergy(float amount)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + amount, 0f, energyCap);
    }
}
