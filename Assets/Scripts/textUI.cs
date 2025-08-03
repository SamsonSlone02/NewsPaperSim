using UnityEngine;
using TMPro;
public class textUI : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //tmpText.text = "Hello, World!";
        tmpText.text = GetComponent<PlayerInfo>().getMoney().ToString() + " dollars...";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateText(string newText)
    {
        tmpText.text = newText;
        
    }
}
