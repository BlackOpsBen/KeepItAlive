using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCarDealerJunky : MonoBehaviour
{
    [SerializeField] private int moneyCost = 5000;
    [SerializeField] private float feedbackIntensity = 10f;
    [SerializeField] private Transform carParkSpot;

    private bool hasCar = false;

    public void OnUseBuilding()
    {
        if (!hasCar)
        {
            if (GameManager.Instance.GetCurrentMoney() >= moneyCost)
            {
                //TODO gain car
                hasCar = true;
                GameManager.Instance.SpendMoney(moneyCost);
                FloatingTextController.Instance.CreateFloatingText("-" + moneyCost.ToString(), FloatingTextController.Instance.moneyColor, GameManager.Instance.moneyIcon.position);

                VisualFeedback();
                AudioManager.Instance.PlaySound("UseDealer");

                CycleAvatars.Instance.UnlockAvatar("CarJunky");

                // Move player to parked car spot
                GetComponent<Building>().ForceExitBuilding();
                FindObjectOfType<PlayerMovement>().transform.position = carParkSpot.position;
            }
            else
            {
                AudioManager.Instance.PlaySound("NegativeFeedback");
                FloatingTextController.Instance.CreateFloatingText("Need $" + moneyCost.ToString(), FloatingTextController.Instance.negativeColor, FloatingTextController.Instance.wordSize, transform.position);
            }
        }
        else
        {
            // TODO change car color
            AudioManager.Instance.PlaySound("NegativeFeedback");
            FloatingTextController.Instance.CreateFloatingText("Already rollin!", FloatingTextController.Instance.negativeColor, FloatingTextController.Instance.wordSize, transform.position);
        }
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
