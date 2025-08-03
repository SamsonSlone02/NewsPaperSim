using UnityEngine;

public class cameraMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + .5f,target.position.z);
        this.transform.position = newPos ;
    }
}
