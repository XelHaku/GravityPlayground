using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		Debug.Log("Slider Trigger Activated");
		if(col.gameObject.tag == "CoolPlanet")
		{			//gameObject.SetActive(false);
			
			Destroy(gameObject);
			if(PlanetData.BeginCalculus == false){
				PlanetData.BeginCalculus = true;	
			}
		}


	}
}
