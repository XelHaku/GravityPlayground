using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Gravity : MonoBehaviour {
	public GameObject GravityGlow;
	public float GravityFactor=10;
	public float initAngle;
	public float initVelocity;
	private double time;
	private double RealPosX, RealPosY;
	float initVel_X ;
	float initVel_Y;
	// Use this for initialization
	void Start () {
		 initVel_X = initVelocity * Mathf.Cos (Mathf.Deg2Rad*initAngle);
		 initVel_Y = initVelocity * Mathf.Sin (Mathf.Deg2Rad* (initAngle));
		var initiateVelocity = new Vector2 (initVel_X, initVel_Y); 
		GetComponent<Rigidbody2D> ().velocity = initiateVelocity;
		RealPosX = GetComponent<Rigidbody2D> ().position.x;
		RealPosY = GetComponent<Rigidbody2D> ().position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
		ApplyGravityGlowForceToBall ();
		time =Time.deltaTime ;
	}

	void ApplyGravityGlowForceToBall(){
		double tempGravityX = 0;
		double tempGravityY = 0;

		double RvecX, RvecY;
		double Radius;


		//change gravity
	    RvecX = GetComponent<Rigidbody2D> ().position.x - GravityGlow.GetComponent<SpriteRenderer> ().bounds.center.x;
		RvecY = GetComponent<Rigidbody2D> ().position.y - GravityGlow.GetComponent<SpriteRenderer> ().bounds.center.y;

		Radius = Math.Pow (RvecX, 2.0f) + Math.Pow (RvecY, 2.0f);
		Radius = Math.Pow (Radius, 0.5f);


		Radius = Math.Pow (Radius, 3f);

		if (Radius > GravityGlow.GetComponent<SpriteRenderer> ().bounds.size.x || true) {
			tempGravityX -= GravityFactor *GravityGlow.GetComponent<SpriteRenderer> ().bounds.size.x * GetComponent<SpriteRenderer> ().bounds.size.x * RvecX / (Radius);
			tempGravityY -= GravityFactor * GravityGlow.GetComponent<SpriteRenderer> ().bounds.size.y * GetComponent<SpriteRenderer> ().bounds.size.y * RvecY / (Radius);
		}

		double TempPosX = RealPosX;
		double TempPosY = RealPosY;

		RealPosX = RealPosX + initVel_X* time + tempGravityX * time * time;
		RealPosY = RealPosY + initVel_Y* time + tempGravityY * time * time;
		if (time != 0) {
			initVel_X = (float)((RealPosX - TempPosX) / time);
			initVel_Y = (float)((RealPosY - TempPosY) / time);
		}
//		Vector2 gravityForce = new Vector2 ((float)tempGravityX, (float)tempGravityY);
//		GetComponent<Rigidbody2D> ().AddForce (gravityForce);
		GetComponent<Rigidbody2D> ().position=(new Vector2((float)RealPosX,(float)RealPosY));

	}

}
