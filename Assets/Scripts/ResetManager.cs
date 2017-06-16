using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour {
	public BallSpawner ballSpawner;
	public GameManager gameManager;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Throwable" && collider.gameObject.name == "Ball(Clone)") {
			ballSpawner.SpawnBall ();
			Destroy (collider.gameObject);
			gameManager.ResetGame ();
		}
	}
}
