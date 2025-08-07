using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX = 100f;
    public float sensY = 100f;

    public Transform orientation;
    public Transform player;
    public Global myGlobal;

    private float xRotation;
    private float yRotation;

    private PlayerControls playerControls;
    private Vector2 lookInput;

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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void LateUpdate()
    {

        if (myGlobal.g_CanLook)
        {

            lookInput = playerControls.Player.Look.ReadValue<Vector2>();

            float mouseX = lookInput.x * Time.deltaTime * sensX;
            float mouseY = lookInput.y * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        }

        //player.rotation = Quaternion.Euler(0, transform.rotation.y, 0); 
    }
}
