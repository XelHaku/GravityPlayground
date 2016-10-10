using UnityEngine;
using System.Collections;

public class DeactiveCollider : MonoBehaviour {

	void Start () {
		StartCoroutine (DeactivateColliderDelay ());
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D col) 
	{
		Debug.Log("DeactivatePerihelion");
		if(col.gameObject.tag == "CoolPlanet")
		{			//gameObject.SetActive(false);
			StartCoroutine (DeactivateColliderDelay ());

		}


	}

	IEnumerator	DeactivateColliderDelay(){
		//Debug.Log("colider Activation");

		yield return new WaitForSeconds (5.0f);
		GetComponent<Collider2D> ().enabled = true;
		Debug.Log("colider Activation");
	}
}
