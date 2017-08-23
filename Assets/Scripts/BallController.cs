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
				hasStarted = true;
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (hasStarted) {
			//GetComponent<AudioSource> ().Play ();

			Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
			GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
