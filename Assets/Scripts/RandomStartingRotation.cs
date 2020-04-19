using UnityEngine;

public class RandomStartingRotation : MonoBehaviour
{
    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    }
}
