using UnityEngine;
using System.Collections;

public class TouchMove : MonoBehaviour {
	public float speed = 0.1F;
	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.touchCount < 2) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime, -touchDeltaPosition.y * speed * Time.deltaTime, 0);
		}
	}
}
