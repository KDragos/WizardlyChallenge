using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
	public GameObject BallPrefab;

	void Start () {
		SpawnBall ();
	}

	public void SpawnBall() {
		Instantiate (BallPrefab, gameObject.transform.position, Quaternion.identity);
	}


}
