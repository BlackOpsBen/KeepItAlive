using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CycleAvatars : MonoBehaviour
{
    public static CycleAvatars Instance { get; private set; }

    [SerializeField] private PlayerAvatar[] playerAvatars;
    [SerializeField] private int currentlyActive = 0;

    [SerializeField] private GameObject toggleFX;

    private bool isInBuilding = false;
    private bool canToggle = false;
    private bool isChecking = false;
    private int nextOption = 0;

    private void Awake()
    {
        EnsureOnlyOneInstance();
        DisableInactiveAvatars();
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

    private void DisableInactiveAvatars()
    {
        for (int i = 0; i < playerAvatars.Length; i++)
        {
            if (i != currentlyActive)
            {
                playerAvatars[i].avatarObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isInBuilding && canToggle)
            {
                ToggleAvatar();
            }
        }
    }

    public void ToggleAvatar()
    {
        nextOption = currentlyActive;
        isChecking = true;
        while (isChecking)
        {
            nextOption++;
            if (nextOption > (playerAvatars.Length - 1))
            {
                nextOption = 0;
            }

            if (playerAvatars[nextOption].isUnlocked)
            {
                EnableAvatar(nextOption);
                DisableInactiveAvatars();
                isChecking = false;
                toggleFX.GetComponent<ParticleSystem>().Play();
                AudioManager.Instance.PlaySound("ToggleAvatar");
            }
        }
        

    }

    private void EnableAvatar(int selected)
    {
        currentlyActive = selected;
        playerAvatars[selected].avatarObject.SetActive(true);
        GetComponent<PlayerMovement>().SetSpeeds(playerAvatars[currentlyActive].moveSpeed, playerAvatars[currentlyActive].turnSpeed);
    }

    //public void ToggleAvatar()
    //{
    //    Debug.Log("ToggleAvatar called and started");
    //    isChecking = true;
    //    int lastChecked = currentlyActive;
    //    int nextToCheck;
    //    while (isChecking)
    //    {
    //        //if last checked is last in list, check first in list
    //        if (lastChecked == playerAvatars.Length - 1)
    //        {
    //            nextToCheck = 0;
    //        }
    //        else
    //        {
    //            nextToCheck = lastChecked + 1;
    //        }
    //        Debug.Log("NextToCheck = " + nextToCheck);
    //        if (playerAvatars[nextToCheck].isUnlocked)
    //        {
    //            // Disable previously active avatar
    //            playerAvatars[currentlyActive].avatarObject.SetActive(false);

    //            // Enable the new avatar and set it as active
    //            playerAvatars[nextToCheck].avatarObject.SetActive(true);
    //            currentlyActive = nextToCheck;

    //            // Set isChecking to false
    //            isChecking = false;

    //            GetComponent<PlayerMovement>().SetSpeeds(playerAvatars[nextToCheck].moveSpeed, playerAvatars[nextToCheck].turnSpeed);
    //        }
    //    }
    //    toggleFX.GetComponent<ParticleSystem>().Play();
    //    AudioManager.Instance.PlaySound("ToggleAvatar");
    //}

    public void UnlockAvatar(string name)
    {
        int avatarIndex = Array.FindIndex(playerAvatars, playerAvatar => playerAvatar.name == name);
        playerAvatars[avatarIndex].isUnlocked = true;

        EnableAvatar(avatarIndex);
        DisableInactiveAvatars();
        
        //playerAvatars[currentlyActive].avatarObject.SetActive(false);
        //playerAvatars[avatarIndex].avatarObject.SetActive(true);
        //currentlyActive = avatarIndex;
        //GetComponent<PlayerMovement>().SetSpeeds(playerAvatars[avatarIndex].moveSpeed, playerAvatars[avatarIndex].turnSpeed);
        
        if (!canToggle)
        {
            StartCoroutine(SetCanToggle());
        }
        //PlayerAvatar avatar = Array.Find(playerAvatars, playerAvatar => playerAvatar.name == name);
        //avatar.isUnlocked = true;
    }

    private IEnumerator SetCanToggle()
    {
        yield return null;
        canToggle = true;
    }

    public void SetIsInBuilding(bool value)
    {
        isInBuilding = value;
    }
}
