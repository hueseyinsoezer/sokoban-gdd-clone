using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSystem : MonoBehaviour
{
 
    public int columnLength, rowLength;
    public float x_Start, y_Start, x_Space, y_Space;
    public GameObject prefabGround, prefabWall;


    private void Start()
    {
        
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            if ((i % columnLength) == 0 || (i % columnLength) == columnLength-1)
            {
                GameObject a = Instantiate(prefabWall, new Vector3(x_Start + (x_Space * (i % columnLength)), y_Start + (-y_Space * (i / columnLength))), Quaternion.identity);
               // a.transform.Rotate(0, 0, 0);
                a.transform.parent = GameObject.Find("Map").transform;
                
            }
            else if (y_Start + (-y_Space * (i / columnLength)) == y_Start || (y_Start + (-y_Space * (i / columnLength))) == (y_Start - (rowLength - 1)))
            {
                GameObject a = Instantiate(prefabWall, new Vector3(x_Start + (x_Space * (i % columnLength)), y_Start + (-y_Space * (i / columnLength))), Quaternion.identity);
                //a.transform.Rotate(0, 0, 0);
                a.transform.parent = GameObject.Find("Map").transform;
                
            }
            else if (0 < x_Space * (i % columnLength) && x_Space * (i % columnLength) < columnLength-1)
            {
                GameObject a = Instantiate(prefabGround, new Vector3(x_Start + (x_Space * (i % columnLength)), y_Start + (-y_Space * (i / columnLength))), Quaternion.identity);
                //a.transform.Rotate(0, 0, 0);
                a.transform.parent = GameObject.Find("Map").transform;
               
            }

        }
        GameObject.Find("Map").transform.Rotate(90, 0, 0);
    }
    private void Update()
    {
        
    }

}

    



