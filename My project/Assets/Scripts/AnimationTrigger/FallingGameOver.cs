using System.Collections;
using System;
using UnityEngine;

public class FallingGameOver : MonoBehaviour {
	
	private static bool isDead;
	public static Action OnFalling;
	private float m_floatingTimer = 0f;
	private PlayerAnimator m_animator;
	private RaycastHit hit;

	private void Awake() {
		m_animator = GetComponent<PlayerAnimator>();
	}
	private void Update() {
		return;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
			Debug.DrawLine(transform.position, hit.point, Color.cyan);
			m_floatingTimer = 0f;
		} else {
			//m_animator.PlayFalling();
			if (!isDead) {
				m_floatingTimer += Time.deltaTime;
				if (m_floatingTimer >= 2f) {
					Camera.main.transform.parent = null;
					Camera.main.transform.LookAt(m_animator.transform);
					OnFalling?.Invoke();
				}
			}
		}
	}
}
