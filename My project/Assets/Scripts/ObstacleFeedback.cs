using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFeedback : MonoBehaviour {
    public ParticleSystem goFeedback;
    public void PlayObstacleFeedback() {
        if (!goFeedback.isPlaying) {
            goFeedback.Play();
        }
        
    }
}