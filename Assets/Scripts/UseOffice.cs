using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseOffice : MonoBehaviour
{
    [SerializeField] private float energyCost = 1f;
    [SerializeField] private float feedbackIntensity = 10f;

    public void OnUseBuilding()
    {
        if (GameManager.Instance.GetCurrentEnergy() >= energyCost)
        {
            GameManager.Instance.SpendEnergy(energyCost);

            VisualFeedback();
            AudioManager.Instance.PlaySound("UseOffice");

            GameManager.Instance.GainMoney();
        }
        else
        {
            AudioManager.Instance.PlaySound("NegativeFeedback");
        }
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
