using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTrigger : AnimationTrigger
{
	public float slideTimer = 2f;
	public override void DoInputForPlayer(PlayerInput p_input) {
		p_input.pressSlideFromTrigger = true;
		StartCoroutine(RemoveSlideAfterSomeTime(p_input));
	}
	IEnumerator RemoveSlideAfterSomeTime(PlayerInput p_PlayerInput) {
		yield return new WaitForSeconds(2f);
		p_PlayerInput.pressSlideFromTrigger = false;
	}
}
