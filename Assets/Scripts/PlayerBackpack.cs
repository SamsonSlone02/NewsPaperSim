using System;
using System.Linq;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBackpack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int backpackSize;
    private GameObject[] backpack;
    void Start()
    {
        backpackSize = 6;
        backpack = new GameObject[] {null,null,null,null,null,null};

    }

    // Update is called once per frame
    void Update()
    {
          
    }
    //put in backpack
    public bool insert(GameObject in_object)
    {
        {
            int insertIndex = 0;
            for (int i = 0; i < backpackSize; i++)
            {
                if (backpack[i] == null)
                {
                    backpack[i] = in_object;
                    insertIndex = i;
                    break;
                }
            
            }
            despawn(insertIndex);
        }
        return true;
    }
    //take out of backpack
    public bool remove(int index)
    {

        for (int i = 0; i < backpackSize; i++)
        {
            if (backpack[i] != null)
            {
                spawn(i);
                backpack[i] = null;
            }
        }
            
            return true;
    }

    //makes item invis and hides it??
    void despawn(int index)
    {
        backpack[index].transform.position = new Vector3(0, -1000, 0);
    }
    //spawns the item back in after being stored in the backpack
    void spawn(int index)
    {
        backpack[index].transform.position = transform.position;
    }
}
