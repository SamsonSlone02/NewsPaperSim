using UnityEngine;
using System;
//using game.IInteractable
public class MailboxInteract : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public IInteractable interactable;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        
        print("interact recieved!");
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);
    }
    public string GetInteractionPrompt()
    {
        return "";
    }
}
