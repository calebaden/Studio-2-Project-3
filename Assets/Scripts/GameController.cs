using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject currentArea;
    public float gameLength;

    // Ambient light variables
    public float maxAmbient;
    public float minAmbient;
    public bool isNight;
    public float lightFadeSpeed;

    // Skyplane variables
    public GameObject skyPlane;
    public Texture sunsetBG;
    public Texture nightBG;

    // Not much going here, will optimize level transition code at a later time

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // PLACEHOLDER: When the song finishes, load the main menu
		if (gameLength > 0)
        {
            gameLength -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        if (isNight && RenderSettings.ambientIntensity > minAmbient)
        {
            RenderSettings.ambientIntensity -= lightFadeSpeed * Time.deltaTime;
        }
        else if (!isNight && RenderSettings.ambientIntensity < maxAmbient)
        {
            RenderSettings.ambientIntensity += lightFadeSpeed * Time.deltaTime;
        }
	}
}
