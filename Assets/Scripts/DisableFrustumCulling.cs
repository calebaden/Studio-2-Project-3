using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFrustumCulling : MonoBehaviour
{
    MeshFilter meshFilter;

	// Use this for initialization
	void Start ()
    {
        meshFilter = GetComponent<MeshFilter>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Transform camTransform = Camera.main.transform;
        float distToCenter = (Camera.main.farClipPlane - Camera.main.nearClipPlane) / 2.0f;
        Vector3 center = camTransform.position + camTransform.forward * distToCenter;
        float extremeBound = 500.0f;
        meshFilter.sharedMesh.bounds = new Bounds(center, Vector3.one * extremeBound);
    }
}
