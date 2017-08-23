using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount = 0;

	int maxHits = 1;
	int timesHit = 0;
	bool isBreakable;
	LevelManager levelManager;

	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		maxHits = hitSprites.Length + 1;
		isBreakable = (this.tag == "Breakable");

		if (isBreakable) {
			breakableCount++;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (!isBreakable) {
			return;
		}

		//AudioSource.PlayClipAtPoint (crack, transform.position);

		if (++timesHit >= maxHits) {
			DestroyObject ();
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
			DestroyObject();
		}
	}

	void DestroyObject() {
		breakableCount--;
		GameObject.Destroy (gameObject);

		if (breakableCount <= 0) {
			breakableCount = 0;
			levelManager.LoadNextLevel ();
		}
	}
}
