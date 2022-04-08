using System.Collections;
using System;
using UnityEngine;

public class AIAnimationSequence : MonoBehaviour {

    public Animator animator;

    public Action onTurnDone; 
    public void PlayShock() {
        animator.SetTrigger("trigShock");
    }

    public void OnTurnDone() {
        onTurnDone?.Invoke();
    }
}
