using UnityEngine;
using System.Collections;

public class DrawLine2KeplerLaw : MonoBehaviour {
	private GameObject Planet;
	private GameObject Sun;
	private LineRenderer LineKepler;


	// Use this for initialization
	void Start () {
		Planet = GameObject.FindGameObjectWithTag ("CoolPlanet");
		Sun = GameObject.FindGameObjectWithTag ("Sun");
		LineKepler = GetComponent<LineRenderer> ();
		LineKepler.SetPosition (0, Sun.GetComponent<Transform> ().position);
		LineKepler.SetPosition (1, Planet.GetComponent<Transform> ().position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
