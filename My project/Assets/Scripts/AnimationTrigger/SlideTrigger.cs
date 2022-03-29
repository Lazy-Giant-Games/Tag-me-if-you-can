using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTrigger : AnimationTrigger
{
	public float timer;
	public override void DoInputForPlayer(PlayerInput p_input) {
		if (playCutsceneCamera) {
			p_input.pressSlideFromTrigger = true;
			p_input.GetComponent<CutSceneCamera>().DoCutSceneCameraForSlide(p_input.transform);
			p_input.animator.SlideOffAfterSec(timer);
		}
	}
}
