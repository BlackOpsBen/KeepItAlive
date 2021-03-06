﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
    public static FloatingTextController Instance { get; private set; }

    [SerializeField] public Color negativeColor;
    [SerializeField] public Color moneyColor;
    [SerializeField] public Color energyColor;
    [SerializeField] public Color heartColor;
    [SerializeField] private float scatter = 100f;
    [SerializeField] public float wordSize = 60f;

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
        screenPos = new Vector2(screenPos.x + Random.Range(-scatter, scatter), screenPos.y + Random.Range(-scatter, scatter));

        GameObject newPopupText = Instantiate(popupTextPrefab, screenPos, Quaternion.identity, gameObject.transform);
        newPopupText.GetComponent<FloatingText>().SetText(text, color);
    }

    public void CreateFloatingText(string text, Color color, float size, Vector3 location)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(location);
        screenPos = new Vector2(screenPos.x + Random.Range(-scatter, scatter), screenPos.y + Random.Range(-scatter, scatter));

        GameObject newPopupText = Instantiate(popupTextPrefab, screenPos, Quaternion.identity, gameObject.transform);
        newPopupText.GetComponent<FloatingText>().SetText(text, color, size);
    }
}
