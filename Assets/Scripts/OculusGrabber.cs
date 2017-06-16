using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusGrabber : MonoBehaviour {
	
	public float throwForce = 1.5f;

	private OVRInput.Controller thisController;
	public bool leftHand;

	void Start() {
		if (leftHand) {
			thisController = OVRInput.Controller.LTouch;
		} else {
			thisController = OVRInput.Controller.RTouch;
		}

	}

	void OnTriggerStay(Collider col) {
		if (col.gameObject.CompareTag ("Throwable")) {
			if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,
				thisController) < 0.1f) {
				ThrowObject (col);
			} else if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,
				thisController) > 0.1f) {
				GrabObject(col);
			} else {

			}
		}
	}

	void ThrowObject(Collider col) {
		col.transform.SetParent (null);
		Rigidbody rigidbody = col.GetComponent<Rigidbody> ();
        if(col.name == "Ball(Clone)")
        {
		    rigidbody.isKinematic = false;
        }

		rigidbody.velocity = OVRInput.GetLocalControllerVelocity (thisController) * throwForce;
		rigidbody.angularVelocity = OVRInput.GetLocalControllerAngularVelocity (thisController);
	}

	void GrabObject(Collider col) {
		col.transform.SetParent (gameObject.transform);
		col.GetComponent<Rigidbody> ().isKinematic = true;
	}
}
