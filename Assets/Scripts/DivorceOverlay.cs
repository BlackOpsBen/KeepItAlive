using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DivorceOverlay : MonoBehaviour
{
    [SerializeField] private Image bg;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI promptText;

    [SerializeField] private Color bgStartColor;
    [SerializeField] private Color bgEndColor;

    [SerializeField] private float fadeSpeed = 10f;

    [SerializeField] private float headerEndFontSize = 244f;

    private Vector3 startRotation;
    private Vector3 endRotation;

    private void Awake()
    {
        bg.color = bgStartColor;
        headerText.color = new Color(1f, 1f, 1f, 0f);
        headerText.fontSize = 0f;
        promptText.enabled = false;
    }

    public void ShowOverlay()
    {
        startRotation = new Vector3(0f, 0f, Random.Range(-25f, 25f));
        endRotation = new Vector3(0f, 0f, Random.Range(-25f, 25f));
        StartCoroutine(AnimateOverlay());
    }

    private IEnumerator AnimateOverlay()
    {
        while (bg.color != bgEndColor)
        {
            bg.color = Color.Lerp(bg.color, bgEndColor, Time.deltaTime * fadeSpeed);
            headerText.color = Color.Lerp(headerText.color, Color.white, Time.deltaTime * fadeSpeed);
            headerText.GetComponent<RectTransform>().rotation = Quaternion.Euler(Vector3.Lerp(startRotation, endRotation, Time.deltaTime * fadeSpeed));
            headerText.fontSize = Mathf.Lerp(headerText.fontSize, headerEndFontSize, Time.deltaTime * fadeSpeed);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        promptText.enabled = true;
        SceneLoadManager.Instance.SetCanRestart(true);
    }
}
