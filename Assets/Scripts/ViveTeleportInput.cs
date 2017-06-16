using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveTeleportInput: MonoBehaviour {
	public SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device device;

	private LineRenderer laser;
	public GameObject teleportAimerObject;
	public Vector3 teleportLocation; 
	public GameObject player;
	public LayerMask laserMask;

	private float yNudge = 1f;

	void Start() {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		laser = GetComponentInChildren<LineRenderer> ();
	}

	void Update() {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
		CheckForTeleportation ();
	}

	void CheckForTeleportation() {
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Touchpad)) {
			laser.gameObject.SetActive (true);
			teleportAimerObject.SetActive (true);

			laser.SetPosition (0, gameObject.transform.position);
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, 15, laserMask)) {
				teleportLocation = hit.point;
				laser.SetPosition (1, teleportLocation);
				teleportAimerObject.transform.position = new Vector3 (teleportLocation.x, teleportLocation.y + yNudge, teleportLocation.z);
			} else {
				teleportLocation = new Vector3 (
					transform.forward.x * 15 + transform.position.x,
					transform.forward.y * 15 + transform.position.y,
					transform.forward.z * 15 + transform.position.z);
				RaycastHit groundRay;
				if (Physics.Raycast (teleportLocation, -Vector3.up, out groundRay, 17, laserMask)) {
					teleportLocation = new Vector3 (
						transform.forward.x * 15 + transform.position.x, 
						groundRay.point.y, 
						transform.forward.z * 15 + transform.position.z);
				}
				laser.SetPosition (1, transform.forward * 15 + transform.position);
				teleportAimerObject.transform.position = teleportLocation + new Vector3 (0, yNudge, 0);
			}

		}
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			laser.gameObject.SetActive (false);
			teleportAimerObject.SetActive (false);
		}
		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			laser.gameObject.SetActive (false);
			teleportAimerObject.SetActive (false);
            if (isInRange(teleportLocation.x) && isInRange(teleportLocation.z))
            {
                teleportLocation = new Vector3(teleportLocation.x, player.transform.position.y, teleportLocation.z);
                //	SteamVR_Fade.Start (Color.black, 2f);
                SteamVR_Fade.View(Color.black, 2);
                player.transform.position = teleportLocation;
                SteamVR_Fade.View(Color.clear, 2);
            }
		}
	}

    // This constrains the player's ability to teleport, ensuring that he/she will stay in the play area.
    bool isInRange(float input)
    {
        return (input >= -9 && input <= 9);
    }

}
