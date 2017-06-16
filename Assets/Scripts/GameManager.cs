using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int numCollectibles;

	void Start () {
		foreach (Transform child in transform) {
			numCollectibles++;
		}
	}

	public void ResetGame() {
		numCollectibles = 0;
		foreach (Transform child in transform) {
			child.gameObject.SetActive (true);
			numCollectibles++;
		}
	}

	public int GetNumberCollectiblesRemaining() {
		return numCollectibles;
	}

	public void CollectCollectible() {
		if (numCollectibles > 0) {
			numCollectibles--;
		}
	}
}
