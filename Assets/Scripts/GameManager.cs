using System;
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

    [SerializeField] private float heartGainDefault = 1f;
    [SerializeField] private float energySpendDefault = 2f;
    [SerializeField] private float energyGainDefault = 1f;
    [SerializeField] private int moneyGainDefault = 100;
    [SerializeField] private int moneySpendDefault = 20;

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

    private void Update()
    {
        HeartDecays();
        if (HeartBar.GetComponent<StatBar>().GetCurrentAmount() <= float.Epsilon)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // TODO show game over screens and get restart
        Debug.Log("Game over!");
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
}
