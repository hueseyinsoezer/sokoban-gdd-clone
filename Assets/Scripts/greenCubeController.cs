using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenCubeController : MonoBehaviour
{
    public GameObject player;
    private GameObject greenZone;
    private GameObject[] walls, traps, redCubes;
    private Vector3 playerPosition, playerDirection;
    public Vector3 lastPosition, lastTrapPosition;
    public bool bridge, greenReach, collided;

    void Start()
    {
        playerPosition = player.GetComponent<Transform>().position;
        playerDirection = player.GetComponent<playerController>().playerDirection;
        walls = GameObject.FindGameObjectsWithTag("wall");
        traps = GameObject.FindGameObjectsWithTag("trap");
        greenZone = GameObject.FindGameObjectWithTag("greenZone");
        redCubes = GameObject.FindGameObjectsWithTag("redCube");
        bridge = false;
        greenReach = false;
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
                        traps[i].transform.position += new Vector3(0f, 0f, 100f);
                        lastTrapPosition = traps[i].transform.position;
                        break;
                    }
                }
            }
            for (int i = 0; i < redCubes.Length; i++)
            {
                if (this.transform.position == redCubes[i].transform.position)
                {                  
                    if (collided == false)
                    {
                        collided = true;
                        player.transform.Translate(-playerDirection);
                        transform.Translate(-playerDirection);
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
            enabled = false;
        }
    }
    public bool GreenIsInPosition()
    {

        if (this.transform.position.x == greenZone.transform.position.x && this.transform.position.z == greenZone.transform.position.z)
        {
            return true;
        }
        else if (this.transform.position.x != greenZone.transform.position.x)
        {
            return false;
        }
        return false;
    }
}
