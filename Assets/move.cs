using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	//movement variables
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	public float boostSpeed = 80f;
	public float bounce = 800f;

	public AudioSource clickAudio;

	public Rigidbody rb;


	void Start() 
	{

		rb = GetComponent<Rigidbody> ();

	}

	//		public void OnCollisionEnter (Collision c)
	//		{
	//			if(collision.gameObject.name == "Bean")  // or if(gameObject.CompareTag("YourWallTag"))
	//			{
	//
	//	
	//			}
	//	
	//	
	//		}
	////

//	void OnCollisionEnter(Collision theCollision)
//	{
//		if (theCollision.gameObject.name == "Bean") 
//		{
//			clickAudio.Play ();
//
//		}
//
//	}
//
//
//







	void Update ()

	{
		//GetComponent<Animation> ().Play ("Husky_Walk");
		//Movement of the car

		//Forward
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);

		}


		if(Input.GetKey(KeyCode.S))
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

		//Left and Right
		if(Input.GetKey(KeyCode.A))
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

		if(Input.GetKey(KeyCode.D))
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

//		//Boost
//		if (Input.GetKey (KeyCode.Space))
//		{
//
//			transform.Translate (Vector3.up * boostSpeed * Time.deltaTime);
//
//
//		}

	}


}
