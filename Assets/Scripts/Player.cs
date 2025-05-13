using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float  mouseSensitivity = 3f;
    [SerializeField] float movmentSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float mass = 1f;
    [SerializeField] Transform cammeraTransform;

    CharacterController controller;
    Vector3 velocity;
    Vector2 look;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    // void Start()
    // {
    //     Cursor.lockState = CursorLockMode.Locked;
    // }

    // Update is called once per frame
    void Update()
    {
        UpdateGravity();
        UpdateMovement();
        UpdateLook();
    }
    void UpdateGravity()
    {
      var gravity = Physics.gravity * mass * Time.deltaTime;
      velocity.y = controller.isGrounded ? -1f : velocity.y + gravity.y;
    }


    void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var input = new Vector3();
        input += transform.forward * y;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y += jumpSpeed;
        }

      //  transform.Translate(input * movmentSpeed * Time.deltaTime, Space.World);

      controller.Move((input * movmentSpeed + velocity) * Time.deltaTime);
    }

    void UpdateLook()
    {
        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        look.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        look.y = Mathf.Clamp(look.y, -89f, 89f);
        cammeraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
{
    Rigidbody body = hit.collider.attachedRigidbody;

    if (body != null && !body.isKinematic)
    {
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.linearVelocity = pushDir * 5f; // tweak force multiplier here
    }
}

}
