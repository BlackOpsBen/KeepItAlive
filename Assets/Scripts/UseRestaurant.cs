using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRestaurant : MonoBehaviour
{
    [SerializeField] private int moneyCost = 19;
    [SerializeField] private float energyGainAmount = 2f;
    [SerializeField] private float feedbackIntensity = 10f;

    public void OnUseBuilding()
    {
        if (GameManager.Instance.GetCurrentEnergy() < GameManager.Instance.GetMaxEnergy())
        {
            if (GameManager.Instance.GetCurrentMoney() >= moneyCost)
            {
                GameManager.Instance.SpendMoney(moneyCost);
                FloatingTextController.Instance.CreateFloatingText("-$" + moneyCost.ToString(), FloatingTextController.Instance.moneyColor, GameManager.Instance.moneyIcon.position);

                VisualFeedback();
                AudioManager.Instance.PlaySound("UseRestaurant");

                GameManager.Instance.GainEnergy(energyGainAmount);
                FloatingTextController.Instance.CreateFloatingText("+" + energyGainAmount.ToString(), FloatingTextController.Instance.energyColor, transform.position);
            }
            else
            {
                AudioManager.Instance.PlaySound("NegativeFeedback");
                FloatingTextController.Instance.CreateFloatingText("Need $" + moneyCost.ToString(), FloatingTextController.Instance.negativeColor, 50f, transform.position);
            }
        }
        else
        {
            AudioManager.Instance.PlaySound("NegativeFeedback");
            FloatingTextController.Instance.CreateFloatingText("Energy full!", FloatingTextController.Instance.energyColor, FloatingTextController.Instance.wordSize, transform.position);
        }

        
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
