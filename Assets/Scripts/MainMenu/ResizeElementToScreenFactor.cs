using UnityEngine;
using System.Collections;

public class ResizeElementToScreenFactor : MonoBehaviour {
	public SpriteRenderer spriteRenderer;
	float unitWidth ;
	float unitHeight ;
	float height ;
	float width ;// basically height * screen aspect ratio
	public float ScreenFactor;

	// Use this for initialization
	void Start () {
		 height = Camera.main.orthographicSize * 2;
		 width = height * Screen.width/ Screen.height; // basically height * screen aspect ratio

		Sprite s = spriteRenderer.sprite;
		unitWidth = s.textureRect.width / s.pixelsPerUnit;
		 unitHeight = s.textureRect.width / s.pixelsPerUnit;
		//float unitHeight = s.textureRect.height / s.pixelsPerUnit;

		//spriteRenderer.transform.localScale = new Vector3(width / unitWidth, height / unitHeight);
	}
	
	// Update is called once per frame
	void Update () {
		height = Camera.main.orthographicSize * 2;
		width = height * Screen.width/ Screen.height;
		spriteRenderer.transform.localScale = new Vector3(ScreenFactor*width / unitWidth, ScreenFactor*width / unitWidth);
	}
}
