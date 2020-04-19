using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAvatar
{
    public string name;
    public GameObject avatarObject;
    public bool isUnlocked = false;
    public float moveSpeed;
    public float turnSpeed;
}
