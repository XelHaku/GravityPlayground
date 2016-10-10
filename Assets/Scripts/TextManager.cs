﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	Text text;
	//float PeriodTime=0;
	//float ForceCalculus=0;
	// Use this for initialization
	void Awake () {
		//GameObject HUDcanvas = GameObject.FindGameObjectWithTag ("HUDCanvas"); 
		//anim =HUDcanvas.GetComponent <Animator> (); 
		text = GetComponent<Text> ();
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		text.text = "Period T = : " +10* (int)PlanetData.PlanetPeriod + " days"+
			"\nForce = " + 1000*(int)Gravity.ForceMeasurement + " N" +
			"\nAphelion Distance = " + (int)PlanetData.Afelio.magnitude + " 10^3km"+
			"\nPerihelion Distance = " + (int)PlanetData.Perihelio.magnitude + " 10^3km";


	}
}
