using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;



public class BallPivotMechanicsOnTouch : MonoBehaviour {
	//public GameObject[] PivotsTagged;
	//public GameObject   FoodBullet;
	public static string BallState;
	public GameObject GravityGlow;
//	public SpriteRenderer sprenderMagentaGlow;
	//public bool BallClockwiseRotation;
	public float maxSpeed;
	public float hookRadius;
	public float sliderMagnitude;
	GameObject  closestPivot ;
	public float GravityFactor;
	private SpriteRenderer sprenderWhiteGlow;
	private Component SliderJoint;
	private GameObject activeSlider;


	// Use this for initialization
	void Start () {
		//GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 100.0f, 0);
		GetComponent<DistanceJoint2D>().enabled = false;
		BallState = "Free";
		GravityGlow = GameObject.FindGameObjectWithTag("GravityGlow");
		

		var taggedMagentaGlow = GameObject.FindGameObjectsWithTag("WhiteGlow");
		foreach (GameObject objGlow in taggedMagentaGlow) {
			sprenderWhiteGlow = 	objGlow.GetComponentInChildren<SpriteRenderer>();
			sprenderWhiteGlow.enabled = false;
		}

		//BallClockwiseRotation = true;
		 // closestPivot = GetNearestTaggedPivot(); 
		//FOR SLIDER
		SliderJoint = GetComponent<SliderJoint2D>();
		GetComponent<SliderJoint2D>().enabled = false;
		 
	}

	
	// Update is called once per frame
	void Update () {
		if (GravityGlow.GetComponent<SpriteRenderer> ().enabled == true) {
			ApplyGravityGlowForceToBall ();
		}

		if(GetComponent<SliderJoint2D>().enabled== true){
			BallState = "Sliding";
		}


	foreach (Touch touch in Input.touches) {

			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
				
				GameObject RealCamera = GameObject.FindGameObjectWithTag ("MainCamera"); 
			//TouchSquare for PIVOT

			if( touch.phase == TouchPhase.Began && touch.phase == TouchPhase.Stationary ){
				
				closestPivot = GetNearestTaggedPivot();
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);
				if(BallState == "Free" ){
					
					if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved ) {
						

						if (closestPivot.GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {


						} else if(Vector3.Distance(GetComponent<Transform>().position,closestPivot.GetComponent<Transform>().position) <= hookRadius*closestPivot.GetComponent<Transform>().localScale.x){
							BallState = "Hooked";
							sprenderWhiteGlow.enabled = true;
							Debug.Log("Hooked to Pivot");
							GetComponent<DistanceJoint2D>().enabled = true;
							GetComponent<DistanceJoint2D>().connectedAnchor = closestPivot.GetComponent<Transform>().position;
							GetComponent<DistanceJoint2D>().distance = Vector3.Distance(GetComponent<Transform>().position,closestPivot.GetComponent<Transform>().position);
							GetComponent<DistanceJoint2D>().connectedAnchor = closestPivot.GetComponent<Transform>().position;

							Vector2 Force = PropulsionFromHook(closestPivot);
							GetComponent<Rigidbody2D> ().AddForce (Force);
						}

					}
			
				
				
				}else{
					if (closestPivot.GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {
						
					} else {
						GetComponent<DistanceJoint2D> ().enabled = false;
						BallState = "Free";
						sprenderWhiteGlow.enabled = false;
						Debug.Log ("Free");
					}
				}
			}

		

			
		}

		Vector3 hit2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//FOR THE KEYBOARD

		if(Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)){
			if(BallState == "Free" ){
				
				 closestPivot = GetNearestTaggedPivot();
				if(Vector3.Distance(GetComponent<Transform>().position,closestPivot.GetComponent<Transform>().position) <= hookRadius*closestPivot.GetComponent<Transform>().localScale.x){
					BallState = "Hooked";
					sprenderWhiteGlow.enabled = true;
					Debug.Log("Hooked to Pivot");
					GetComponent<DistanceJoint2D>().enabled = true;

					GetComponent<DistanceJoint2D>().connectedAnchor = closestPivot.GetComponent<Transform>().position;
					GetComponent<DistanceJoint2D>().distance = Vector3.Distance(GetComponent<Transform>().position,closestPivot.GetComponent<Transform>().position);
					Vector2 Force = PropulsionFromHook(closestPivot);
					GetComponent<Rigidbody2D> ().AddForce (Force);
				}		
			}else if(BallState == "Hooked" ){
				
				GetComponent<DistanceJoint2D>().enabled = false;
				BallState = "Free";
				sprenderWhiteGlow.enabled = false;
				Debug.Log("Free");
			}else if(BallState == "Sliding" ){
				GetComponent<DistanceJoint2D>().enabled = false;
				//sprenderWhiteGlow.enabled = false;
				Debug.Log("Sliding");
				if (activeSlider.GetComponent<Rigidbody2D> ().rotation == 90.0f) {
					GetComponent<SliderJoint2D>().enabled = false;
					BallState = "Free";
					activeSlider.GetComponent<Collider2D> ().enabled = false;
					StartCoroutine (DeactivateColliderDelay (activeSlider));
					if (hit2.x <= GetComponent<Transform>().position.x ) {
						PropulsionFromSlider ("LEFT"); Debug.Log("Accelerated LEFT  "+"MousePoint  "+hit2.x+"  Object Position"+GetComponent<Transform>().position.x);
					}else if (hit2.x> GetComponent<Transform>().position.x) {
						PropulsionFromSlider ("RIGHT"); Debug.Log("Accelerated RIGHT  "+"MousePoint  "+hit2.x+"  Object Position"+GetComponent<Transform>().position.x);
					}
				}
				if (activeSlider.GetComponent<Rigidbody2D> ().rotation == 0.0f) {
					GetComponent<SliderJoint2D>().enabled = false;
					BallState = "Free";
					activeSlider.GetComponent<Collider2D> ().enabled = false;
					StartCoroutine (DeactivateColliderDelay (activeSlider));
					if (hit2.y <= GetComponent<Transform>().position.y ) {
						PropulsionFromSlider ("DOWN"); Debug.Log("Accelerated DOWN  "+"MousePoint  "+hit2.y+"  Object Position"+GetComponent<Transform>().position.y);
					}else if (hit2.y> GetComponent<Transform>().position.y) {
						PropulsionFromSlider ("UP"); Debug.Log("Accelerated RIGHT  "+"MousePoint  "+hit2.y+"  Object Position"+GetComponent<Transform>().position.y);
					} 
				}
				if (activeSlider.GetComponent<Rigidbody2D> ().rotation == 45.0f) {
					GetComponent<SliderJoint2D>().enabled = false;
					BallState = "Free";
					activeSlider.GetComponent<Collider2D> ().enabled = false;
					StartCoroutine (DeactivateColliderDelay (activeSlider));
					if (hit2.x > GetComponent<Transform>().position.x ) {
						PropulsionFromSlider ("DIAGONAL_DOWN"); Debug.Log("Accelerated DIAGONAL_DOWN  "+"MousePoint  "+hit2.y+"  Object Position"+GetComponent<Transform>().position.y);
					}else if (hit2.x<= GetComponent<Transform>().position.x) {
						PropulsionFromSlider ("DIAGONAL_UP"); Debug.Log("Accelerated DIAGONAL_UP  "+"MousePoint  "+hit2.y+"  Object Position"+GetComponent<Transform>().position.y);
					}
				}
			}
		}
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		GameObject[] activePivot = GameObject.FindGameObjectsWithTag ("Pivot");
		foreach( var pivotHover in activePivot){
			if(hit.collider == pivotHover.GetComponent<Collider2D>())
		{
			//Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			//Vector2 touchPos = new Vector2 (wp.x, wp.y);
				Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);

				GravityGlow.GetComponent<Rigidbody2D>().position = pivotHover.GetComponent<Rigidbody2D>().position;
				GravityGlow.GetComponent<SpriteRenderer> ().enabled = true;
				StartCoroutine (DeactivateGravityGlowDelay());
			
			}
		}
	
		
	
		//SAFE DELETE
