using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
	private GameManager gameManager;

	void Start() {
		gameManager = gameObject.GetComponentInParent<GameManager> ();
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.name == "Ball(Clone)" && !coll.attachedRigidbody.isKinematic) {
			gameManager.CollectCollectible ();
			gameObject.transform.parent.gameObject.SetActive (false);

		}
	}
}
