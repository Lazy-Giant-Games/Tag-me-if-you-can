using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : AnimationTrigger {

	public float jumpForce = 550f;
	public enum JUMP_ANIMATION { LOW_JUMP = 0, HIGH_JUMP }
	public JUMP_ANIMATION jumpAnimationToPlay;

	public override void DoInputForPlayer(PlayerInput p_input) {
		Debug.LogError("JUMP");
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
		} else {
			p_input.animator.PlayLowJump();
		}
		rb.AddForce((p_input.transform.forward) * jumpForce);
		StartCoroutine(CheckIfGrounded(pc, p_input, rb));

		if (playCutsceneCamera) {
			p_input.GetComponent<CutSceneCamera>().DoCutSceneCameraForJump(pc.transform);
		}
	}

	IEnumerator CheckIfGrounded(PlayerController pc, PlayerInput pi, Rigidbody rb) {
		GroundDetector gd = GameObject.FindObjectOfType<GroundDetector>();
		yield return new WaitForSeconds(0.5f);
		while (!gd.isGrounded) {
			yield return 0;
		}
		pc.enabled = true;
		pi.isPlayer = true;
		rb.useGravity = false;
	}
}