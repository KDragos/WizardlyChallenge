using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {

	private ParticleSystem[] childParticleSystems;

    void Start()
    {
        childParticleSystems = gameObject.GetComponentsInChildren<ParticleSystem>();
    }

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.name == "Ball(Clone)") {
			foreach (ParticleSystem particleSystem in childParticleSystems) {
				if (particleSystem.isStopped) {
					particleSystem.Play ();
				}
			}
		}
	}
}
