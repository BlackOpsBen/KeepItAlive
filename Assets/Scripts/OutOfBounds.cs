using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] float fallDistanceThreshold = -10f;
    [SerializeField] float fadeSpeed = 5f;
    [SerializeField] Image hellImage;
    [SerializeField] TextMeshProUGUI hellText;

    [SerializeField] Color startColor;
    [SerializeField] Color endColor;

    bool isWarned = false;

    void Update()
    {
        if (transform.position.y < fallDistanceThreshold)
        {
            if (!isWarned)
            {
                isWarned = true;
                StartCoroutine(WarnAndResetPlayer());
            }
        }
    }

    private IEnumerator WarnAndResetPlayer()
    {
        while (hellImage.color.a < .9f)
        {
            hellImage.color = Color.Lerp(hellImage.color, endColor, Time.deltaTime * fadeSpeed);
            hellText.color = hellImage.color;
            yield return null;
        }
        hellImage.color = startColor;
        hellText.color = startColor;
        transform.position = Vector3.up;
        FindObjectOfType<FollowPlayer>().transform.position = Vector3.up;
        isWarned = false;
    }
}
