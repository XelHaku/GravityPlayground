using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour {
	
	
	// Update is called once per frame
	public void ChangeToScene (int sceneToChangeTo) {

		SceneManager.LoadScene ("GravityPlayGroundMain");
		GameObject MainMenu = GameObject.FindGameObjectWithTag ("MainMenu");
		MainMenu.GetComponent<Canvas> ().enabled = false;



	}
}
