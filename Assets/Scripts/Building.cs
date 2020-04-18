using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private float snapSpeed = 10f;

    private bool isOccupied = false;

    private PlayerMovement playerMovement;

    private float exitDelay = 1f;
    private float exitCount = 0f;
    private float exitThreshold = 0.2f;

    private Vector3 exitDirection;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
        if (isOccupied)
        {
            playerMovement.transform.position = Vector3.Lerp(playerMovement.transform.position, transform.position, Time.deltaTime * snapSpeed);

            exitDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;

            if (exitDirection.magnitude > exitThreshold)
            {
                exitCount += Time.deltaTime * 2;
            }
            else
            {
                exitCount = 0f;
            }
            if (exitCount >= exitDelay)
            {
                ExitBuilding();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            playerMovement.SetCanMove(false);
            exitCount = 0f;
            isOccupied = true;
            Debug.Log("Occupied building!");
        }
    }

    private void ExitBuilding()
    {
        isOccupied = false;
        playerMovement.transform.position = transform.position + playerMovement.GetMoveDirection();
        playerMovement.SetCanMove(true);
    }
}