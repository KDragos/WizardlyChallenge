using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    public string[] levelNames = new string[] {
        "00_Start", "00_Tutorial_01", "00_Tutorial_02",
        "01_Level_01", "01_Level_02", "01_Level_03", "01_Level_04",
        "02_Win" };
	public string methodToCall = "LoadNextLevel";
	public GameManager gameManager;
    public static int currentLevel = 0;
    public StartingPlatform startingPlatform;

	void Start () {
		gameManager = FindObjectOfType<GameManager> ();
        startingPlatform = FindObjectOfType<StartingPlatform>();
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Throwable") {
			if (coll.gameObject.name == "Ball(Clone)" && gameManager.GetNumberCollectiblesRemaining() == 0) {
				Invoke(methodToCall, 0.1f);
			}
		}
	}

	void StartTutorial() {
        currentLevel = 1;
        SteamVR_LoadLevel.Begin (levelNames[currentLevel]);
	}

	void StartTutorial2() {
        currentLevel++;
        SteamVR_LoadLevel.Begin (levelNames[currentLevel]);
	}

    void StartGame() {
        currentLevel = 3;
        SteamVR_LoadLevel.Begin (levelNames[currentLevel]);
	}

	void LoadNextLevel() {
        if(startingPlatform.isStartPossible)
        {
            currentLevel++;
            SteamVR_LoadLevel.Begin (levelNames[currentLevel]);
        }

	}

	void QuitGame() {
		Application.Quit ();
	}
}
