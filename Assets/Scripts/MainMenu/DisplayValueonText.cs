using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayValueonText : MonoBehaviour {
	public Slider ValueSlider;
	public static float Value;
	// Use this for initialization
	Text textValue;
	void Start () {
		textValue = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		Value = ValueSlider.value;
		if (GetComponent<Text> ().name == "VelocityText") {
			textValue.text = "Velocity\n" + Value;
		}else if (GetComponent<Text> ().name == "AngleText") {
			textValue.text = "Angle\n" + Value+ " deg";
		}else if(GetComponent<Text> ().name == "SunDistanceText") {
			textValue.text = "Sun Distance\n" + Value+ " ";
		}
			
	
	
	}
}
