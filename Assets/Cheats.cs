using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            GameManager.Instance.GainMoney(1000);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GameManager.Instance.GainHeart(1000);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.GainEnergy(1000);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.IncreaseEnergyCap(1000);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            GameManager.Instance.IncreaseHeartCap(1000);
        }
    }
}
