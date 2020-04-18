using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseOffice : MonoBehaviour
{
    public void OnUseBuilding()
    {
        // TODO gain money
        GameManager.Instance.SpendEnergy();
    }
}
