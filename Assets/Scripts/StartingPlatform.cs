using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPlatform : MonoBehaviour {

	public Material startPossible;
	public Material startNotPossible;
	public GameObject startPlatform;
    public bool isStartPossible = true;

	private MeshRenderer platformRenderer;

	void Start () {
		platformRenderer = startPlatform.GetComponent<MeshRenderer> ();
	}
	
	void OnTriggerExit(Collider coll) {
		if(coll.gameObject.tag == "Player") {
			platformRenderer.material = startNotPossible;
            isStartPossible = false;
		}
	}

	void OnTriggerEnter(Collider coll) {
		if(coll.gameObject.tag == "Player") {
			platformRenderer.material = startPossible;
            isStartPossible = true;
		}
	}
}
