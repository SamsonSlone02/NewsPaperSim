using UnityEngine;

public class game : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 144;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
