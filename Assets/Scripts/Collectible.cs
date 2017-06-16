using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
	private GameManager gameManager;
    private StartingPlatform startingPlatform;

	void Start() {
		gameManager = gameObject.GetComponentInParent<GameManager> ();
        startingPlatform = GameObject.FindObjectOfType<StartingPlatform>();
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.name == "Ball(Clone)" && startingPlatform.isStartPossible) {
			gameManager.CollectCollectible ();
			gameObject.transform.parent.gameObject.SetActive (false);

		}
	}
}
