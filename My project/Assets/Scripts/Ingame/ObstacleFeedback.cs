using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFeedback : MonoBehaviour {
    public ParticleSystem goFeedback;

    public Vector3 localPos;
	private void Start() {
        //PlayObstacleFeedback();
        StartCoroutine(DelayedGoToPosition());
    }

    IEnumerator DelayedGoToPosition() {
        yield return new WaitForSeconds(1.25f);

        goFeedback.gameObject.transform.localPosition = localPos;
    }
	public void PlayObstacleFeedback() {
        if (!goFeedback.isPlaying) {
            goFeedback.Play();
        }
        
    }
}