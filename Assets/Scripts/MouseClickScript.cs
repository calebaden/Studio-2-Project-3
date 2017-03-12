using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Battlehub.HorizonBending;

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
        // Raycast variables
        Ray[] rays;
        float[] maxDistances;
        HB.ScreenPointToRays(Camera.main, out rays, out maxDistances);

        RaycastHit hit;
        if (HB.Raycast(rays, out hit, maxDistances))
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
                    hit.transform.GetComponent<EnvironmentInteractScript>().InteractionEvent();
                    audioSource.PlayOneShot(interactSound);
                }
            }
            else if (cursorTextureActive)
            {
                Cursor.SetCursor(null, Vector3.zero, cursorMode);
                cursorTextureActive = false;
            }
        }
        else if (cursorTextureActive)
        {
            Cursor.SetCursor(null, Vector3.zero, cursorMode);
            cursorTextureActive = false;
        }
    }
}
