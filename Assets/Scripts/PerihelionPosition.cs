using UnityEngine;
using System.Collections;

public class PerihelionPosition : MonoBehaviour{

	// Use this for initialization
	void Start () {
		//StartCoroutine_Auto (MovePerihelio());
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Transform> ().position =PlanetData.Perihelio;
	}


//	IEnumerator	MovePerihelio(){
//		//Debug.Log("colider Activation");
//
//		yield return new WaitForSeconds (5.0f);
//		
//	}
}
