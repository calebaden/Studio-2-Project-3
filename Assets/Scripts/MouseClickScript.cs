using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClickScript : MonoBehaviour
{
    AudioSource audioSource;

    public Texture2D interactIcon;
    public Vector2 hotSpot;
    public CursorMode cursorMode = CursorMode.Auto;

    bool cursorTextureActive = false;

    public AudioClip interactSound;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
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
                if (!cursorTextureActive)
                {
                    Cursor.SetCursor(interactIcon, hotSpot, cursorMode);
                    cursorTextureActive = true;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    // Call the interact function on the selected event
                    hit.transform.GetComponent<EnvironmentInteractScript>().InteractionEvent();
                    audioSource.PlayOneShot(interactSound);
                }
            }
            else
            {
                if (cursorTextureActive)
                {
                    Cursor.SetCursor(null, Vector3.zero, cursorMode);
                    cursorTextureActive = false;
                }
            }
        }
	}
}
