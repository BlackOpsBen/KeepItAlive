using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject HeartBar;
    [SerializeField] private GameObject EnergyBar;

    [SerializeField] private float heartDecay = 0.5f;

    [SerializeField] private float heartGainDefault = 1f;
    [SerializeField] private float energySpendDefault = 2f;
    [SerializeField] private float energyGainDefault = 1f;

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
        HeartBar.GetComponent<StatBar>().GainOrLoseAmount(-heartDecay * Time.deltaTime);
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

    public float GetCurrentEnergy()
    {
        return EnergyBar.GetComponent<StatBar>().GetCurrentAmount();
    }

    public float GetCurrentHeart()
    {
        return HeartBar.GetComponent<StatBar>().GetCurrentAmount();
    }

    //public int GetCurrentMoney()
    //{
    //    // TODO return current money
    //}
}
