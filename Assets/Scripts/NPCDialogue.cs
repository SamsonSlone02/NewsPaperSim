using TMPro;
using UnityEngine;
using System.Collections;

public class NPCDialogue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshPro tmpText;
    private int charCount;
    private string pushText;
    private string currentText;
    private float counter;
    private int speed;
    public float cps;
    public float cooldownSetTime;
    private float cooldownTimer;
    private bool isOnCooldown;
    private Transform playerTrans;
    private bool isTyping;

    void Start()
    {
        tmpText.text = "test";
        pushText = "Wow This is a large piece of text being pushed!";
        currentText = "";
        charCount = 0;
        counter = 0;
        speed = 0;
        isOnCooldown = false;
        playerTrans = GameObject.Find("Player").transform;
        isTyping = false;

    }
    

    // Update is called once per frame
    void Update()
    {
        facePlayer();
        if (!isTyping)
            StartCoroutine(TypeText(pushText));
       
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
        yield return new WaitForSeconds(cooldownSetTime);
        tmpText.text = "";
        isTyping = false;
    }


    private void facePlayer()
    {
        if (playerTrans == null)
        {
            return;
        }

        //expanding the values so we can only rotate on the y
        Vector3 adjustedPos = new Vector3(playerTrans.position.x, this.transform.position.y, playerTrans.position.z);

        transform.LookAt(adjustedPos);
        transform.Rotate(0, 180, 0);
       


    }    
    
}
