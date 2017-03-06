using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractScript : MonoBehaviour
{
    Renderer rend;

    public Color color;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void InteractionEvent ()
    {
        // Do the thing
        rend.material.color = color;
    }
}
