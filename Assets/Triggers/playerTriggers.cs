using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class playerTriggers : MonoBehaviour
{
    delegate void OnPlayerInteract();
    OnPlayerInteract onPlayerInteract;
    private PlayerControls playerControls;
    private float interactInput;
    public Pickup playerPickup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        playerPickup = GetComponent<Pickup>();

    }

    // Update is called once per frame
    void Update()
    {
        //interactInput = playerControls.Player.Interact.ReadValue<float>();
        //if (interactInput != 0)
        //{
            
        //}
    }
    private void Awake()
    {
        playerControls = new PlayerControls();
        
    }

    private void OnEnable()
    {
        playerControls.Player.Interact.performed += playerInteract;
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Interact.performed -= playerInteract;
        playerControls.Disable();
    }

    private void playerInteract(InputAction.CallbackContext obj)
    {
        if (onPlayerInteract != null)
        {
            onPlayerInteract();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("mailbox"))
        {
           
            Debug.Log("You can now interact with the mailbox!");
            onPlayerInteract += other.GetComponentInParent<MailboxInteract>().Interact;
            //playerPickup.pickup(other.transform.parent.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("mail"))
        {

            Debug.Log("You can no longer interact with the mailbox!");
            onPlayerInteract -= other.GetComponentInParent<MailboxInteract>().Interact;
            //playerPickup.pickup();
        }
    }

}
