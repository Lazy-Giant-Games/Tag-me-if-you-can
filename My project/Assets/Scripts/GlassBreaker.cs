using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreaker : MonoBehaviour {
    public ParticleSystem goGlassVFX1;
    public ParticleSystem goGlassVFX2;

    public void PlayGlassVFX() {
        goGlassVFX1.Play();
        goGlassVFX2.Play();
        goGlassVFX1.GetComponent<AudioSource>().Play();
        goGlassVFX2.GetComponent<AudioSource>().Play();
    }

	private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "ShatterableGlass") {
            Destroy(collision.gameObject);
            PlayGlassVFX();
        }
	}
}