//		if (GetComponent<DistanceJoint2D> ().enabled == true) {
//			GetComponent<DistanceJoint2D>().connectedAnchor = closestPivot.GetComponent<Transform>().position;
//		}

	}//END UPDATE
	void FixedUpdate()
	{
		if(GetComponent<Rigidbody2D> ().velocity.magnitude > maxSpeed)
		{
			GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity.normalized * maxSpeed;
		}
	}

	GameObject GetNearestTaggedPivot(){
		var nearestDistanceSqr = Mathf.Infinity;
		var taggedGameObjects = GameObject.FindGameObjectsWithTag("Pivot"); 
		//GameObject nearestObj;
		GameObject closestPivot = null;
		// loop through each tagged object, remembering nearest one found
		foreach (GameObject obj in taggedGameObjects) {
			var objectPos = obj.transform.position;
			var distanceSqr = (objectPos - transform.position).sqrMagnitude;
			if (distanceSqr < nearestDistanceSqr) {
				//nearestObj = obj.transform;
				nearestDistanceSqr = distanceSqr;
				closestPivot = obj;
			}
		}

		return closestPivot;
	}

	void ApplyGravityGlowForceToBall(){
		double tempGravityX = 0;
		double tempGravityY = 0;

		float RvecX, RvecY;
		double Radius;


		//change gravity
		RvecX = GetComponent<Rigidbody2D> ().position.x - GravityGlow.GetComponent<SpriteRenderer> ().bounds.center.x;
		RvecY = GetComponent<Rigidbody2D> ().position.y - GravityGlow.GetComponent<SpriteRenderer> ().bounds.center.y;
		Radius = Math.Pow (RvecX, 2.0f) + Math.Pow (RvecY, 2.0f);
		Radius = Math.Pow (Radius, 0.5f);


		Radius = Math.Pow (Radius, 3f);

		if (Radius > GravityGlow.GetComponent<SpriteRenderer> ().bounds.size.x) {
			tempGravityX -= GravityFactor * GetComponent<SpriteRenderer> ().bounds.size.x * GetComponent<SpriteRenderer> ().bounds.size.x * RvecX / (Radius);
			tempGravityY -= GravityFactor * GetComponent<SpriteRenderer> ().bounds.size.y * GetComponent<SpriteRenderer> ().bounds.size.y * RvecY / (Radius);
		}




		Vector2 gravityForce = new Vector2 ((float)tempGravityX, (float)tempGravityY);
		GetComponent<Rigidbody2D> ().AddForce (gravityForce);

	}
	#region COLLISION

	void OnTriggerEnter2D(Collider2D col) 
	{
		Debug.Log("Slider Trigger Activated");
		if(col.gameObject.tag == "Slider")
		{			//col.gameObject.SetActive(false);
			sprenderWhiteGlow.enabled = false;
			activeSlider = col.gameObject;
			Debug.Log("Slider Activated");
			GetComponent<SliderJoint2D>().enabled = true;

			//GetComponent<SliderJoint2D> ().connectedBody = col.GetComponent<Rigidbody2D> ();
			//GetComponent<SliderJoint2D> ().anchor = col.GetComponent<Rigidbody2D> ().position;
			GetComponent<SliderJoint2D> ().connectedAnchor = col.GetComponent<Rigidbody2D> ().position;


			JointTranslationLimits2D limits = GetComponent<SliderJoint2D>().limits;
			//limits.min = -col.GetComponent<SpriteRenderer>().bounds.extents.x;
			//limits.max = col.GetComponent<SpriteRenderer>().bounds.extents.x;
			float Ex=0.0f,Ey=0.0f;
			float angleRot = col.GetComponent<Rigidbody2D> ().rotation;
			Ex = col.GetComponent<SpriteRenderer> ().bounds.extents.x;
			Ey = col.GetComponent<SpriteRenderer> ().bounds.extents.y;

			//
			//			limits.max = (Mathf.Cos (angleRot) * Ex - Mathf.Sin (angleRot) * Ey) / (Mathf.Cos (angleRot) * Mathf.Cos (angleRot) - Mathf.Cos (angleRot) * Mathf.Sin (angleRot));
			//				limits.min =-limits.max; 
			//				GetComponent<SliderJoint2D> ().limits = limits;  
			if (angleRot == 90.0f) {
				limits.max = Ey;
				limits.min = -limits.max;
			} else if (angleRot == 0.0f) {
				limits.max = Ex;
				limits.min = -limits.max;

			}
			else if (angleRot == 45.0f) {
				limits.max = Mathf.Sqrt(Ex*Ex+Ey*Ey);
				limits.min =-limits.max; 

			}
			GetComponent<SliderJoint2D> ().limits = limits; 

			GetComponent<SliderJoint2D> ().angle = col.GetComponent<Rigidbody2D> ().rotation;
			Debug.Log("Rotation =" + col.GetComponent<Rigidbody2D> ().rotation+ "Angle = " +angleRot + "Limits  =" + limits.max);
		}


	}
	#endregion

	Vector2 PropulsionFromHook(GameObject closestPivot){
		var ballVec = new Vector3 ();
		var pivotVec = new Vector3 ();
		ballVec = GetComponent<Transform> ().position;
		pivotVec = closestPivot.transform.position;
		
		GameObject RealCamera = GameObject.FindGameObjectWithTag ("MainCamera"); 
		var BminusP = ballVec - pivotVec;

				var getSing = new Vector3 ();
				getSing = Vector3.Cross (new Vector3 (GetComponent<Rigidbody2D> ().velocity.x, GetComponent<Rigidbody2D> ().velocity.y, 0), BminusP);
				int Sing = -1;
				if (getSing.z <= 0) {
					Sing = 1;
					Debug.Log("Sing = -1");
				}
				
		var velocityDireccion = Sing *50.0f * closestPivot.transform.localScale.x * Vector3.Normalize (Vector3.Cross ( new Vector3 (0, 0, 1),BminusP));
				return new Vector2 (velocityDireccion.x, velocityDireccion.y);
			
	}

	void PropulsionFromSlider(String ForceDirection){

		var appliedForce = new Vector2 (-sliderMagnitude, 0.0f);
		if (ForceDirection == "LEFT") {
			 appliedForce = new Vector2 (-sliderMagnitude, 0.0f);

		} else if (ForceDirection == "RIGHT") {
			appliedForce = new Vector2 (sliderMagnitude, 0.0f);

		}else if (ForceDirection == "UP") {
			appliedForce = new Vector2 (0.0f,sliderMagnitude);

		}else if (ForceDirection == "DOWN") {
			appliedForce = new Vector2 (0.0f,-sliderMagnitude);

		}else if (ForceDirection == "DIAGONAL_UP") {
			appliedForce = new Vector2 (-sliderMagnitude*0.707f,sliderMagnitude*0.707f);

		}else if (ForceDirection == "DIAGONAL_DOWN") {
			appliedForce = new Vector2 (sliderMagnitude*0.707f,-sliderMagnitude*0.707f);

		}
		GetComponent<Rigidbody2D> ().AddForce (appliedForce);
		//return new Vector2 (appliedForce.x, appliedForce.y);
	}

	IEnumerator	DeactivateColliderDelay(GameObject objectColliderDelayed){
		Debug.Log("Slider colider deacti");

		yield return new WaitForSeconds (0.50f);
		objectColliderDelayed.GetComponent<Collider2D> ().enabled = true;
	}

	IEnumerator	DeactivateGravityGlowDelay(){
		Debug.Log("Gravity glow deactivation");

		yield return new WaitForSeconds (3.0f);
		GravityGlow.GetComponent<SpriteRenderer> ().enabled = false;
	}

}
