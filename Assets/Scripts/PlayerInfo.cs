using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject currHeld;
    private float money;
    public int backpackSize;



    void Start()
    {
        backpackSize = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool compareHolding(GameObject in_object)
    {
        if (currHeld == in_object)
        {
            return true;
        }

        return false;
    }

    public bool isHolding()
    {
        if (currHeld != null)
        {
            return true;
        }

        return false;
    }

    public bool setHolding(GameObject in_object)
    {
        currHeld= in_object;
        return true;

        
    }

    public bool addMoney(float in_money)
    {
        money += in_money;
        return true;
    }
    public float getMoney()
    {

        return money;
    }

}   
