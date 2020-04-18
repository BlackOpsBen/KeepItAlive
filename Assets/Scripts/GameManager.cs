using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject HeartBar;
    [SerializeField] private GameObject EnergyBar;

    [SerializeField] private float heartDecay = 1f;

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

    public void GainOrLoseEnergy(float amount)
    {
        EnergyBar.GetComponent<StatBar>().GainOrLoseAmount(amount);
    }
}
