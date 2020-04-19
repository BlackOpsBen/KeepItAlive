using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
    public static FloatingTextController Instance { get; private set; }

    [SerializeField] private GameObject popupTextPrefab;

    private void Awake()
    {
        EnsureOnlyOneInstance();
    }

    private void EnsureOnlyOneInstance()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void CreateFloatingText(string text, Color color, Vector3 location)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(location);

        GameObject newPopupText = Instantiate(popupTextPrefab, screenPos, Quaternion.identity, gameObject.transform);
        newPopupText.GetComponent<FloatingText>().SetText(text, color);
    }
}
