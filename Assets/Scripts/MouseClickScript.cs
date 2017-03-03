using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if the raycast hit anything
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag == "Interactable")
            {
                // Show interact icon at mouse position
                if (Input.GetMouseButtonDown(0))
                {
                    // Call the interact function on the selected event
                    hit.transform.GetComponent<EnvironmentInteractScript>().InteractionEvent();
                }
            }
        }
	}
}
