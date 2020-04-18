using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHouse : MonoBehaviour
{
    [SerializeField] private float energyCost = 1f;
    [SerializeField] private float feedbackIntensity = 20f;
    public void OnUseBuilding()
    {
        if (GameManager.Instance.GetCurrentEnergy() >= energyCost)
        {
            GameManager.Instance.SpendEnergy(energyCost);

            VisualFeedback();

            GameManager.Instance.GainHeart();
        }
        else
        {
            // TODO play negative feedback SFX/VFX
        }
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
