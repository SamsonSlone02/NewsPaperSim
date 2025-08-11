using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MapLoad : MonoBehaviour
{
    public float x, y, z;
    public int height, width;
    public int plotWidth;
    public int plotHeight;
    string mypath = "xroad";
    string mypath2 = "house1";
    string mypath3 = "house2";
    string wall = "wall";
    string wall1 = "wall1";
    string wall2 = "wall2";
    string wall3 = "wall3";

    string hRoad = "-";
    public GameObject hRoadObject;

    string vRoad = "|";
    public GameObject vRoadObject;

    string leftLRoad = "LL";
    public GameObject leftLRoadObject;

    string revLeftLRoad = "RLL";
    public GameObject revLeftLRoadObject;

    string rightLRoad = "RL";
    public GameObject rightLRoadObject;

    string revRightLRoad = "RRL";
    public GameObject revRightLRoadObject;

    string leftThreeWay = "}";
    public GameObject leftThreeWayObject;

    string rightThreeWay = "{";
    public GameObject rightThreeWayObject;

    string rightHouse = "RH";
    public GameObject rightHouseObject;

    string leftHouse = "LH";
    public GameObject leftHouseObject;

    string upHouse = "UH";
    public GameObject upHouseObject;

    string downHouse = "DH";
    public GameObject downHouseObject;

    string fountain = "F";
    public GameObject fountainObject;

    string placeholder = "#";
    public GameObject placeholderObject;

    string[,] asciiMap;

    
    
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("running");
        GameObject[,] worldItems = new GameObject[height, width];
        asciiMap = new string[height, width];

        createAsciiMap();
        connectRoads();
        loadHouses();
        loadMap();
        printMap();

    }

    void createAsciiMap()
    {
        //3 part load?

        //first roads
        //houses
        //decor?
        for (int i = 0; i < height; i++)
        {

            for (int j = 0; j < width; j++)
            {
                //leaves one block of padding on the outside of the width; road will not reach the end of both sides
                if ((i % 2 == 0 && (j > 0 && j < width - 1)))
                {
                    asciiMap[i, j] = hRoad;
                }
               
                else
                {

                    asciiMap[i, j] = placeholder;
                }
            }
            
        }
        for (int i = 1; i < height-1; i++)
        {
            if (i % 2 != 0)
            {
                int rng = UnityEngine.Random.Range(0, 3);

                switch (rng) {
                    case 0:
                        asciiMap[i, 1] = vRoad;
                        break;
                    case 1:
                        asciiMap[i, width - 2] = vRoad;
                        break;
                    case 2:
                        asciiMap[i, 1] = vRoad;
                        asciiMap[i, width - 2] = vRoad;
                        break;
                }

            }
        }

       

        asciiMap[height-1, width-1] = fountain;
    }
    void printMap()
    {
        Debug.Log(string.Join("\n", Enumerable.Range(0, asciiMap.GetLength(0)).Select(i => string.Join(" ", Enumerable.Range(0, asciiMap.GetLength(1)).Select(j => asciiMap[i, j])))));
    }

    void loadMap()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {

                GameObject instantiatedObejct;
                switch (asciiMap[i, j])
                {
                    case "-":
                        instantiatedObejct = Instantiate(hRoadObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.identity);
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "|":
                        instantiatedObejct = Instantiate(vRoadObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.Euler(0, 90, 0));
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "#":
                        instantiatedObejct = Instantiate(placeholderObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.identity);
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "RLL":
                        instantiatedObejct = Instantiate(revLeftLRoadObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.identity);
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "LL":
                        instantiatedObejct = Instantiate(leftLRoadObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.Euler(0, 270, 0));
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "RRL":
                        instantiatedObejct = Instantiate(revRightLRoadObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.Euler(0, 90, 0));
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "RL":
                        instantiatedObejct = Instantiate(rightLRoadObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.Euler(0, 180, 0));
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "}":
                        instantiatedObejct = Instantiate(leftThreeWayObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.identity);
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "{":
                        instantiatedObejct = Instantiate(rightThreeWayObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.Euler(0, 180, 0));
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "F":
                        instantiatedObejct = Instantiate(fountainObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.identity);
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "RH":
                        instantiatedObejct = Instantiate(rightHouseObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.identity);
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "LH":
                        instantiatedObejct = Instantiate(leftHouseObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.Euler(0, 180, 0));
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "UH":
                        instantiatedObejct = Instantiate(upHouseObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.Euler(0, 270, 0));
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;
                    case "DH":
                        instantiatedObejct = Instantiate(downHouseObject, new Vector3((j * -plotWidth) + x, 0 + y, (i * plotHeight) + z), Quaternion.Euler(0, 90, 0));
                        instantiatedObejct.transform.SetParent(this.transform, false);
                        break;



                }

            }
        }
    
    }
    void connectRoads()
    {
        if (asciiMap[1, 1] == vRoad)
        {
            asciiMap[0, 1] = revLeftLRoad;
        }
        if (asciiMap[1, width - 2] == vRoad)
        {
            asciiMap[0, width-2] = revRightLRoad;
        }



        for (int i = 2; i < height-1; i += 2)
        {


            if (asciiMap[i - 1, 1] == vRoad)
            {
                asciiMap[i, 1] = leftLRoad;
            }
            if (asciiMap[i + 1, 1] == vRoad)
            {
                asciiMap[i, 1] = revLeftLRoad;
            }

            if (asciiMap[i - 1, width-2] == vRoad)
            {
                asciiMap[i, width-2] = rightLRoad;
            }
            if (asciiMap[i + 1, width - 2] == vRoad)
            {
                asciiMap[i, width - 2] = revRightLRoad;
            }



            //if (asciiMap[i + 1, 1] == vRoad && asciiMap[i - 1, 1] == vRoad)
            //{
            //    asciiMap[i, 1] = leftThreeWay;
            //}
            //if (asciiMap[i + 1, width-2] == vRoad && asciiMap[i - 1, width-2] == vRoad)
            //{
            //    asciiMap[i, width-2] = rightThreeWay;
            //}



            
        }

        for (int i = 2; i < height-1; i += 2)
        {

            if (asciiMap[i + 1, 1] == vRoad && asciiMap[i - 1, 1] == vRoad)
            {
                asciiMap[i, 1] = leftThreeWay;
            }
            if (asciiMap[i + 1, width-2] == vRoad && asciiMap[i - 1, width-2] == vRoad)
            {
                asciiMap[i, width-2] = rightThreeWay;
            }

        }

        
    }

    void loadHouses()
    {
        for (int i = 0; i < height; i++)
        {
            if (asciiMap[i, 1] != placeholder)
            {
                asciiMap[i, 0] = leftHouse;
            }
            if (asciiMap[i, width - 2] != placeholder)
            {
                asciiMap[i, width - 1] = rightHouse;
            }

        }


        for (int i = 1; i < height; i+=2)
        {
            int rng = UnityEngine.Random.Range(0, 2);
            for (int j = 2; j < width-2; j++)
            {

                switch (rng)
                {
                    case 0:
                        if (i == height - 1)
                        {
                            asciiMap[i, j] = upHouse;
                        }else
                            asciiMap[i, j] = downHouse;
                        break;
                    case 1:
                        asciiMap[i, j] = upHouse;
                        break;

                }


            }
        
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
