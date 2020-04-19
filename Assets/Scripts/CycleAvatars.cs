using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CycleAvatars : MonoBehaviour
{
    [SerializeField] private PlayerAvatar[] playerAvatars;
    [SerializeField] private int currentlyActive = 0;

    private bool canToggle = false;
    private bool isChecking = false;

    private void Awake()
    {
        DisableLockedAvatars();
    }

    private void DisableLockedAvatars()
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
        ToggleAvatar();
    }

    private void ToggleAvatar()
    {
        if (Input.GetButtonDown("Jump") && canToggle)
        {
            isChecking = true;
            int lastChecked = currentlyActive;
            int nextToCheck;
            while (isChecking)
            {
                //if last checked is last in list, check first in list
                if (lastChecked == playerAvatars.Length - 1)
                {
                    nextToCheck = 0;
                }
                else
                {
                    nextToCheck = lastChecked + 1;
                }
                if (playerAvatars[nextToCheck].isUnlocked)
                {
                    // Disable previously active avatar
                    playerAvatars[currentlyActive].avatarObject.SetActive(false);

                    // Enable the new avatar and set it as active
                    playerAvatars[nextToCheck].avatarObject.SetActive(true);
                    currentlyActive = nextToCheck;

                    // Set isChecking to false
                    isChecking = false;

                    GetComponent<PlayerMovement>().SetSpeeds(playerAvatars[nextToCheck].moveSpeed, playerAvatars[nextToCheck].turnSpeed);
                }
            }
        }
    }

    public void UnlockAvatar(string name)
    {
        int avatarIndex = Array.FindIndex(playerAvatars, playerAvatar => playerAvatar.name == name);
        Debug.Log("avatarIndex = " + avatarIndex);
        playerAvatars[avatarIndex].isUnlocked = true;
        
        //PlayerAvatar avatar = Array.Find(playerAvatars, playerAvatar => playerAvatar.name == name);
        //avatar.isUnlocked = true;
    }
}
