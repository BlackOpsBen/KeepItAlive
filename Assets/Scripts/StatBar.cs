using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    private float defaultMinCap = 10f;
    private float defaultMaxCap = 20f;
    private float containerMaxY = 19.5f;
    private float statCap = 10f;
    private float currentAmount;

    [SerializeField] private RectTransform container;
    [SerializeField] private RectTransform emptyBar;
    [SerializeField] private RectTransform fillBar;

    [SerializeField] private float capDecayInterval = 10f;
    [SerializeField] private float capDecayAmount = 0.5f;

    private void Awake()
    {
        currentAmount = statCap;
    }

    private void Start()
    {
        StartCoroutine(CapDecay());
    }

    private IEnumerator CapDecay()
    {
        while (true)
        {
            yield return new WaitForSeconds(capDecayInterval);
            if (statCap > defaultMinCap)
            {
                SetCap(-capDecayAmount);
                GainOrLoseAmount(0);
            }
        }
    }

    public void GainOrLoseAmount(float amount)
    {
        currentAmount = Mathf.Clamp(currentAmount + amount, 0f, statCap);

        UpdateFillBar();
    }

    public void SetCap(float amount)
    {
        statCap = Mathf.Clamp(statCap + amount, defaultMinCap, defaultMaxCap);

        float containerNewYScale = Mathf.Lerp(defaultMinCap, containerMaxY, statCap/defaultMinCap-1);
        container.localScale = new Vector3(container.localScale.x, containerNewYScale, container.localScale.z);

        float emptyBarNewYScale = Mathf.Lerp(defaultMinCap, defaultMaxCap, statCap / defaultMinCap - 1);
        emptyBar.localScale = new Vector3(emptyBar.localScale.x, emptyBarNewYScale, emptyBar.localScale.z);
    }

    private void UpdateFillBar()
    {
        fillBar.localScale = new Vector3(fillBar.localScale.x, currentAmount, fillBar.localScale.z);
    }

    public float GetCurrentAmount()
    {
        return currentAmount;
    }

    public float GetStatCap()
    {
        return statCap;
    }

    public bool GetIsMaxedOut()
    {
        return statCap >= defaultMaxCap;
    }
}
