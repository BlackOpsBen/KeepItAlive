using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseDojo : MonoBehaviour
{
    [SerializeField] private float energyCost = 5f;
    [SerializeField] private int moneyCost = 1000;
    [SerializeField] private int dojoGain = 1;
    [SerializeField] private int dojoRequirement = 10;
    [SerializeField] private float feedbackIntensity = 20f;

    private bool hasNinja = false;
    private int currentDojoLevel = 0;

    public void OnUseBuilding()
    {
        if (!hasNinja)
        {
            if (GameManager.Instance.GetCurrentEnergy() >= energyCost)
            {
                if (GameManager.Instance.GetCurrentMoney() >= moneyCost)
                {
                    GameManager.Instance.SpendEnergy(energyCost);
                    GameManager.Instance.SpendMoney(moneyCost);
                    FloatingTextController.Instance.CreateFloatingText("-" + energyCost.ToString(), FloatingTextController.Instance.energyColor, GameManager.Instance.energyIcon.position);
                    FloatingTextController.Instance.CreateFloatingText("-" + moneyCost.ToString(), FloatingTextController.Instance.moneyColor, GameManager.Instance.moneyIcon.position);

                    VisualFeedback();
                    AudioManager.Instance.PlaySound("UseDojo");

                    currentDojoLevel += dojoGain;
                    FloatingTextController.Instance.CreateFloatingText("+?", Color.white, transform.position);

                }
                else
                {
                    AudioManager.Instance.PlaySound("NegativeFeedback");
                    FloatingTextController.Instance.CreateFloatingText("Need $" + moneyCost.ToString(), FloatingTextController.Instance.negativeColor, FloatingTextController.Instance.wordSize, transform.position);
                }
            }
            else
            {
                AudioManager.Instance.PlaySound("NegativeFeedback");
                FloatingTextController.Instance.CreateFloatingText("Need more energy", FloatingTextController.Instance.negativeColor, FloatingTextController.Instance.wordSize, transform.position);
            }
            if (currentDojoLevel >= dojoRequirement)
            {
                FloatingTextController.Instance.CreateFloatingText("You are a Ninja Master!", Color.white, 100f, transform.position);
                CycleAvatars.Instance.UnlockAvatar("Ninja");
                hasNinja = true;

                AudioManager.Instance.PlaySound("DojoComplete");

            }
        }
        else
        {
            AudioManager.Instance.PlaySound("NegativeFeedback");
            FloatingTextController.Instance.CreateFloatingText("You already unlocked a freakin' ninja! What else do you want?", FloatingTextController.Instance.negativeColor, FloatingTextController.Instance.wordSize, transform.position);
        }
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
