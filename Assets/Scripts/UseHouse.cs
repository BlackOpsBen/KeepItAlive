using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHouse : MonoBehaviour
{
    [SerializeField] private float energyCost = 1f;
    [SerializeField] private float heartGainAmount = 2f;
    [SerializeField] private float feedbackIntensity = 20f;
    [SerializeField] private GameObject childBoy;
    [SerializeField] private GameObject childGirl;

    private float birthThreshold = 0.1f;

    public void OnUseBuilding()
    {
        if (GameManager.Instance.GetCurrentEnergy() >= energyCost)
        {
            GameManager.Instance.SpendEnergy(energyCost);
            FloatingTextController.Instance.CreateFloatingText("-" + energyCost.ToString(), FloatingTextController.Instance.energyColor, GameManager.Instance.energyIcon.position);

            VisualFeedback();
            AudioManager.Instance.PlaySound("UseHouse");

            GameManager.Instance.GainHeart(heartGainAmount);
            FloatingTextController.Instance.CreateFloatingText("+" + heartGainAmount.ToString(), FloatingTextController.Instance.heartColor, GameManager.Instance.heartIcon.position);

            if (Random.Range(0f, 1f) < birthThreshold)
            {
                GameObject childToBirth;
                if (Random.Range(0f, 1f) < 0.5f)
                {
                    childToBirth = childBoy;
                }
                else
                {
                    childToBirth = childGirl;
                }
                Vector3 spawnPoint = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y, transform.position.z + Random.Range(-1f, 1f)) * 3f;
                Instantiate(childToBirth, transform.position, Quaternion.identity);
                AudioManager.Instance.PlaySound("Baby");
                birthThreshold = 0.1f;
            }
            else
            {
                birthThreshold += 0.025f;
            }
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
