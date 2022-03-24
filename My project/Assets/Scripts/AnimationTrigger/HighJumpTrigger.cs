using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpTrigger : AnimationTrigger {

	public float jumpForce = 550f;
	public override void DoInputForPlayer(PlayerInput p_input) {
		p_input.pressJumpFromTrigger = true;
		p_input.isPlayer = false;
		PlayerController pc = p_input.GetComponent<PlayerController>();
		pc.enabled = false;
		Rigidbody rb = p_input.GetComponent<Rigidbody>();
		rb.Sleep();
		rb.velocity = Vector3.zero;
		rb.isKinematic = false;
		rb.useGravity = true;
		p_input.animator.PlayHighJump();

		rb.AddForce(p_input.transform.forward * jumpForce);
		StartCoroutine(CheckIfGrounded(pc, p_input, rb));
	}

	IEnumerator CheckIfGrounded(PlayerController pc, PlayerInput pi, Rigidbody rb) {
		GroundDetector gd = GameObject.FindObjectOfType<GroundDetector>();
		yield return new WaitForSeconds(0.5f);
		while (!gd.isGrounded) {
			Debug.LogError(gd.isGrounded);
			yield return 0;
		}
		Debug.LogError(gd.isGrounded);
		pc.enabled = true;
		pi.isPlayer = true;
		rb.useGravity = false;
	}
}