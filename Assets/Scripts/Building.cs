using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private float snapSpeed = 10f;

    private bool isOccupied = false;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
        if (isOccupied)
        {
            playerMovement.transform.position = Vector3.Lerp(playerMovement.transform.position, transform.position, Time.deltaTime * snapSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            playerMovement.enabled = false;
            isOccupied = true;
            Debug.Log("Occupied building!");
        }
    }
}
