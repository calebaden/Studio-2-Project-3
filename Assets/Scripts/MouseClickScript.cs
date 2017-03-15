using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Battlehub.HorizonBending;

public class MouseClickScript : MonoBehaviour
{
    PlayerController playerController;
    AudioSource audioSource;

    public Texture2D interactIcon;
    public Texture2D rightArrow;
    public Texture2D leftArrow;
    public Vector2 hotSpot;
    public CursorMode cursorMode;

    bool cursorTextureActive = false;

    public AudioClip interactSound;

	// Use this for initialization
	void Start ()
    {
        playerController = GetComponent<PlayerController>();
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
            else if (hit.collider.tag == "RightSign")
            {
                if (!cursorTextureActive)
                {
                    Cursor.SetCursor(rightArrow, hotSpot, cursorMode);
                    cursorTextureActive = true;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    playerController.ChooseDirection("Right");
                }
            }
            else if (hit.collider.tag == "LeftSign")
            {
                if (!cursorTextureActive)
                {
                    Cursor.SetCursor(leftArrow, hotSpot, cursorMode);
                    cursorTextureActive = true;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    playerController.ChooseDirection("Left");
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
