﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject HeartBar;
    [SerializeField] private GameObject EnergyBar;
    [SerializeField] private GameObject MoneyBalanceField;

    [SerializeField] private float heartDecay = 0.5f;

    private float heartGainDefault = 1f;
    private float heartCapGainDefault = 1f;
    private float energySpendDefault = 2f;
    private float energyGainDefault = 1f;
    private float energyCapGainDefault = 1f;
    private int moneyGainDefault = 100;
    private int moneySpendDefault = 20;

    [SerializeField] public Transform moneyIcon;
    [SerializeField] public Transform heartIcon;
    [SerializeField] public Transform energyIcon;

    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SceneLoadManager.Instance.SetCanRestart(false);
    }

    private void Update()
    {
        HeartDecays();
        if (HeartBar.GetComponent<StatBar>().GetCurrentAmount() <= float.Epsilon && !isGameOver)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        DisablePlayerInteraction();
        GetComponentInChildren<DivorceOverlay>().ShowOverlay();
    }

    private void DisablePlayerInteraction()
    {
        FindObjectOfType<PlayerMovement>().enabled = false;
        Building[] buildings = FindObjectsOfType<Building>();
        foreach (Building building in buildings)
        {
            building.enabled = false;
        }
    }

    private void HeartDecays()
    {
        if (MoneyBalanceField.GetComponent<MoneyCounter>().GetCurrentBalance() <= 0)
        {
            HeartBar.GetComponent<StatBar>().GainOrLoseAmount(-heartDecay * Time.deltaTime * 2);
        }
        else
        {
            HeartBar.GetComponent<StatBar>().GainOrLoseAmount(-heartDecay * Time.deltaTime);
        }
    }

    public void GainHeart(float amount)
    {
        HeartBar.GetComponent<StatBar>().GainOrLoseAmount(amount);
    }

    public void GainHeart()
    {
        HeartBar.GetComponent<StatBar>().GainOrLoseAmount(heartGainDefault);
    }

    public void IncreaseHeartCap(float amount)
    {
        HeartBar.GetComponent<StatBar>().SetCap(amount);
    }

    public void IncreaseHeartCap()
    {
        HeartBar.GetComponent<StatBar>().SetCap(heartCapGainDefault);
    }

    public void SpendEnergy(float amount)
    {
        EnergyBar.GetComponent<StatBar>().GainOrLoseAmount(-amount);
    }

    public void SpendEnergy()
    {
        EnergyBar.GetComponent<StatBar>().GainOrLoseAmount(-energySpendDefault);
    }

    public void GainEnergy(float amount)
    {
        EnergyBar.GetComponent<StatBar>().GainOrLoseAmount(amount);
    }

    public void GainEnergy()
    {
        EnergyBar.GetComponent<StatBar>().GainOrLoseAmount(energyGainDefault);
    }

    public void IncreaseEnergyCap(float amount)
    {
        EnergyBar.GetComponent<StatBar>().SetCap(amount);
    }

    public void IncreaseEnergyCap()
    {
        EnergyBar.GetComponent<StatBar>().SetCap(energyCapGainDefault);
    }

    public void SpendMoney(int amount)
    {
        MoneyBalanceField.GetComponent<MoneyCounter>().GainOrSpendMoney(-amount);
    }

    public void SpendMoney()
    {
        MoneyBalanceField.GetComponent<MoneyCounter>().GainOrSpendMoney(-moneySpendDefault);
    }

    public void GainMoney(int amount)
    {
        MoneyBalanceField.GetComponent<MoneyCounter>().GainOrSpendMoney(amount);
    }

    public void GainMoney()
    {
        MoneyBalanceField.GetComponent<MoneyCounter>().GainOrSpendMoney(moneyGainDefault);
    }

    public float GetCurrentEnergy()
    {
        return EnergyBar.GetComponent<StatBar>().GetCurrentAmount();
    }

    public float GetCurrentHeart()
    {
        return HeartBar.GetComponent<StatBar>().GetCurrentAmount();
    }

    public int GetCurrentMoney()
    {
        return MoneyBalanceField.GetComponent<MoneyCounter>().GetCurrentBalance();
    }

    public float GetMaxEnergy()
    {
        return EnergyBar.GetComponent<StatBar>().GetStatCap();
    }

    public bool GetIsHeartMaxed()
    {
        return HeartBar.GetComponent<StatBar>().GetIsMaxedOut();
    }

    public bool GetIsEnergyMaxed()
    {
        return EnergyBar.GetComponent<StatBar>().GetIsMaxedOut();
    }
}
