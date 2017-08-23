using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	public bool autoplay = false;

	GameObject ball;
	float minPosX = 0.5f;
	float maxPosX = 15.5f;

	void Start() {
		ball = GameObject.FindGameObjectWithTag ("Ball");
	}

	void Update () {
		
		if (autoplay) {
			Autoplay ();
			return;
		}

		MoveWithMouse ();
	}

	void MoveWithMouse() {
		Vector3 paddlePosition = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
		float mousePositionX = Input.mousePosition.x / Screen.width * 16;

		paddlePosition.x = Mathf.Clamp (mousePositionX, minPosX, maxPosX);
		transform.position = paddlePosition;
	}

	void Autoplay() {
		Vector3 paddlePosition = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
		Vector3 ballPostion = ball.transform.position;

		paddlePosition.x = Mathf.Clamp (ballPostion.x, minPosX, maxPosX);
		transform.position = paddlePosition;
	}
}
