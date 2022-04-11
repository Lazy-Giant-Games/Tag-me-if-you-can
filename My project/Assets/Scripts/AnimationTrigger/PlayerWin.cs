using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour {
	private void OnEnable() {
		EnemyProgressBar.OnCaptured += OnPlayerWin;
	}

	private void OnDisable() {
		EnemyProgressBar.OnCaptured -= OnPlayerWin;
	}
	public void OnPlayerWin() {
		PlayerController pc = GetComponent<PlayerController>();
		pc.walkSpeed = 0f;
		pc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		pc.animator.PlayEndAnimation(); 
		pc.enabled = false;
	}
}
