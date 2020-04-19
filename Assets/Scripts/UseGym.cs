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
        if (!GameManager.Instance.GetIsEnergyMaxed())
        {
            if (GameManager.Instance.GetCurrentEnergy() >= energyCost)
            {
                GameManager.Instance.SpendEnergy(energyCost);
                FloatingTextController.Instance.CreateFloatingText("-" + energyCost.ToString(), FloatingTextController.Instance.energyColor, GameManager.Instance.energyIcon.position);

                VisualFeedback();
                AudioManager.Instance.PlaySound("UseGym");

                GameManager.Instance.IncreaseEnergyCap(energyCapGain);
                FloatingTextController.Instance.CreateFloatingText("+" + energyCapGain.ToString(), Color.white, GameManager.Instance.energyIcon.position);
            }
            else
            {
                AudioManager.Instance.PlaySound("NegativeFeedback");
                FloatingTextController.Instance.CreateFloatingText("Need more energy", FloatingTextController.Instance.negativeColor, FloatingTextController.Instance.wordSize, transform.position);
            }
        }
        else
        {
            AudioManager.Instance.PlaySound("NegativeFeedback");
            FloatingTextController.Instance.CreateFloatingText("You're swole enough!", FloatingTextController.Instance.energyColor, FloatingTextController.Instance.wordSize, transform.position);
        }
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
