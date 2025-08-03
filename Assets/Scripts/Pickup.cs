using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Pickup : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject target;
    public Transform cameraTransform;
    private Quaternion cameraRot;
    private Quaternion startRot;
    private Vector3 cameraDir;
    private Vector3 cameraPos;
    private Vector3 targetPos;
    private Vector3 dirDiff;
    public float throwspeed;
    private bool following;
    public GameObject player;
    [SerializeField]
    private float distanceFromPlayer = 3;
   

    void Start()
    {
        player = GameObject.Find("Player");
        cameraTransform = GameObject.Find("Camera").transform;
       
      
        following = false;
        target = this.gameObject;
        cameraPos = cameraTransform.position;
        cameraRot = cameraTransform.rotation;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!player.GetComponent<PlayerInfo>().compareHolding(this.gameObject)) 
        {
            following = false;
        }
        if (following)
        {
            cameraDir = cameraTransform.forward.normalized;
            cameraPos = cameraTransform.position;
            cameraRot = cameraTransform.rotation;
            targetPos.x = cameraPos.x + cameraDir.x * distanceFromPlayer;
            targetPos.y = cameraPos.y + cameraDir.y * distanceFromPlayer;
            targetPos.z = cameraPos.z + cameraDir.z * distanceFromPlayer;
            //float x = cameraTransform.rotation.x + startRot.x;
            //float y = cameraTransform.rotation.y + startRot.y;
            //float z = cameraTransform.rotation.z + startRot.z;
            float x = cameraTransform.rotation.x;
            float y = cameraTransform.rotation.y;
            float z = cameraTransform.rotation.z;

            //target.transform.rotation *= Quaternion.Euler(x,y,z).normalized;


            if (target == null)
                return;


            dirDiff = targetPos - target.transform.position;
            float tempDistance = Vector3.Distance(targetPos, target.transform.position);
            tempDistance = Mathf.Abs(tempDistance);
            if (tempDistance > 5)
            {
                target.transform.position = targetPos;
            }
            float currentSpeed = Mathf.Lerp(10f, 20f, Mathf.Clamp01(tempDistance / 5));
            if (tempDistance < .5f)
            {
                currentSpeed = Mathf.Lerp(.2f, 20f, Mathf.Clamp01(tempDistance / 5));
            }


            // Debug.Log(currentSpeed);
            target.GetComponent<Rigidbody>().linearVelocity = dirDiff.normalized * currentSpeed;

            Debug.DrawLine(target.transform.position, target.transform.position + dirDiff * 10, Color.red, 0);

            target.transform.rotation = cameraRot * startRot;

        }
    }


    public void pickup(GameObject in_target = null)
    {

        Debug.Log("pickup called");
        if (in_target == null)
        {
            target = null;
        }
        else
        {
            target = in_target;
            startRot = target.transform.rotation;
        }
    }

    public void throwObj(GameObject in_target = null)
    {

        Debug.Log("pickup called");
        if (target != null)
        {

            Rigidbody temp = target.GetComponent<Rigidbody>();
            temp.angularVelocity = new Vector3(0, 0, 0);
            temp.linearVelocity = new Vector3(0, 0, 0);
            target = null;
            temp.AddForce(cameraDir * (throwspeed * 500));
            Debug.Log((cameraDir * (throwspeed * 500)).ToString());
            
        }
        
    }
    public void Interact()
    {
        following = !following;
        player.GetComponent<PlayerInfo>().setHolding(this.gameObject);
        
        //Destroy(gameObject);
    }
    public string GetInteractionPrompt()
    {
        return "";
    }
  

}


