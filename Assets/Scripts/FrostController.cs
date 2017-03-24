using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostController : MonoBehaviour
{
    FrostEffect frostScript;

    public bool isFrosty = false;
    public float maxFrost = 0.36f;
    public float minFrost = 0;
    public float removeMult;

	// Use this for initialization
	void Start ()
    {
        frostScript = GetComponent<FrostEffect>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isFrosty)
        {
            frostScript.FrostAmount = Mathf.Lerp(frostScript.FrostAmount, maxFrost, 1 * Time.deltaTime);

            if (Input.mousePosition.x < Screen.width / 2 && Input.GetAxis("Mouse X") < 0)
            {
                float mouseX = Input.GetAxis("Mouse X");
                mouseX = Mathf.Clamp(mouseX, -1, 0);
                frostScript.FrostAmount = Mathf.Lerp(frostScript.FrostAmount, minFrost, (mouseX * -removeMult) * Time.deltaTime);
            }
            else if (Input.mousePosition.x > Screen.width / 2 && Input.GetAxis("Mouse X") > 0)
            {
                float mouseX = Input.GetAxis("Mouse X");
                mouseX = Mathf.Clamp(mouseX, 0, 1);
                frostScript.FrostAmount = Mathf.Lerp(frostScript.FrostAmount, minFrost, (Input.GetAxis("Mouse X") * removeMult) * Time.deltaTime);
            }
        }
        else
        {
            frostScript.FrostAmount = Mathf.Lerp(frostScript.FrostAmount, minFrost, 1 * Time.deltaTime);
        }
	}
}
