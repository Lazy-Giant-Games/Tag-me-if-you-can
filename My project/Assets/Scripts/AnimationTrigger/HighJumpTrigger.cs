using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpTrigger : AnimationTrigger {

	public override void DoInputForPlayer(PlayerInput p_input) {
		p_input.pressJumpFromTrigger = true;
		p_input.animator.PlayHighJump();
	}
}