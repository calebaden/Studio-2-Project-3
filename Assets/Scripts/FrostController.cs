using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostController : MonoBehaviour
{
    FrostEffect frostScript;

    public bool isFrosty = false;
    public float maxFrost = 0.36f;
    public float minFrost = 0;

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
        }
        else
        {
            frostScript.FrostAmount = Mathf.Lerp(frostScript.FrostAmount, minFrost, 1 * Time.deltaTime);
        }
        
	}
}
