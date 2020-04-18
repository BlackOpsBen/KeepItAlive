using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class SnapToGrid : MonoBehaviour
{
    private int gridSize = 4;

    void Update()
    {
        SnapPosition();
    }

    private void SnapPosition()
    {
        transform.position = new Vector3(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            0f,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
            );
    }
}
