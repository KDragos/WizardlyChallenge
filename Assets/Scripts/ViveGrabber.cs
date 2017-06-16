using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveGrabber : MonoBehaviour {
	
	public SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device device;
	public float throwForce = 1.5f;

	void Start() {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	void Update() {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
	}

	void OnTriggerStay(Collider col) {
		if (col.gameObject.CompareTag ("Throwable")) {
			if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger)) {
				ThrowObject (col);
			} else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
				GrabObject(col);
			} else {

			}
		}
	}

	void ThrowObject(Collider col) {
		col.transform.SetParent (null);
		Rigidbody rigidbody = col.GetComponent<Rigidbody> ();
		if (col.name == "Ball(Clone)") {
			rigidbody.isKinematic = false;
		}
		rigidbody.velocity = device.velocity * throwForce;
		rigidbody.angularVelocity = device.angularVelocity;
	}

	void GrabObject(Collider col) {
		col.transform.SetParent (gameObject.transform);
		col.GetComponent<Rigidbody> ().isKinematic = true;
		device.TriggerHapticPulse (2000);
	}
}
