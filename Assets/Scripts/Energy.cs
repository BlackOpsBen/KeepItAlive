using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private float defaultMinCap = 10f;
    private float defaultMaxCap = 20f;
    private float containerMaxY = 19.5f;
    [SerializeField] private float energyCap = 10f;
    [SerializeField] private float currentEnergy;

    [SerializeField] private RectTransform container;
    [SerializeField] private RectTransform emptyBar;
    [SerializeField] private RectTransform fillBar;

    private void Awake()
    {
        currentEnergy = energyCap;
    }

    public void SetEnergy(float amount)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + amount, 0f, energyCap);

        UpdateFillBar();
    }

    public void SetCap(float amount)
    {
        energyCap = Mathf.Clamp(energyCap + amount, defaultMinCap, defaultMaxCap);

        float containerNewYScale = Mathf.Lerp(defaultMinCap, containerMaxY, energyCap/defaultMinCap-1);
        container.localScale = new Vector3(container.localScale.x, containerNewYScale, container.localScale.z);

        float emptyBarNewYScale = Mathf.Lerp(defaultMinCap, defaultMaxCap, energyCap / defaultMinCap - 1);
        emptyBar.localScale = new Vector3(emptyBar.localScale.x, emptyBarNewYScale, emptyBar.localScale.z);
    }

    private void UpdateFillBar()
    {
        fillBar.localScale = new Vector3(fillBar.localScale.x, currentEnergy, fillBar.localScale.z);
    }

    private void Update()
    {
        // TODO remove Update
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetCap(1f);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SetEnergy(1f);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SetEnergy(-1f);
        }
    }
}
