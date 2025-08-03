using UnityEngine;

public class FPS_Mouse_Rotation : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientaiton;

    float xRotation;
    float yRotation;

    Vector3 MoveDirection;
    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravSpeed = 10f;
    [SerializeField] float dragAmount = .1f;
    public bool canJump = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //getMouseInput

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        //orientaiton.rotation = Quaternion.Euler(0f, yRotation, 0f);

        MoveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            Move(transform.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(transform.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-transform.right);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(-transform.forward);
        }

        playerRigidBody.AddForce(MoveDirection, ForceMode.VelocityChange);
        playerRigidBody.linearVelocity = Vector3.ClampMagnitude(playerRigidBody.linearVelocity, maxSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        AddResistance();
        AddGravity();
    }

    void Move(Vector3 dir)
    {
        MoveDirection += dir * Time.deltaTime * moveSpeed;
        MoveDirection.y = 0;
    }

    void Jump()
    {
        if (!canJump) return;
        playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canJump = false;
    }

    void AddResistance()
    {
        Vector3 velDir = playerRigidBody.linearVelocity;
        velDir *= -1f; // reverse direction
        velDir.y = 0;
        playerRigidBody.linearVelocity += velDir* dragAmount;
    }

    void AddGravity()
    {
        playerRigidBody.AddForce(Physics.gravity * playerRigidBody.mass * gravSpeed);
    }
}
