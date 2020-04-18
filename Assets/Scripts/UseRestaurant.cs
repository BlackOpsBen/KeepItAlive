using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRestaurant : MonoBehaviour
{
    [SerializeField] private int moneyCost = 19;
    [SerializeField] private float feedbackIntensity = 10f;

    public void OnUseBuilding()
    {
        GameManager.Instance.SpendMoney(moneyCost);

        VisualFeedback();
        AudioManager.Instance.PlaySound("UseRestaurant");

        GameManager.Instance.GainEnergy();
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
