using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHouse : MonoBehaviour
{
    [SerializeField] private float energyCost = 1f;
    [SerializeField] private float feedbackIntensity = 20f;
    [SerializeField] private GameObject childBoy;
    [SerializeField] private GameObject childGirl;
    public void OnUseBuilding()
    {
        if (GameManager.Instance.GetCurrentEnergy() >= energyCost)
        {
            GameManager.Instance.SpendEnergy(energyCost);
            FloatingTextController.Instance.CreateFloatingText("-" + energyCost.ToString(), FloatingTextController.Instance.energyColor, transform.position);

            VisualFeedback();
            AudioManager.Instance.PlaySound("UseHouse");

            GameManager.Instance.GainHeart();

            if (Random.Range(0f, 1f) < 0.1f)
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
            }
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
