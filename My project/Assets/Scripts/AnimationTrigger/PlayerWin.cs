using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour {

	public static bool IsWon;
	public GameObject endingScene;
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
	}
}
