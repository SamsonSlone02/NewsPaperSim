using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerControls playerControls;
    public Rigidbody rb;
    public float speed;
    private Vector2 inputMovement;
    public Transform orientation;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        //Debug.Log(this.transform.position);
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        inputMovement = playerControls.Player.Move.ReadValue<Vector2>();

        Vector3 moveDirection = orientation.forward * inputMovement.y + orientation.right * inputMovement.x;
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        float jump = playerControls.Player.Jump.ReadValue<float>();
        if (jump == 1)
        {
            this.transform.position = new Vector3(1, 2, 3); // just for testing
        }

        capSpeed();
    }

    void capSpeed()
    {
        Vector3 horizontalVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (horizontalVel.magnitude > speed)
        {
            Vector3 limitedVel = horizontalVel.normalized * speed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
}
