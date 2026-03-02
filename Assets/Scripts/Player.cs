using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask groundMask;

    [Header("Camera")]
    public Transform playerCamera;
    public float mouseSensitivity = 100f;
    public float verticalLookLimit = 80f;

    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;

    private bool isGrounded;

    bool bliper;
    void ToggleBlip()
    {
        bliper = !bliper;
    }

    private void Start()
    {
        InvokeRepeating(nameof(ToggleBlip), 1f, 1f);

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        // Create groundCheck if missing
        if (groundCheck == null)
        {
            GameObject groundCheckObj = new GameObject("GroundCheck");
            groundCheckObj.transform.SetParent(transform);
            groundCheckObj.transform.localPosition = new Vector3(0, groundCheckRadius - 1.05f, 0);
            groundCheck = groundCheckObj.transform;
        }
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation - mouseY, -verticalLookLimit, verticalLookLimit);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void Movement()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isGrounded = Physics.SphereCast(groundCheck.position, groundCheckRadius, Vector3.down, 
            out RaycastHit hitInfo, 0.15f, groundMask);
        if(hitInfo.collider != null)
        {
            Debug.Log( hitInfo.collider.tag );
            switch(hitInfo.collider.tag )
            {
                case "Fast":
                    speed = 15;
                    break;

                case "Slow":
                    speed = 5; break;

                default:
                    speed = 7; break;
            }
        }
        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        controller.Move((move * speed + velocity) * Time.deltaTime);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    private void Update()
    {
        // Mouse look
        MouseLook();

        // Movement
        Movement();

        // Jump
        Jump();

        // Gravity
        velocity.y += gravity * Time.deltaTime;
       // controller.Move(velocity * Time.deltaTime);

        // Unlock cursor
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }

    private void OnDrawGizmos()
    {
        if(groundCheck)
        {
            if(bliper)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(groundCheck.position + Vector3.down * 0.15f, groundCheckRadius);
            }
        }

    }
}