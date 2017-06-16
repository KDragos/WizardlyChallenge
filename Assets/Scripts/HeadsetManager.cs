using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class HeadsetManager : MonoBehaviour {

	public GameObject viveRig;
	public GameObject oculusRig;
	public bool hmdChosen;
    public GameObject viveInstructions;
    public GameObject oculusInstructions;

	void Start () {
		if (VRDevice.model.Contains("Vive")) {
            // Activate Vive objects.
			viveRig.SetActive (true);
            viveInstructions.SetActive(true);

            // Deactivate Oculus objects.
			oculusRig.SetActive (false);
            oculusInstructions.SetActive(false);

			hmdChosen = true;
		} else if (VRDevice.model.Contains("Oculus")) {
            // Activate Oculus objects.
            oculusRig.SetActive (true);
            oculusInstructions.SetActive(true);

            // Deactivate Vive objects.
			viveRig.SetActive (false);
            viveInstructions.SetActive(false);

			hmdChosen = true;
		}
	}
	
	void Update () {
        // Covers the case where a headset might get disconnected.
		if (!hmdChosen) {
			if (VRDevice.model == "vive") {
				viveRig.SetActive (true);
                viveInstructions.SetActive(true);
				oculusRig.SetActive (false);
                oculusInstructions.SetActive(false);
                hmdChosen = true;
			} else if (VRDevice.model == "oculus") {
				oculusRig.SetActive (true);
                oculusInstructions.SetActive(true);
                viveRig.SetActive (false);
                viveInstructions.SetActive(false);
                hmdChosen = true;
			}
		}
		if (!VRDevice.isPresent) {
			hmdChosen = false;
		}
	}
}
