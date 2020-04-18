using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeedMultiplier = 10f;
    [SerializeField] private float turnSpeedMultiplier = 5f;
    
    private Transform cameraParent;
    
    private Vector2 movementInputAxis;

    private void Awake()
    {
        cameraParent = FindObjectOfType<FollowPlayer>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        ProcessMovement();
    }

    private void GetMovementInput()
    {
        movementInputAxis.x = Input.GetAxis("Horizontal");
        movementInputAxis.y = Input.GetAxis("Vertical");
        Debug.Log(movementInputAxis);
    }

    private void ProcessMovement()
    {
        // Move
        Vector3 forward = cameraParent.forward;
        Vector3 right = cameraParent.right;
        Vector3 facingDirection = transform.forward * Mathf.Max(Mathf.Abs(movementInputAxis.x), Mathf.Abs(movementInputAxis.y));
        Vector3 moveDirection = forward * movementInputAxis.y + right * movementInputAxis.x;
        transform.Translate(facingDirection * moveSpeedMultiplier * Time.deltaTime, Space.World);

        // Rotate to face move direction
        Quaternion rotation = Quaternion.identity;
        if (moveDirection != Vector3.zero)
        {
            rotation = Quaternion.LookRotation(moveDirection, transform.up);
        }
        if (Mathf.Abs(movementInputAxis.x) > float.Epsilon || Mathf.Abs(movementInputAxis.y) > float.Epsilon)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeedMultiplier * Time.deltaTime);
        }
    }
}
