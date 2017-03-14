﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractScript : MonoBehaviour
{
    [Header("Common Variables")]
    // Common Variables
    public string type;
    public bool isActive = true;

    [Header("Tree Variables")]
    // Tree Variables
    public Color color;

    [Header("Lamp Variables")]
    // Lamp Variables
    public GameObject lampBulb;
    public Light spotLight;
    public Material offMat;
    public Material emissMat;
    public float maxIntensity;
    public float lightFadeSpeed;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Fades the spot lights intensity based on the lamps current state
		if (type == "Lamp" && isActive && spotLight.intensity < maxIntensity)
        {
            spotLight.intensity += lightFadeSpeed * Time.deltaTime;
        }
        else if (type == "Lamp" && !isActive && spotLight.intensity > 0)
        {
            spotLight.intensity -= lightFadeSpeed * Time.deltaTime;
        }
	}

    // Function that checks the objects type and calls the appropriate function
    public void InteractionEvent ()
    {
        if (type == "Tree")
        {
            treeInteraction();
        }
        else if (type == "Lamp")
        {
            lampInteraction();
        }
    }

    // Function that handles the tree's behaviour
    void treeInteraction ()
    {
        if (isActive)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = color;
            isActive = false;
        }
    }

    // Function changes the lamps state from on and off
    void lampInteraction ()
    {
        if (isActive)
        {
            lampBulb.GetComponent<Renderer>().material = offMat;
            isActive = false;
        }
        else
        {
            lampBulb.GetComponent<Renderer>().material = emissMat;
            isActive = true;
        }
    }
}
