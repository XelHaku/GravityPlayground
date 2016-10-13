using UnityEngine;
using System.Collections;

public class DrawPlanetPath : MonoBehaviour {
	public GameObject EllipsePoint;
	public GameObject actualEllipsePoint;
	// Use this for initialization
	void Start () {
		InvokeRepeating("CreateEllipsePopint", 0.0f, 1f);//


	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void CreateEllipsePopint()
	{
		
		actualEllipsePoint =( Instantiate(EllipsePoint,GetComponent<Rigidbody2D>().position,new Quaternion(0,0,0,1.0f)) as Transform).gameObject;
		//EllipsePoint.GetComponent<Rigidbody2D>().position = GetComponent<Rigidbody2D>().position;
	}


//	IEnumerator	DeactivateColliderDelay(){
//		//Debug.Log("colider Activation");
//
//		yield return new WaitForSeconds (2.0f);
//		GetComponent<Collider2D> ().enabled = true;
//		Debug.Log("colider Activation");
//	}
}
