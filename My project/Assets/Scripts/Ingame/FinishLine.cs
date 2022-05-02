using System.Collections;
using System;
using UnityEngine;

public class FinishLine : MonoBehaviour {

    public static Action OnFinishLineReached;
	private void OnTriggerEnter(Collider other) {
		if (other.GetComponent<PlayerController>() != null) {
			OnFinishLineReached?.Invoke();
		}
	}
}
