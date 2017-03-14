using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    PlayerController player;
    GameController gameController;

    public bool hasChosen;
    public string weather;

    public GameObject leftTunnel;
    public GameObject rightTunnel;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.levelController = this;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if (gameController.currentWeather != weather)
        {
            gameController.currentWeather = weather;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
