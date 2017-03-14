﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LevelController levelController;
    CameraScript cameraScript;
    GameController gameController;
    UIController uiController;

    public float moveSpeed;
    public bool isChangingLane;
    public float tunnelLength;
    public GameObject target;
    public GameObject rainObject;

	// Use this for initialization
	void Start ()
    {
        cameraScript = GetComponentInChildren<CameraScript>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        uiController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If the player is not changing lanes, move forwards at the movement speed
        if (!isChangingLane)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        // If the player is changing lanes, move towards the target
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
	}

    // Function that is called when exiting another collider
    private void OnTriggerExit(Collider otherObject)
    {
        if (otherObject.gameObject.tag == "Junction")
        {
            if (!levelController.hasChosen)
            {
                int rand = Random.Range(0, 2);                                  // Create a random value between 0 and 1 (inclusive)
                if (rand == 0)
                {
                    target = levelController.leftTunnel;                        // If the random value is 0, set the target to the left tunnel of the current area
                }
                else
                {
                    target = levelController.rightTunnel;                       // If the random value is 1, set the target to the right tunnel of the current area
                }
            }

            // Start changing lane and zoom in the camera
            isChangingLane = true;
            cameraScript.isZoomed = true;
        }
    }

    // Function that is called when entering another collider
    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.gameObject.tag == "TunnelEntrance")     // Check if the other object is a tunnel entrance
        {
            isChangingLane = false;                                                 // Set the changing lane bool to false so the character walks in a straight line
            otherObject.GetComponent<LoadAreaScript>().areaToLoad.SetActive(true);  // Load the next area that is a game object on the colliders script
            otherObject.GetComponent<LoadAreaScript>().areaToLoad.transform.position = otherObject.transform.position + new Vector3(0, -0.5f, tunnelLength);
        }
        else if (otherObject.gameObject.tag == "TunnelExit")            // Check if the other object is a tunnel exit
        {
            cameraScript.isZoomed = false;                              // Disable the camera zooming
            gameController.currentArea.SetActive(false);                // Unload the area just gone
            gameController.currentArea = levelController.gameObject;    // Set the current are to the area just arrived
        }

        if (otherObject.gameObject.tag == "FrostDisable")
        {
            Camera.main.gameObject.GetComponent<FrostController>().isFrosty = false;
        }
        else if (otherObject.gameObject.tag == "FrostEnable")
        {
            Camera.main.gameObject.GetComponent<FrostController>().isFrosty = true;
        }

        if (otherObject.gameObject.tag == "RainDisable")
        {
            rainObject.SetActive(false);
        }
        else if (otherObject.gameObject.tag == "RainEnable")
        {
            rainObject.SetActive(true);
        }

        if (otherObject.gameObject.tag == "EndTrigger")
        {
            uiController.isFaded = true;
        }
    }

    public void ChooseLeft ()
    {
        if (!levelController.hasChosen)
        {
            target = levelController.leftTunnel;                                // Set the target to the left tunnel in the current area
            levelController.hasChosen = true;                                   // Set the has chosen variable to true
        }
    }

    public void ChooseRight ()
    {
        if (!levelController.hasChosen)
        {
            target = levelController.rightTunnel;                               // Set the target to the right tunnel in the current area
            levelController.hasChosen = true;                                   // Set the has chosen variable to true
        }
    }
}
