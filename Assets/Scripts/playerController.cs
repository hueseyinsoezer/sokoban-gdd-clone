using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public limitedMoveCube _limitedMoveCube;
    public Vector3 playerPosition, playerDirection;
    private Vector3 redBridgePosition, greenBridgePosition;
    private GameObject[] walls, traps;
    public bool movement;
    
    void Start()
    {
        _limitedMoveCube = GameObject.Find("limited-steps-red-cube").GetComponent<limitedMoveCube>();
        playerPosition = this.transform.position;
        walls = GameObject.FindGameObjectsWithTag("wall");
        traps = GameObject.FindGameObjectsWithTag("trap");
        redBridgePosition = GameObject.FindGameObjectWithTag("redCube").GetComponent<redCubeController>().lastTrapPosition;
        greenBridgePosition = GameObject.FindGameObjectWithTag("greenCube").GetComponent<greenCubeController>().lastTrapPosition;

        movement = true;
    }
        
    void Update()
    {
        
        playerPosition = this.transform.position;
        if (movement == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.Translate(new Vector3(-1f, 0f, 0f));
                playerDirection = new Vector3(-1f, 0f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.Translate(new Vector3(1f, 0f, 0f));
                playerDirection = new Vector3(1f, 0f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                transform.Translate(new Vector3(0f, 0f, 1f));
                playerDirection = new Vector3(0f, 0f, 1f);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                transform.Translate(new Vector3(0f, 0f, -1f));
                playerDirection = new Vector3(0f, 0f, -1f);
            }
        }
        else
        {
            enabled = false;
            GameObject.Find("LevelManager").GetComponent<levelManager>().LosePanel();
        }        
        for (int x = 0; x < walls.Length; x++)
        {
            if (playerPosition == walls[x].transform.position)
            {
                transform.Translate(-playerDirection);
            }   
        }


        for (int y = 0; y < traps.Length; y++)
        {

            if (playerPosition.x == traps[y].transform.position.x && playerPosition.z == traps[y].transform.position.z)
            {
                if ((traps[y].transform.position.x != redBridgePosition.x && traps[y].transform.position.z != redBridgePosition.z)|| (traps[y].transform.position.x != greenBridgePosition.x && traps[y].transform.position.z != greenBridgePosition.z))
                {
                    movement = true;
                }
                transform.Translate(new Vector3(0, -2f, 0));
                movement = false;
                break;
            }
            else
            {
                movement = true;
            }
        }
        if (_limitedMoveCube.limited == true && this.transform.position == _limitedMoveCube.startPosition)
        {
            transform.Translate(-playerDirection);
        }

    }   
}
