using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusTeleportInput: MonoBehaviour {

	private LineRenderer laser;
	public GameObject teleportAimerObject;
	public Vector3 teleportLocation; 
	public GameObject player;
	public LayerMask laserMask;
	private float yNudge = 1f;

    // Dash
    public ParticleSystem dashEffect;
    public float dashSpeed = 0.1f;
    private bool isDashing;
    private float lerpTime;
    private Vector3 dashStartPosition;

	void Start() {
		laser = GetComponentInChildren<LineRenderer> ();
	}

	void Update() {
        CheckForTeleportation ();
	}

	void CheckForTeleportation() {
        if (isDashing)
        {
            lerpTime += Time.deltaTime * dashSpeed;
            player.transform.position = Vector3.Lerp(dashStartPosition, teleportLocation, lerpTime);
            if (lerpTime >= 1)
            {
                dashEffect.Stop();
                isDashing = false;
                lerpTime = 0;
            }
        } else
        {
            if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
            {
                laser.gameObject.SetActive(true);
                if (!teleportAimerObject.activeInHierarchy)
                {
                    teleportAimerObject.SetActive(true);
                }

                laser.SetPosition(0, gameObject.transform.position);
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask))
                {
                    teleportLocation = hit.point;
                    laser.SetPosition(1, teleportLocation);
                    teleportAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y + yNudge, teleportLocation.z);
                }
                else
                {
                    teleportLocation = new Vector3(
                        transform.forward.x * 15 + transform.position.x,
                        transform.forward.y * 15 + transform.position.y,
                        transform.forward.z * 15 + transform.position.z);
                    RaycastHit groundRay;
                    if (Physics.Raycast(teleportLocation, Vector3.down, out groundRay, 17, laserMask))
                    {
                        teleportLocation = new Vector3(
                            transform.forward.x * 15 + transform.position.x,
                            groundRay.point.y,
                            transform.forward.z * 15 + transform.position.z);
                    }
                    laser.SetPosition(1, transform.forward * 15 + transform.position);
                    teleportAimerObject.transform.position = teleportLocation + new Vector3(0, yNudge, 0);
                }

            }
            if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            {
                laser.gameObject.SetActive(false);
                teleportAimerObject.SetActive(false);
                if (isInRange(teleportLocation.x) && isInRange(teleportLocation.z))
                {
                    teleportLocation = new Vector3(teleportLocation.x, player.transform.position.y, teleportLocation.z);
                    dashStartPosition = player.transform.position;
                    isDashing = true;
                    dashEffect.Play();
                }
                laser.gameObject.SetActive(false);
                teleportAimerObject.SetActive(false);
            }
        }
      
	}

    // This constrains the player's ability to teleport, ensuring that he/she will stay in the play area.
    bool isInRange(float input)
    {
        return (input >= -9 && input <= 9);
    }

}
