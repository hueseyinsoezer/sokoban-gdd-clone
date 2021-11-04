using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redCubeController : MonoBehaviour
{
    public GameObject player;
    private GameObject redZone;
    private GameObject[] walls, traps, greenCubes;
    private Vector3 playerPosition, playerDirection;
    public Vector3 lastPosition, lastTrapPosition;
    public bool bridge, collided;

    void Start()
    {
        playerPosition = player.GetComponent<Transform>().position;
        playerDirection = player.GetComponent<playerController>().playerDirection;
        walls = GameObject.FindGameObjectsWithTag("wall");
        traps = GameObject.FindGameObjectsWithTag("trap");
        redZone = GameObject.FindGameObjectWithTag("redZone");
        greenCubes = GameObject.FindGameObjectsWithTag("greenCube");
        bridge = false;
        collided = false;
    }

    void Update()
    {   
        playerPosition = player.GetComponent<Transform>().position;
        playerDirection = player.GetComponent<playerController>().playerDirection;
        if (bridge == false)
        {
            if (playerPosition.z == this.transform.position.z)
            {
                if (playerPosition.x == this.transform.position.x)
                {
                    transform.Translate(playerDirection);
                }
                else if (playerPosition.x == this.transform.position.x)
                {
                    transform.Translate(playerDirection);
                }
            }
            else if (playerPosition.x == this.transform.position.x)
            {
                if (playerPosition.z == this.transform.position.z)
                {
                    transform.Translate(playerDirection);
                }
                else if (playerPosition.z == this.transform.position.z)
                {
                    transform.Translate(playerDirection);
                }
            }
            for (int i = 0; i < walls.Length; i++)
            {
                if (this.transform.position == walls[i].transform.position)
                {
                    transform.Translate(-playerDirection);
                    player.transform.Translate(-playerDirection);
                }
            }
            for (int i = 0; i < traps.Length; i++)
            {
                if (this.transform.position.x == traps[i].transform.position.x && this.transform.position.z == traps[i].transform.position.z)
                {
                    lastPosition = traps[i].transform.position;
                    bridge = true;
                    if (bridge == true)
                    {
                        traps[i].transform.position += new Vector3(100f, 0f, 0f);
                        lastTrapPosition = traps[i].transform.position;
                        break;
                    }
                }
            }
            for (int i = 0; i < greenCubes.Length; i++)
            {
                if (this.transform.position == greenCubes[i].transform.position)
                {
                    collided = true;
                    if (collided == true)
                    {        
                        player.transform.Translate(-playerDirection);
                        transform.Translate(-playerDirection);
                        collided = false;
                    }
                }
                else
                {
                    collided = false;
                }
            }
        }
        else
        {
            this.transform.position = lastPosition;
        }
    }
    public bool RedIsInPosition()
    {
        if (this.gameObject.transform.position == lastPosition)
        {
            return true;
        }
        else if (this.transform.position.x == redZone.transform.position.x && this.transform.position.z == redZone.transform.position.z)
        {
            return true;
        }
        else if (this.transform.position.x != redZone.transform.position.x)
        {
            return false;
        }
        return false;
    }
}
