//using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;


public class crosshair : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 cameraDir;
    private LayerMask layerMask;
    private PlayerControls playerControls;
    delegate void OnPlayerInteract();
    OnPlayerInteract onPlayerInteract;
    public Global myGlobal;

    public float pickupDistance;
    public Vector3 cameraPos;

    private void Awake()
    {
        //playerControls = new PlayerControls();
        myGlobal = GameObject.Find("Game").GetComponent<Global>();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
       
    }

    void FixedUpdate()
    {
        
    }

    public void interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
          
            if (GetComponent<PlayerInfo>().isHolding())
            {
                release();
                return;
            }
            layerMask = LayerMask.GetMask("Pickupable", "Interactable");
            cameraDir = cameraTransform.forward.normalized;
            cameraPos = cameraTransform.position;
            Debug.DrawRay(cameraPos, cameraDir * pickupDistance, Color.yellow);

            RaycastHit hit;
            if (Physics.Raycast(cameraPos, cameraDir, out hit, pickupDistance, layerMask))
            {
                Debug.DrawRay(transform.position, cameraDir * hit.distance, Color.yellow);
                //Debug.Log("Did Hit");
                if (hit.collider.gameObject.CompareTag("mail"))
                {
                    hit.collider.gameObject.GetComponentInParent<Pickup>().Interact();

                    Debug.Log("added");
                    // Get the parent GameObject if it exists
                    Transform parent = hit.collider.transform.parent;
                }
                if (hit.collider.gameObject.CompareTag("npc"))
                { 
                    hit.collider.gameObject.GetComponentInParent<NPCInteract>().Interact();
                }
            }
            else
            {

            }
        }
        if (context.canceled)
        {
            Debug.Log("key released");
        }
        


    }

    public void interact2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {


            if (GetComponent<PlayerInfo>().isHolding())
            {
                release();
                return;
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            myGlobal.g_CanLook = false;
            gameObject.GetComponent<PlayerBackpack>().showUI();
           
            
            layerMask = LayerMask.GetMask("Pickupable", "Interactable");
            cameraDir = cameraTransform.forward.normalized;
            cameraPos = cameraTransform.position;
            Debug.DrawRay(cameraPos, cameraDir * pickupDistance, Color.yellow);

            RaycastHit hit;
            if (Physics.Raycast(cameraPos, cameraDir, out hit, pickupDistance, layerMask))
            {
                Debug.DrawRay(transform.position, cameraDir * hit.distance, Color.yellow);
                //Debug.Log("Did Hit");
                if (hit.collider.gameObject.CompareTag("mail"))
                {
                    gameObject.GetComponent<PlayerBackpack>().insert(hit.collider.gameObject.transform.parent.gameObject);

                    Debug.Log("added");
             
                }
               
            }
            else
            {
                Debug.Log("not a valid 'interact 2' object!");
                gameObject.GetComponent<PlayerBackpack>().remove(0);
            }
        }
        if (context.canceled)
        {
            Debug.Log("key released");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            myGlobal.g_CanLook = true;
            gameObject.GetComponent<PlayerBackpack>().hideUI();

        }
    }

    public void release()
    {
        GetComponent<PlayerInfo>().setHolding(null);

    }

}


    

