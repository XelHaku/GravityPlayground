using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SunCrashGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		Debug.Log("SUN CRASH");
		if(col.gameObject.tag == "CoolPlanet" )
		{			//gameObject.SetActive(false);
			GameObject Sun = GameObject.FindGameObjectWithTag("Sun");
			Destroy (col);Destroy (Sun);
			PlanetData.BeginCalculus = false;

			//SceneManager.LoadScene ("MainMenu",LoadSceneMode.Single);
			GameObject Dog = GameObject.FindGameObjectWithTag("DogGameOver");
			Dog.GetComponent<Canvas> ().enabled = true;
		}


	}
}
