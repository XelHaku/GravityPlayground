using UnityEngine;
using System.Collections;

public class DelayCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DeactivateColliderDelay ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator	DeactivateColliderDelay(){
		//Debug.Log("colider Activation");

		yield return new WaitForSeconds (2.0f);
		GetComponent<Collider2D> ().enabled = true;
		Debug.Log("colider Activation");
	}
}
