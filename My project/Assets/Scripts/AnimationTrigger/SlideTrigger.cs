using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTrigger : AnimationTrigger
{
	public override void DoInputForPlayer(PlayerInput p_input) {
		if (playCutsceneCamera) {
			p_input.pressSlideFromTrigger = true;
			p_input.GetComponent<CutSceneCamera>().DoCutSceneCameraForJump();
		}
	}
}
