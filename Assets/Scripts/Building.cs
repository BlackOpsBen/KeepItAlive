using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //Delegated to function of building
    //[SerializeField] private float feedbackIntensity = 10f;
    [SerializeField] private GameObject token;
    [SerializeField] private Transform tokenSpawnPoint;

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
            HoldPlayer();
            GetUseBuilding();
        }
    }

    private void GetUseBuilding()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SendMessage("OnUseBuilding");
            //Delegating to Function of Building
            //Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
            //SpawnToken();
        }
    }

    public void SpawnToken()
    {
        Instantiate(token, tokenSpawnPoint.position, Quaternion.identity, tokenSpawnPoint);
    }

    private void HoldPlayer()
    {
        playerMovement.transform.position = Vector3.Lerp(playerMovement.transform.position, transform.position, Time.deltaTime * snapSpeed);
        playerMovement.transform.rotation = Quaternion.Slerp(playerMovement.transform.rotation, Quaternion.identity, Time.deltaTime * snapSpeed);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            EnterBuilding();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (!isOccupied)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    EnterBuilding();
                }
            }
        }
    }

    private void EnterBuilding()
    {
        playerMovement.SetCanMove(false);
        exitCount = 0f;
        isOccupied = true;
    }

    private void ExitBuilding()
    {
        isOccupied = false;
        playerMovement.transform.position = transform.position + playerMovement.GetMoveDirection() * 2f;
        playerMovement.SetCanMove(true);
    }

    public bool GetIsOccupied()
    {
        return isOccupied;
    }

    public void ForceExitBuilding()
    {
        isOccupied = false;
        playerMovement.SetCanMove(true);
    }
}