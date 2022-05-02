using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public int MAX_LEVEL = 6;

    public static GameManager Instance = null;

	public int currentLevel = 0;
	private int m_runningLevelForDisplay = 1;
	private void OnEnable() {
		if (Instance == null) {
			Instance = this;
		}
		DontDestroyOnLoad(this);
	}
	private void OnDisable() {
		if (Instance == this) {
			Instance = null;
		}
	}

	public int GetLevelForDisplay() {
		return m_runningLevelForDisplay;
	}
	private void Start() {
		LoadCurrentScene();
	}
	public void GoToNextLevel() {
		currentLevel++;
		m_runningLevelForDisplay++;
		if (currentLevel >= MAX_LEVEL) {
			currentLevel = 0;
		}
		LoadCurrentScene();
	}
	public void LoadCurrentScene() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlayLevel_" + currentLevel.ToString());
	}
}