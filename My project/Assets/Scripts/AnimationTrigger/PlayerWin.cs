using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour {

	public static bool IsWon;
	public GameObject endingScene;
	private void OnEnable() {
		EnemyProgressBar.OnCaptured += OnPlayerWin;
	}

	private void OnDisable() {
		EnemyProgressBar.OnCaptured -= OnPlayerWin;
	}
	public void OnPlayerWin() {
		
		
		PlayerController pc = GetComponent<PlayerController>();
		pc.animator.PlayRun();
		pc.walkSpeed = 0f;
		//pc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		pc.GetComponent<Rigidbody>().useGravity = true;
		pc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		pc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		pc.animator.PlayEndCatch(); 
		pc.enabled = false;
		IsWon = true;
		pc.GetComponent<CameraController>().enabled = false;
		endingScene.SetActive(true);
		Camera.main.enabled = false;
		//StartCoroutine(FocusCamera());

	}

	IEnumerator FocusCamera() {
		AIMovement am = GameObject.FindObjectOfType<AIMovement>();
		Transform eyes = am.transform.GetChild(1).GetChild(0).Find("Eyes");
		Camera.main.transform.parent = null;
		Vector3 pos = Vector3.zero;
		float timer = 0f;
		while (timer < 5f) {
			timer += Time.deltaTime;
			Camera.main.transform.LookAt(am.transform);
			yield return 0;
		}
	}
}
