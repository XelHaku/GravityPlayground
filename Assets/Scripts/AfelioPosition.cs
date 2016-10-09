using UnityEngine;
using System.Collections;

public class AfelioPosition : MonoBehaviour {
	private bool starCalculus;
	GameObject Perihelion;
	Vector2 initPos;
	Vector2 actualPos;
	// Use this for initialization
	void Start () {
		actualPos = new Vector2 (0, 0);
		Perihelion = GameObject.FindGameObjectWithTag ("Perihelion");
		initPos = Perihelion.GetComponent<Transform> ().position;
		starCalculus = false;
		//StartCoroutine(MoveAfelio());

	}
	
	// Update is called once per frame
	void Update () {
		if (initPos == actualPos) {
			starCalculus = true;
		} else {
			initPos = actualPos;
		}
		if(starCalculus)
		GetComponent<Transform> ().position =PlanetData.Afelio;
	}


//	IEnumerator	MoveAfelio(){
//		//Debug.Log("colider Activation");
//
//		yield return new WaitForSeconds (20.0f);
//			GetComponent<Transform> ().position =PlanetData.Afelio;
//		starCalculus = true;
//	}
}
