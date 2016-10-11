using UnityEngine;
using System.Collections;
using UnityEngine.UI
;
public class TimeSlider : MonoBehaviour {
	public Slider SliderTime;
	public static float TimeSwept;
	// Use this for initialization
	void Start () {
		SliderTime.onValueChanged.AddListener (delegate {ValueChangeCheck();});
	}
	
	// Update is called once per frame
	void Update () {
		TimeSwept = SliderTime.value;
	}

	public void ValueChangeCheck(){
		Debug.Log (SliderTime.value);
		GameObject[] LinesToErase = GameObject.FindGameObjectsWithTag ("LineArea");
		foreach (var line in LinesToErase) {
			Destroy (line);
		}
	} 

}
