using UnityEngine;
using System.Collections;

public class PlanetData : MonoBehaviour
{
	public static Vector2 Afelio;
	public static Vector2 Perihelio;
	public static float PlanetPeriod;
	private float TempPlanetPeriod;

	private Vector2 PlanetPosition;

	public static bool BeginCalculus;
	float framerModule=1;

	GameObject Perihelion;
	Vector2 initPos;
	Vector2 actualPos;



	public class SemiMajor{
		public float SemiMajorCalc(){
			float semimajoraxis = (Afelio.magnitude + Perihelio.magnitude) / 2.0f;
			return semimajoraxis;
		}
	}
	// Use this for initialization
	void Start () {
		PlanetPeriod = 0;
		TempPlanetPeriod = 0;
		Afelio = new Vector2 (0, 0);
		Perihelio = new Vector2 (1000000000000000,1000000000000000);
		BeginCalculus = false;

		actualPos = new Vector2 (0, 0);
		Perihelion = GameObject.FindGameObjectWithTag ("Perihelion");
		initPos = new Vector2 (1, 1);
		PlanetPosition = GetComponent<Rigidbody2D> ().position;

	}
	
	// Update is called once per frame
	void Update () {
		framerModule++;
		if (initPos.x == actualPos.x && initPos.y == actualPos.y && framerModule%60 == 0) {
			BeginCalculus = true;
			framerModule=1;
		} else if(framerModule%60 == 0) {
			initPos = actualPos;

			Debug.Log("init pos  "+ initPos + "  actualPos " +actualPos );

		}
		actualPos = Perihelion.GetComponent<Transform> ().position;
		if (BeginCalculus) {
			PlanetPosition = GetComponent<Rigidbody2D> ().position;

			CheckAfelio ();
			CheckPerihelio ();
//			Debug.Log("Calculating APhelion and Phelion");
		}
		TempPlanetPeriod = TempPlanetPeriod + Time.deltaTime;
	}

	void CheckAfelio(){
		if (PlanetPosition.magnitude >Afelio.magnitude) {
			Afelio = PlanetPosition;
		}
	}
	void CheckPerihelio(){
		if (PlanetPosition.magnitude < Perihelio.magnitude) {
			Perihelio = PlanetPosition;
		}
	}


	void OnTriggerEnter2D(Collider2D col) 
	{
		Debug.Log("PeriHelion Reached");
		if(col.gameObject.tag == "Perihelion" && Time.timeSinceLevelLoad > 10.0f)
		{			//gameObject.SetActive(false);
			PlanetPeriod = TempPlanetPeriod;
			TempPlanetPeriod = 0;
			col.GetComponent<Collider2D> ().enabled = false;
			StartCoroutine (DeactivateColliderDelay ());

		}


	}

	IEnumerator	DeactivateColliderDelay(){
		//Debug.Log("colider Activation");

		yield return new WaitForSeconds (5.0f);
		//GetComponent<Collider2D> ().enabled = true;
		GameObject PeriHelion = GameObject.FindGameObjectWithTag("Perihelion");
		PeriHelion.GetComponent<Collider2D> ().enabled = true;
		Debug.Log("colider Activation");
	}
}
