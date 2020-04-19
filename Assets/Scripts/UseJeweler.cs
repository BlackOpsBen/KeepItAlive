using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseJeweler : MonoBehaviour
{
    [SerializeField] private int moneyCost = 1000;
    [SerializeField] private float feedbackIntensity = 5f;

    public void OnUseBuilding()
    {
        if (GameManager.Instance.GetCurrentMoney() >= moneyCost)
        {
            GameManager.Instance.SpendMoney(moneyCost);
            FloatingTextController.Instance.CreateFloatingText("-" + moneyCost.ToString(), FloatingTextController.Instance.moneyColor, transform.position);

            VisualFeedback();
            AudioManager.Instance.PlaySound("UseJeweler");

            GameManager.Instance.IncreaseHeartCap();
        }
        else
        {
            AudioManager.Instance.PlaySound("NegativeFeedback");
            FloatingTextController.Instance.CreateFloatingText("Need $" + moneyCost.ToString(), FloatingTextController.Instance.negativeColor, 50f, transform.position);
        }
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
