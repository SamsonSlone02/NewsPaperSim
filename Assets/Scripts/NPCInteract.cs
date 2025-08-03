using TMPro;
using UnityEngine;
using System.Collections;

public class NPCInteract : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string[] voicelines = { };
    private bool hasUrgentMessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshPro tmpText;
    public Transform textTrans;
    private string pushText;
    public float cps;
    public float cooldownSetTime;
    private Transform playerTrans;
    private bool isTyping;
    private int dialogueCount;

    void Start()
    {
        tmpText.text = "test";
        pushText = "Wow This is a large piece of text being pushed!";
        playerTrans = GameObject.Find("Player").transform;
        textTrans = GameObject.Find("textCanvas").transform;
        isTyping = false;
        voicelines = new string[] { 
            "Wow This is a piece of great dialogue", 
            "Hey! Stop that",
            "This is a test dialogue"
        };

    }


    // Update is called once per frame
    void Update()
    {
        facePlayer();
        
    }
    IEnumerator TypeText(string text)
    {
        isTyping = true;
        tmpText.text = "";
        foreach (char c in text)
        {
            tmpText.text += c;
            yield return new WaitForSeconds(cps);
        }
        isTyping = false;

    }


    private void facePlayer()
    {
        if (playerTrans == null)
        {
            Debug.Log("PLAYER NOT FOUND");
            return;
        }

        //expanding the values so we can only rotate on the y
        Vector3 adjustedPos = new Vector3(playerTrans.position.x, textTrans.position.y, playerTrans.position.z);

        textTrans.LookAt(adjustedPos);
        textTrans.Rotate(0, 180, 0);



    }

    public void Interact()
    {

        Debug.Log("you just interacted with an NPC!");
        //pushText = (voicelines[Random.Range(0,voicelines.Length)].ToString());
        pushText = voicelines[dialogueCount];
        if (!isTyping)
            StartCoroutine(TypeText(pushText));
        dialogueCount = (dialogueCount + 1) % voicelines.Length;
    }

    public string GetInteractionPrompt()
    { 
        return "";
    }
    

}

