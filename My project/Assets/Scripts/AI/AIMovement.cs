using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class AIMovement : MonoBehaviour {

	public bool IsGameDone { set; get; }

	public float moveSpeed = 60;

	[SerializeField]
	private Transform m_model;
	public Transform Model => m_model;
	public bool IsHeld { set; get; }

	public Rigidbody MyRigidBody { set; get; }
	public NavMeshAgent MyNavMeshAgent { set; get; }
	public Collider MyCollider { set; get; }

	public PlayerAnimator animator;
	public bool IsGrounded { set; get; }
	public bool IsCaptured { set; get; }

	private float m_initialSpeed;
	private void Awake() {
		MyRigidBody = GetComponent<Rigidbody>();
		MyNavMeshAgent = GetComponent<NavMeshAgent>();
		MyCollider = GetComponent<Collider>();
	}

	public void SetCaptured() {
		moveSpeed = 0f;
		animator.PlayEndAnimationAI();
		IsCaptured = true;
	}
	private void Start() {
		m_initialSpeed = moveSpeed;
		IsGrounded = true;
	}
	public void DisablePortalMovement() {
		MyNavMeshAgent.enabled = false;
		MyNavMeshAgent.isStopped = true;
		MyRigidBody.useGravity = false;
		//MyCollider.isTrigger = true;
		GetComponent<CommandControlledBot>().ClearAllCommand();
		GetComponent<CommandControlledBot>().enabled = false;
		MyRigidBody.velocity = Vector3.zero;
	}

	public void EnablePortalMovement() {
		MyNavMeshAgent.enabled = true;
		MyNavMeshAgent.isStopped = false;
		MyCollider.isTrigger = false;
		MyNavMeshAgent.Warp(transform.position);
		GetComponent<CommandControlledBot>().enabled = true;
		GetComponent<CommandControlledBot>().StartPlay();
	}

	public void ReduceSpeed(float p_reduceValue = 0f) {
		moveSpeed -= p_reduceValue;
		moveSpeed = Mathf.Clamp(moveSpeed, 2f, 20f);
	}

	public void IncreaseSpeed(float p_reduceValue = 0f) {
		moveSpeed += p_reduceValue;
		moveSpeed = Mathf.Clamp(moveSpeed, 2f, 20f);
	}
	private void Update() {
		if (Keyboard.current.leftArrowKey.isPressed) {
			ReduceSpeed(0.15f);
		}
		if (Keyboard.current.rightArrowKey.isPressed) {
			IncreaseSpeed(0.15f);
		}
		if (Keyboard.current.upArrowKey.isPressed) {
			moveSpeed = m_initialSpeed;
		}
	}
}
