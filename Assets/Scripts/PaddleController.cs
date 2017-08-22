using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	float minPosX = 0.5f;
	float maxPosX = 15.5f;
	
	// Update is called once per frame
	void Update () {
		float mousePositionX = Input.mousePosition.x / Screen.width * 16;

		Vector3 paddlePosition = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
		paddlePosition.x = Mathf.Clamp (mousePositionX, minPosX, maxPosX);

		transform.position = paddlePosition;
	}
}
