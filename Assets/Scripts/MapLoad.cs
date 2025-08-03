using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MapLoad : MonoBehaviour
{
    public int x, y, z;
    public int height,width;
    public int plotWidth;
    public int plotHeight;
    string mypath = "xroad";
    string mypath2 = "house1";
    string mypath3 = "house2";
    string wall = "wall";
    string wall1 = "wall1";
    string wall2 = "wall2";
    string wall3 = "wall3";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("running");
        GameObject floor =  Resources.Load(mypath) as GameObject;
        GameObject floor2 = Resources.Load(mypath3) as GameObject;
        GameObject wheat =  Resources.Load(mypath3) as GameObject;
        GameObject nwWall = Resources.Load(mypath) as GameObject;
        GameObject neWall = Resources.Load(mypath) as GameObject;
        GameObject swWall = Resources.Load(mypath) as GameObject;
        GameObject seWall = Resources.Load(mypath) as GameObject;
                          
        GameObject nWall = Resources.Load(wall) as GameObject;
        GameObject eWall = Resources.Load(wall) as GameObject;
        GameObject sWall = Resources.Load(wall) as GameObject;
        GameObject wWall = Resources.Load(wall) as GameObject;

        GameObject[,] worldItems = new GameObject[height,width];
        

        Vector3 origin = new Vector3(x, y, z);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {

                if (i == 0 && j == 0)
                {
                    worldItems[i,j] = Instantiate(seWall, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), seWall.transform.rotation);

                }
                else if (i == height-1 && j == width-1)
                {
                    worldItems[i,j] = Instantiate(nwWall, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), nwWall.transform.rotation);

                }
                else if (i == 0 && j == width-1)
                {
                    worldItems[i,j] = Instantiate(swWall, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), swWall.transform.rotation);
                }
                else if (i == height-1 && j == 0)
                {
                    worldItems[i,j] = Instantiate(neWall, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), neWall.transform.rotation);

                }
                else if (i == height - 1)
                {
                    worldItems[i,j] = Instantiate(nWall, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), nWall.transform.rotation);
                    worldItems[i, j].transform.Rotate(0, 0, 0);

                }
                else if (j == width-1)
                {
                    worldItems[i,j] = Instantiate(wWall, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), wWall.transform.rotation);
                    worldItems[i, j].transform.Rotate(0, 90, 0);

                }
                else if (i == 0)
                {
                    worldItems[i,j] = Instantiate(sWall, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), sWall.transform.rotation);
                    worldItems[i, j].transform.Rotate(0, 180, 0);

                }
                else if (j == 0)
                {
                    worldItems[i,j] = Instantiate(eWall, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), eWall.transform.rotation);
                    worldItems[i, j].transform.Rotate(0, 270, 0);

                }
                else
                {
                    int temp = Random.Range(0, 6);
                    if (temp == 0)
                    {
                        worldItems[i, j] = Instantiate(wheat, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), floor.transform.rotation);

                    }
                    else if (temp ==1)
                    {
                        worldItems[i, j] = Instantiate(floor2, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), floor.transform.rotation);

                    }
                    else 
                    {
                        worldItems[i, j] = Instantiate(floor, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), floor.transform.rotation);

                    }

                }
            }
        }

        //for (int i = 1; i < height - 1; i++)
        //{
        //    for (int j = 1; j < width - 1; j++)
        //    {
        //        int rand = Random.Range(1, 8);

        //        if (rand == 2)
        //        {
        //            Destroy(worldItems[i, j]);
        //            worldItems[i, j] = Instantiate(floor2, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), floor2.transform.rotation);
        //        }
        //        else if (rand > 4)
        //        {
        //            Destroy(worldItems[i, j]);
        //            worldItems[i, j] = Instantiate(wheat, new Vector3(origin.x + (i * plotWidth), 0, origin.z + (j * plotWidth)), wheat.transform.rotation);
        //        }
        //    }
        //}

        //for (int i = 2; i < height - 2; i++)
        //{
        //    for (int j = 2; j < width - 2; j++)
        //    {
        //        if (Random.Range(1, 25) == 3)
        //        {
        //            Destroy(worldItems[i, j + 1]);
        //            Destroy(worldItems[i, j - 1]);
        //            Destroy(worldItems[i - 1, j]);
        //            Destroy(worldItems[i + 1, j]);
        //            worldItems[i, j - 1] = Instantiate(wWall, new Vector3(origin.x + (i * plotWidth), 0, origin.z + ((j - 1) * plotWidth)), wWall.transform.rotation);
        //            worldItems[i, j + 1] = Instantiate(eWall, new Vector3(origin.x + (i * plotWidth), 0, origin.z + ((j + 1) * plotWidth)), eWall.transform.rotation);
        //            worldItems[i - 1, j] = Instantiate(nWall, new Vector3(origin.x + ((i - 1) * plotWidth), 0, origin.z + (j * plotWidth)), nWall.transform.rotation);
        //            worldItems[i + 1, j] = Instantiate(sWall, new Vector3(origin.x + ((i + 1) * plotWidth), 0, origin.z + (j * plotWidth)), sWall.transform.rotation);

        //        }
        //    }
        //}





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
