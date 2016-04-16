using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerDraw : MonoBehaviour {

	public bool OnDraw = true;
	public GameObject trail;
	public int currentPoint = 0;

	Vector3 GetTouchPosition(Touch touch) {
		Vector2 screenPosition = touch.position;
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 4));
		return worldPosition;
	}

	void Update() {
		if (Input.touchCount > 0) {
			var touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began) {
				currentPoint = 0;
			}
			else if (touch.phase == TouchPhase.Moved) {
				Vector3 Pos = GetTouchPosition(touch);
				trail.transform.position = Pos;
			}
			else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {

			}
		}
		else {

			if (Input.GetMouseButtonDown(0)) {
				currentPoint = 0;
			}
			else if (Input.GetMouseButton(0)) {
				Vector2 screenPosition = Input.mousePosition;
				Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 4));
				trail.transform.position = worldPosition;
			}
			else if (Input.GetMouseButtonUp(0)) {
			}
		}
	}



}
