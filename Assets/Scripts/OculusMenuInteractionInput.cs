using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusMenuInteractionInput : MonoBehaviour {

	public float swipeSum;
	public float touchLast;
	public float touchCurrent;
	public float distance;
	public bool hasSwipedLeft;
	public bool hasSwipedRight;

	public ObjectMenuManager objectMenuManager;
	public OVRInput.Controller thisController;

	private bool menuIsSwipable;
	private float menuStickX;

	void Update() {
		if(OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)) {
			ShowMenu();
			ListenForSwipes();
			if (OVRInput.GetDown (OVRInput.Button.PrimaryIndexTrigger, thisController)) {
				SpawnObject ();
			}
		}

		if (OVRInput.GetUp (OVRInput.Touch.PrimaryThumbstick)) {
			HideMenu ();
		}
	}

	void ListenForSwipes() {
		menuStickX = OVRInput.Get (OVRInput.Axis2D.PrimaryThumbstick, thisController).x;
		if (menuStickX < 0.45f && menuStickX > -0.45f) {
			menuIsSwipable = true;
		}
		if (menuIsSwipable) {
			if (menuStickX >= 0.45f) {
				SwipeRight ();
				menuIsSwipable = false;
			} else if (menuStickX <= -0.45f) {
				SwipeLeft ();
				menuIsSwipable = false;
			}
		}
		if (OVRInput.GetDown (OVRInput.Button.PrimaryIndexTrigger, thisController)) {
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
