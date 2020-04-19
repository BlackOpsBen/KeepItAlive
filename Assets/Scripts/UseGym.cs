using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGym : MonoBehaviour
{
    [SerializeField] private float energyCost = 5f;
    [SerializeField] private float energyCapGain = 1f;
    [SerializeField] private float feedbackIntensity = 20f;

    public void OnUseBuilding()
    {
        if (GameManager.Instance.GetCurrentEnergy() >= energyCost)
        {
            GameManager.Instance.SpendEnergy(energyCost);
            FloatingTextController.Instance.CreateFloatingText("-" + energyCost.ToString(), FloatingTextController.Instance.energyColor, transform.position);

            VisualFeedback();
            AudioManager.Instance.PlaySound("UseGym");

            GameManager.Instance.IncreaseEnergyCap(energyCapGain);
        }
        else
        {
            AudioManager.Instance.PlaySound("NegativeFeedback");
            FloatingTextController.Instance.CreateFloatingText("Need more energy", FloatingTextController.Instance.negativeColor, 50f, transform.position);
        }
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
