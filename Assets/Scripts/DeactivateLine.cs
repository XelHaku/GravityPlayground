using UnityEngine;
using System.Collections;

public class DeactivateLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DeactivateSpriteRenderer ());
	}

	// Update is called once per frame
	void Update () {

	}
	IEnumerator	DeactivateSpriteRenderer(){
		//Debug.Log("colider Activation");

		yield return new WaitForSeconds (4.0f*TimeSlider.TimeSwept-0.2f*TimeSlider.TimeSwept);
		GetComponent<LineRenderer> ().enabled = false;
	}
}
