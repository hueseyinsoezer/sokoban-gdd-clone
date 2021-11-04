using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class limitedMoveCube : MonoBehaviour
{
    public mapController _mapController;
    public GameObject player;
    public Text stepLabel;
    public int stepValue;
    private GameObject redZone; 
    private GameObject[] walls, traps;
    private Vector3 playerPosition, playerDirection;
    public Vector3 startPosition, lastPosition, lastTrapPosition;
    public bool bridge, limitedIsInTarget, limited;

    void Start()
    {
        startPosition = this.transform.position;
        playerPosition = player.GetComponent<Transform>().position;
        playerDirection = player.GetComponent<playerController>().playerDirection;
        walls = GameObject.FindGameObjectsWithTag("wall");
        traps = GameObject.FindGameObjectsWithTag("trap");
        redZone = GameObject.FindGameObjectWithTag("redZone");
        _mapController = GameObject.FindGameObjectWithTag("gameController").GetComponent<mapController>();
        bridge = false;
        limitedIsInTarget = false;
        limited = false;          
        stepValue = _mapController.steps;
        stepLabel.text = stepValue.ToString();
    }

    void Update()
    {
        
        playerPosition = player.GetComponent<Transform>().position;
        playerDirection = player.GetComponent<playerController>().playerDirection;
        IsInPosition();
        LimitPosition();
        StepLimit();
        if (bridge == false && limited == false)
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
            
        }
        else if(bridge == true)
        {
            if (limited == true && player.transform.position == this.transform.position)
            {
                player.transform.Translate(-playerDirection);
                this.transform.Translate(new Vector3(0, 0, 0));
            }
            this.transform.position = lastPosition;
            
        }
        

    }
    private void IsInPosition()
    {
        if ((this.transform.position.x == redZone.transform.position.x && this.transform.position.z == redZone.transform.position.z))
        {
            limitedIsInTarget = true;
        }
        else if (this.transform.position.x != redZone.transform.position.x)
        {
            limitedIsInTarget = false;
        }
        
    }
    private void LimitPosition()
    {
        limited = false;
        if(this.transform.position != startPosition)
        {
            stepValue--;
            stepLabel.text = stepValue.ToString();
            startPosition = this.transform.position;            
        }
        if(stepValue == 0)
        {
            stepValue = 0;
            limited = true;
            enabled = false;
        }

    }
    private void StepLimit()
    {
        Vector3 numberPos = Camera.main.WorldToScreenPoint(this.transform.position);
        stepLabel.transform.position = numberPos;
    }
}
