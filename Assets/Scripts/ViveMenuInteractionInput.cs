using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveMenuInteractionInput : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device device;

	public float swipeSum;
	public float touchLast;
	public float touchCurrent;
	public float distance;
	public bool hasSwipedLeft;
	public bool hasSwipedRight;

	public ObjectMenuManager objectMenuManager;

	void Start() {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	void Update() {
		device = SteamVR_Controller.Input ((int)trackedObj.index);

		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Touchpad)) {
			touchLast = device.GetAxis (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
			ShowMenu ();
		}

		if (device.GetTouch (SteamVR_Controller.ButtonMask.Touchpad)) {
			touchCurrent = device.GetAxis (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
			distance = touchCurrent - touchLast;
			touchLast = touchCurrent;
			swipeSum += distance;
			if (!hasSwipedRight) {
				if (swipeSum > 0.5f) {
					swipeSum = 0;
					SwipeRight ();
					hasSwipedRight = true;
					hasSwipedLeft = false;
				}
			}
			if (!hasSwipedLeft) {
				if (swipeSum < -0.5f) {
					swipeSum = 0;
					SwipeLeft ();
					hasSwipedLeft = true;
					hasSwipedRight = false;
				}
			}
		}
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			swipeSum = 0;
			touchCurrent = 0;
			touchLast = 0;
			hasSwipedLeft = false;
			hasSwipedRight = false;
			HideMenu ();
		}
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad)) {
			SpawnObject ();
		}
			
	}

	void ShowMenu() {
		objectMenuManager.ShowMenu ();
	}

	void HideMenu() {
		objectMenuManager.HideMenu ();
	}

	void SwipeLeft() {
		objectMenuManager.MenuLeft ();
	}

	void SwipeRight() {
		objectMenuManager.MenuRight ();
	}

	void SpawnObject() {
		objectMenuManager.SpawnCurrentObject ();
	}
	
}
