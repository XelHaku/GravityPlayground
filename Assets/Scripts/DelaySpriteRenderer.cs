using UnityEngine;
using System.Collections;

public class DelaySpriteRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DeactivateSpriteRenderer ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator	DeactivateSpriteRenderer(){
		//Debug.Log("colider Activation");

		yield return new WaitForSeconds (60.0f);
		GetComponent<SpriteRenderer> ().enabled = false;
	}
}
