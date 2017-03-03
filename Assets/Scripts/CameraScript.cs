using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 zoomOut = new Vector3(0, 25, 0);
    public Vector3 zoomIn = new Vector3(0, 5, 0);
    public float zoomSpeed;
    public bool isZoomed;
    public float minDistance;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (isZoomed && Vector3.Distance(transform.localPosition, zoomIn) > minDistance)
        {
            // If the camera is set to zoom in but is not within the minimum distance, move it towards the zoom in position
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, zoomIn, zoomSpeed * Time.deltaTime);
        }
        else if (!isZoomed && Vector3.Distance(transform.localPosition, zoomOut) > minDistance)
        {
            // If the camera is set to zoom out but is not within the minimum distance, move it towards the zoom out position
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, zoomOut, zoomSpeed * Time.deltaTime);
        }
	}
}
