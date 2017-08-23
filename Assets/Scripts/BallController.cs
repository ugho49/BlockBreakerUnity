using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	GameObject paddle;
	Vector3 paddleToBallVector;
	bool hasStarted;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindGameObjectWithTag ("Paddle");
		paddleToBallVector = this.transform.position - paddle.transform.position;
		hasStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				print ("launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
		}
	}
}
