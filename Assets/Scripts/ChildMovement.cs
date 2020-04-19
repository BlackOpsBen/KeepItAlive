using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeedMultiplier = 10f;
    [SerializeField] private float turnSpeedMultiplier = 10f;

    [SerializeField] private Animator animator;

    private Vector2 movementGeneratedAxis;

    private Vector3 moveDirection;

    private bool canMove = true;

    void Update()
    {
        GenerateMovementAxis();
        ProcessMovement();
    }

    private void GenerateMovementAxis()
    {
        movementGeneratedAxis.x = Random.Range(-1f, 1f);
        movementGeneratedAxis.y = Random.Range(-1f, 1f);
        animator.SetFloat("Running", movementGeneratedAxis.normalized.magnitude);
    }

    private void ProcessMovement()
    {
        // Move
        Vector3 forward = Vector3.forward;
        Vector3 right = Vector3.right;
        Vector3 facingDirection = transform.forward * Mathf.Max(Mathf.Abs(movementGeneratedAxis.x), Mathf.Abs(movementGeneratedAxis.y));
        moveDirection = forward * movementGeneratedAxis.y + right * movementGeneratedAxis.x;
        if (canMove)
        {
            transform.Translate(facingDirection * moveSpeedMultiplier * Time.deltaTime, Space.World);
        }

        // Rotate to face move direction
        Quaternion rotation = Quaternion.identity;
        if (moveDirection != Vector3.zero)
        {
            rotation = Quaternion.LookRotation(moveDirection, transform.up);
        }
        if (Mathf.Abs(movementGeneratedAxis.x) > float.Epsilon || Mathf.Abs(movementGeneratedAxis.y) > float.Epsilon)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeedMultiplier * Time.deltaTime);
        }
    }
}
