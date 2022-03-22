using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		PlayerInput pi = other.GetComponent<PlayerInput>();
		if (pi != null && pi.isPlayer) {
			DoInputForPlayer(pi);
		}
	}

	public virtual void DoInputForPlayer(PlayerInput p_input) { 
		
	}
	
}
