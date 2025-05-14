using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float mass = 1f;
    [SerializeField] Transform cammeraTransform;

    CharacterController controller;
    Vector3 velocity;
    Vector2 look;

    float gravity = -9.81f;
    bool isJumping;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateLook();
        UpdateMovement();
    }

    void UpdateMovement()
    {
        // Movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Gravity and jumping
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f; // small downward force to keep grounded

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
            }
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Final move
        Vector3 finalMove = (move * movementSpeed + velocity) * Time.deltaTime;
        controller.Move(finalMove);
    }

    void UpdateLook()
    {
        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        look.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        look.y = Mathf.Clamp(look.y, -89f, 89f);
        cammeraTransform.localRotation = Quaternion.Euler(look.y, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, look.x, 0f);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body != null && !body.isKinematic)
        {
            // Push rigidbody horizontally
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            body.linearVelocity = pushDir * 5f; // tweak this multiplier
        }
    }
}