using UnityEngine;
using System.Collections;

public class InstatiateLine : MonoBehaviour {
	public GameObject LinePrefab;
	private  GameObject actualLine;
	public float SweptTime;
	public float VoidTime;
	public float FixedSweptTime;
	public float FixedVoidTime;
	Color RandomColor;
	// Use this for initialization
	void Start () {
		FixedSweptTime = TimeSlider.TimeSwept;
		FixedVoidTime = TimeSlider.TimeSwept;
		SweptTime = 0;
		VoidTime = 0;
		RandomColor = new Color (Random.value, Random.value, Random.value, 1.0f);
		//InvokeRepeating("CreateLine", 2.0f, 0.01f);//
	}
	
	// Update is called once per frame
	void Update () {
		FixedSweptTime = TimeSlider.TimeSwept;
		FixedVoidTime = TimeSlider.TimeSwept;
		//Debug.log("TimeSwept " + )
		if (SweptTime == 0) {
			RandomColor = new Color (Random.value, Random.value, Random.value, 1.0f);
			InvokeRepeating("CreateLine", 0.0f, 0.01f);
		}
		SweptTime = SweptTime + Time.deltaTime;
		if(SweptTime > FixedSweptTime){{
				CancelInvoke ("CreateLine");
				VoidTime = VoidTime + Time.deltaTime;	
			}
			if (VoidTime > FixedVoidTime) {
				SweptTime = 0;
				VoidTime = 0;
			}
		}


	}

//	void Update () {
//		//Debug.log("TimeSwept " + )
//		if (SweptTime == FixedSweptTime) {
//			RandomColor = new Color (Random.value, Random.value, Random.value, 1.0f);
//			InvokeRepeating("CreateLine", 2.0f, 0.01f);
//		}
//		SweptTime = SweptTime - Time.deltaTime;
//		if(SweptTime < 0){{
//				CancelInvoke ("CreateLine");
//				VoidTime = VoidTime - Time.deltaTime;	
//			}
//			if (VoidTime < 0) {
//				SweptTime = FixedSweptTime;
//				VoidTime = FixedVoidTime;
//			}
//		}
//
//		FixedSweptTime = TimeSlider.TimeSwept;
//		FixedVoidTime = TimeSlider.TimeSwept;
//	}

	void CreateLine()
	{
		//actualLine.GetComponent<LineRenderer> ().SetColors (RandomColor,RandomColor);
		actualLine =( Instantiate(LinePrefab,GetComponent<Rigidbody2D>().position,new Quaternion(0,0,0,1.0f)) as Transform).gameObject;
		actualLine.GetComponent<LineRenderer> ().SetColors (RandomColor,RandomColor);

		//EllipsePoint.GeComponent<Rigidbody2D>().position = GetComponent<Rigidbody2D>().position;
	}
}
