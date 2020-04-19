using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI popupNumberText;

    public void SetText(string text, Color color)
    {
        popupNumberText.text = text;
        popupNumberText.color = color;
    }
}
