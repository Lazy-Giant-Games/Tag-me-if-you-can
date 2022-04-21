using System.Collections;
using System;
using UnityEngine;

public class PlayerWin : MonoBehaviour {

	public static Action forcedFailScreen;
	public static bool IsWon;
	public GameObject endingScene;

	public FailSceneAnimator failSceneAnimator;
	private void OnEnable() {
		EnemyProgressBar.OnCaptured += OnPlayerWin;
		CommandControlledBot.onRunnerDone += OnPlayerLose;
	}

	private void OnDisable() {
		EnemyProgressBar.OnCaptured -= OnPlayerWin;
		CommandControlledBot.onRunnerDone -= OnPlayerLose;
	}
	public void OnPlayerWin() {
		PlayerController pc = GetComponent<PlayerController>();
		pc.animator.PlayRun();
		pc.walkSpeed = 0f;
		pc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		pc.enabled = false;
		IsWon = true;
		pc.GetComponent<CameraController>().enabled = false;
		endingScene.SetActive(true);
		Camera.main.enabled = false;
	}

	public void OnPlayerLose() {
		PlayerController pc = GetComponent<PlayerController>();
		pc.animator.PlayRun();
		pc.walkSpeed = 0f;
		pc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		pc.enabled = false;
		IsWon = true;
		pc.GetComponent<CameraController>().enabled = false;
		failSceneAnimator.FailSceneTrigger();
		Camera.main.enabled = false;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.G) && !IsWon) {
			OnPlayerLose();
			forcedFailScreen?.Invoke();
		}
	}
}
