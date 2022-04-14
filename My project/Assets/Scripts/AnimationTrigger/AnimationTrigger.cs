using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour {

	public bool playCutsceneCamera;
	private void OnTriggerEnter(Collider other) {
		PlayerInput pi = other.GetComponent<PlayerInput>();
		if (pi != null) {
			DoInputForPlayer(pi);
		}
	}

	public virtual void DoInputForPlayer(PlayerInput p_input) { 
		
	}

	public virtual void DoInputForAI(PlayerInput p_input) { 
		
	}
	
}
