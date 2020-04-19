using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRestaurant : MonoBehaviour
{
    [SerializeField] private int moneyCost = 19;
    [SerializeField] private float feedbackIntensity = 10f;

    public void OnUseBuilding()
    {
        if (GameManager.Instance.GetCurrentEnergy() < GameManager.Instance.GetMaxEnergy())
        {
            if (GameManager.Instance.GetCurrentMoney() >= moneyCost)
            {
                GameManager.Instance.SpendMoney(moneyCost);
                FloatingTextController.Instance.CreateFloatingText("-$" + moneyCost.ToString(), FloatingTextController.Instance.moneyColor, transform.position);

                VisualFeedback();
                AudioManager.Instance.PlaySound("UseRestaurant");

                GameManager.Instance.GainEnergy();
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
            FloatingTextController.Instance.CreateFloatingText("Energy full!", FloatingTextController.Instance.energyColor, 50f, transform.position);
        }

        
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
