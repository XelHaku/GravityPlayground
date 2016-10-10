using UnityEngine;
using System.Collections;
using UnityEngine.UI
;


public class SliderValues : MonoBehaviour {
	public Slider SliderVelocity, SliderAngle, SliderDistance;
	public static float Velocity, Angle, Distance;
	// Use this for initialization
	void Awake() {
		//DontDestroyOnLoad(transform.gameObject);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Velocity = SliderVelocity.value;
		Angle = SliderAngle.value;
		Distance = SliderDistance.value;
	}
}
