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
    Renderer skyRend;
    public Texture sunsetBG;
    public Texture nightBG;
    public Texture snowBG;

    // Weather variables
    public string currentWeather = "Sunset";

    // Use this for initialization
    void Start ()
    {
        skyRend = skyPlane.GetComponent<Renderer>();
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

        // Switches between night and day depending on the isNight bool
        if (isNight && RenderSettings.ambientIntensity > minAmbient)
        {
            RenderSettings.ambientIntensity -= lightFadeSpeed * Time.deltaTime;
        }
        else if (!isNight && RenderSettings.ambientIntensity < maxAmbient)
        {
            RenderSettings.ambientIntensity += lightFadeSpeed * Time.deltaTime;
        }
	}

    // Function that changes the weather to sunset
    public void ChangeToSunset ()
    {
        isNight = false;
        skyRend.material.mainTexture = sunsetBG;
        currentWeather = "Sunset";
    }

    // Function that changes the weather to night time
    public void ChangeToNight ()
    {
        isNight = true;
        skyRend.material.mainTexture = nightBG;
        currentWeather = "Night";
    }

    // Function that changes the weather to snow
    public void ChangeToSnow ()
    {
        isNight = false;
        skyRend.material.mainTexture = snowBG;
        currentWeather = "Snow";
    }
}
