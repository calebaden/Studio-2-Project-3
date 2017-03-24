using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject currentArea;
    public string currentWeather;
    public float lightFadeSpeed;

    [Header("Ambient Light Variables")]
    //public float ambientFadeSpeed;
    public float sunsetAmbient;
    public float nightAmbient;
    public float snowAmbient;
    public float cloudyAmbient;

    [Header("Directional Light Variables")]
    public Light dirLight;
    //public float dirLightFadeSpeed;
    public float sunsetDirLight;
    public float nightDirLight;
    public float snowDirLight;
    public float cloudyDirLight;

    [Header("SkyPlane Directional Light Variables")]
    public Light skyDirLight;
    //public float skyDirLightFadeSpeed;
    public float sunsetSkyDirLight;
    public float nightSkyDirLight;
    public float snowSkyDirLight;
    public float cloudySkyDirLight;

    [Header("SkyPlane Variables")]
    public GameObject skyPlane;
    Renderer skyRend;
    public Texture sunsetBG;
    public Texture nightBG;
    public Texture snowBG;
    public Texture cloudyBG;


    // Use this for initialization
    void Start ()
    {
        skyRend = skyPlane.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangeWeather();
    }

    // Changes weather based on string variable
    public void ChangeWeather ()
    {
        if (currentWeather == "Sunset")
        {
            ChangeToSunset();
        }
        else if (currentWeather == "Rain")
        {
            ChangeToNight();
        }
        else if (currentWeather == "Snow")
        {
            ChangeToSnow();
        }
        else if (currentWeather == "Cloudy")
        {
            ChangeToCloudy();
        }
    }

    // Function that changes the lighting and skybox to sunset elements
    public void ChangeToSunset ()
    {
        RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, sunsetAmbient, lightFadeSpeed * Time.deltaTime);
        dirLight.intensity = Mathf.Lerp(dirLight.intensity, sunsetDirLight, lightFadeSpeed * Time.deltaTime);
        skyDirLight.intensity = sunsetSkyDirLight;

        if (skyRend.material.mainTexture != sunsetBG)
        {
            skyRend.material.mainTexture = sunsetBG;
        }
    }

    // Function that changes the lighting and skybox to night elements
    public void ChangeToNight ()
    {
        RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, nightAmbient, lightFadeSpeed * Time.deltaTime);
        dirLight.intensity = Mathf.Lerp(dirLight.intensity, nightDirLight, lightFadeSpeed * Time.deltaTime);
        skyDirLight.intensity = nightSkyDirLight;

        if (skyRend.material.mainTexture != nightBG)
        {
            skyRend.material.mainTexture = nightBG;
        }
    }

    // Function that changes the lighting and skybox to snow elements
    public void ChangeToSnow ()
    {
        RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, snowAmbient, lightFadeSpeed * Time.deltaTime);
        dirLight.intensity = Mathf.Lerp(dirLight.intensity, snowDirLight, lightFadeSpeed * Time.deltaTime);
        skyDirLight.intensity = snowSkyDirLight;

        if (skyRend.material.mainTexture != snowBG)
        {
            skyRend.material.mainTexture = snowBG;
        }
    }

    // Function that changes the lighting and skybox to cloudy elements
    public void ChangeToCloudy ()
    {
        RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, cloudyAmbient, lightFadeSpeed * Time.deltaTime);
        dirLight.intensity = Mathf.Lerp(dirLight.intensity, cloudyDirLight, lightFadeSpeed * Time.deltaTime);
        skyDirLight.intensity = cloudySkyDirLight;

        if (skyRend.material.mainTexture != cloudyBG)
        {
            skyRend.material.mainTexture = cloudyBG;
        }
    }
}
