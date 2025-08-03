using UnityEngine;
using System;
//using game.IInteractable
public class PickupInteract : MonoBehaviour, IInteractable
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
        //Destroy(gameObject);
    }
    public string GetInteractionPrompt()
    {
        return "";
    }
}
