using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	LevelManager levelManager;

	void Start() {
		levelManager = new LevelManager ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("You lose");
		levelManager.LoadLevel ("Lose");
	}

}
