using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractScript : MonoBehaviour
{
    public MouseClickScript mouseClickScript;

    [Header("Common Variables")]
    public string type;
    public bool isActive = true;

    [Header("ParkTree Variables")]
    public GameObject leaves;
    public ParticleSystem leafParticles;
    Animator leafAnimator;
    public AudioClip treeSound;

    [Header("PalmTree Variables")]
    public GameObject coconut;
    Rigidbody coconutRB;

    [Header("SnowTree Variables")]

    [Header("Lamp Variables")]
    public GameObject lampBulb;
    public Light spotLight;
    public Material offMat;
    public Material emissMat;
    public float maxIntensity;
    public float lightFadeSpeed;

    [Header("Bouy Variables")]
    public Animator bouyAnimator;

    // Use this for initialization
    void Start ()
    {
        if (type == "ParkTree")
        {
            leafAnimator = leaves.GetComponent<Animator>();
        }
        else if (type == "PalmTree")
        {
            coconutRB = coconut.GetComponent<Rigidbody>();
        }
        else if (type == "Bouy")
        {
            bouyAnimator = GetComponent<Animator>();
        }
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
        if (type == "ParkTree")
        {
            parkTreeInteraction();
        }
        else if (type == "PalmTree")
        {
            palmTreeInteraction();
        }
        else if (type == "Lamp")
        {
            lampInteraction();
        }
        else if (type == "Bouy")
        {
            bouyInteraction();
        }
    }

    // Function that activates the park tree's animation and particle effect
    void parkTreeInteraction ()
    {
        if (isActive)
        {
            leafAnimator.Play("Fall");
            leafParticles.Play();
            //mouseClickScript.audioSource.PlayOneShot(treeSound);
            isActive = false;
        }
    }

    // Activates the bouy animation
    void bouyInteraction()
    {
        if (isActive)
        {
            bouyAnimator.Play("bouyBobbing");
            isActive = false;
        }
    }

    // Function that sets the kinematic value of the coconut object to false
    void palmTreeInteraction ()
    {
        if (isActive)
        {
            coconutRB.isKinematic = false;
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
