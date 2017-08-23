using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	public Sprite[] hitSprites;

	int maxHits = 1;
	int timesHit = 0;

	void Start() {
		maxHits = hitSprites.Length + 1;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("collision ball / brick");

		if (++timesHit >= maxHits) {
			GameObject.Destroy (gameObject);
			return;
		}

		LoadSprites ();
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;

		if (hitSprites [spriteIndex]) {
			GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			// If sprite is missing, destroy the object
			GameObject.Destroy (gameObject);
		}
	}
}
