using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : AnimationTrigger {

	public float jumpForceForward = 225f;
	public float jumpForceUpward = 225f;
	public enum JUMP_ANIMATION { LOW_JUMP = 0, HIGH_JUMP }
	public JUMP_ANIMATION jumpAnimationToPlay;

	private bool m_doRoll;
	public override void DoInputForPlayer(PlayerInput p_input) {
		//Debug.LogError("JUMP");
		p_input.pressJumpFromTrigger = true;
		p_input.isPlayer = false;
		PlayerController pc = p_input.GetComponent<PlayerController>();
		pc.enabled = false;
		Rigidbody rb = p_input.GetComponent<Rigidbody>();
		rb.Sleep();
		rb.velocity = Vector3.zero;
		rb.isKinematic = false;
		rb.useGravity = true;
		if (jumpAnimationToPlay == JUMP_ANIMATION.HIGH_JUMP) {
			p_input.animator.PlayHighJump();
			m_doRoll = true;
			if (playCutsceneCamera) {
				p_input.GetComponent<CutSceneCamera>().DoCutSceneCameraForJump(pc, p_input);
			}
		} else {
			p_input.animator.PlayLowJump();
			m_doRoll = false;
			if (playCutsceneCamera) {
				p_input.GetComponent<CutSceneCamera>().DoCutSceneCameraForJump(pc, p_input);
			}
		}
		rb.AddForce(((p_input.transform.forward) * jumpForceForward+ ((p_input.transform.up) * jumpForceUpward)));
		StartCoroutine(CheckIfGrounded(pc, p_input, rb));
	}

	IEnumerator CheckIfGrounded(PlayerController pc, PlayerInput pi, Rigidbody rb) {
		//pi.animator.forceDontShowFakeHands = true;
		GroundDetector gd = pc.GetComponentInChildren<GroundDetector>();
		yield return new WaitForSeconds(0.05f);
		while (!gd.isGrounded) {
			yield return 0;
		}
		if (m_doRoll) {
			pc.animator.PlayRoll();
		}
		
		pc.enabled = true;
		pi.isPlayer = true;
		rb.useGravity = false;
		//pi.animator.forceDontShowFakeHands = false;
	}

	public override void DoInputForAI(PlayerInput p_input) {
		//Debug.LogError("JUMP");
		p_input.pressJumpFromTrigger = true;
		p_input.isPlayer = false;
		PlayerController pc = p_input.GetComponent<PlayerController>();
		pc.enabled = false;
		Rigidbody rb = p_input.GetComponent<Rigidbody>();
		rb.Sleep();
		rb.velocity = Vector3.zero;
		rb.isKinematic = false;
		rb.useGravity = true;
		if (jumpAnimationToPlay == JUMP_ANIMATION.HIGH_JUMP) {
			p_input.animator.PlayHighJump();
			/*if (playCutsceneCamera) {
				p_input.GetComponent<CutSceneCamera>().DoCutSceneCameraForJump(pc.transform);
			}*/
		} else {
			p_input.animator.PlayLowJump();
			/*if (playCutsceneCamera) {
				p_input.GetComponent<CutSceneCamera>().DoCutSceneCameraForJump(pc.transform, false);
			}*/
		}
		rb.AddForce(((p_input.transform.forward) * jumpForceForward + ((p_input.transform.up) * jumpForceUpward)));
		StartCoroutine(CheckIfGrounded(pc, p_input, rb));
	}
}