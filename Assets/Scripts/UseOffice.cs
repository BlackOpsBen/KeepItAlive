using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseOffice : MonoBehaviour
{
    [SerializeField] private float energyCost = 1f;
    [SerializeField] private float feedbackIntensity = 10f;
    private DetermineIncome determineIncome;

    private void Awake()
    {
        determineIncome = GetComponent<DetermineIncome>();
    }

    public void OnUseBuilding()
    {
        if (GameManager.Instance.GetCurrentEnergy() >= energyCost)
        {
            GameManager.Instance.SpendEnergy(energyCost);
            FloatingTextController.Instance.CreateFloatingText("-" + energyCost.ToString(), FloatingTextController.Instance.energyColor, GameManager.Instance.energyIcon.position);

            VisualFeedback();
            AudioManager.Instance.PlaySound("UseOffice");

            GameManager.Instance.GainMoney(determineIncome.GetCurrentIncome());
            FloatingTextController.Instance.CreateFloatingText("+$" + determineIncome.GetCurrentIncome().ToString(), FloatingTextController.Instance.moneyColor, transform.position);

            determineIncome.DecreaseSteps();
        }
        else
        {
            AudioManager.Instance.PlaySound("NegativeFeedback");
            FloatingTextController.Instance.CreateFloatingText("Need more energy", FloatingTextController.Instance.negativeColor, FloatingTextController.Instance.wordSize, transform.position);
        }
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
