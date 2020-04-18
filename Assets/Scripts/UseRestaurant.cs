using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRestaurant : MonoBehaviour
{
    public void OnUseBuilding()
    {
        // TODO spend money
        GameManager.Instance.GainEnergy();
    }
}
