using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
public class RestartButton : MonoBehaviour {

	public void ChangeToScene (int sceneToChangeTo) {
		//GameObject MainMenu = GameObject.FindGameObjectWithTag ("MainMenu");
		//MainMenu.GetComponent<Canvas> ().enabled = true;
		SceneManager.LoadScene ("MainMenu",LoadSceneMode.Single);




	}
}
