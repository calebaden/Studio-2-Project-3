using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractScript : MonoBehaviour
{
    
    // Common Variables
    public string type;
    public bool isActive = true;

    // Tree Variables
    public Color color;

    // Lamp Variables
    public GameObject lampBulb;
    public Light spotLight;
    public Material baseMat;
    public Material emissMat;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

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

    void treeInteraction ()
    {
        if (isActive)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = color;
            isActive = false;
        }
    }

    void lampInteraction ()
    {
        if (isActive)
        {
            //spotLight.intensity = 1;
            lampBulb.GetComponent<Renderer>().material = emissMat;
            isActive = false;
        }
        else
        {
            //spotLight.intensity = 0;
            lampBulb.GetComponent<Renderer>().material = baseMat;
            isActive = true;
        }
    }
}
