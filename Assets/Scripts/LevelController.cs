using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    PlayerController player;

    public bool hasChosen;

    public GameObject leftTunnel;
    public GameObject rightTunnel;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.levelController = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
