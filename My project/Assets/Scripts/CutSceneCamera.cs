using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneCamera : MonoBehaviour {
	public Transform initialPosition;
	public Transform slidePosition;
	public Transform jumpPosition;

	private Vector3 m_initialLocalRotation;

	public GroundDetector droundDetector;
	private void Start() {
		m_initialLocalRotation = Camera.main.transform.localEulerAngles;
	}
	public void DoCutSceneCameraForSlide() {
		Time.timeScale = 0.5f;
		PlayerController pc = GameObject.FindObjectOfType<PlayerController>();
		LeanTween.rotate(Camera.main.gameObject, pc.transform.position - Camera.main.transform.position, 1f);
		LeanTween.moveLocal(Camera.main.gameObject, slidePosition.position, 1f).setOnComplete(() => {
			GetComponent<Rigidbody>().useGravity = true;
			StartCoroutine(WaitTilGrounded());
		});
	}

	IEnumerator WaitTilGrounded() {
		
		yield return new WaitForSeconds(0.1f);
		while (!droundDetector.isGrounded) {
			yield return 0f;
		}
		GetComponent<Rigidbody>().useGravity = true;
		LeanTween.moveLocal(Camera.main.gameObject, initialPosition.localPosition, 1.5f).setIgnoreTimeScale(true);
		LeanTween.rotateLocal(Camera.main.gameObject, m_initialLocalRotation, 1.5f).setIgnoreTimeScale(true);
		Time.timeScale = 1f;
	}

	public void DoCutSceneCameraForJump() {
		Time.timeScale = 0.5f;
		PlayerController pc = GameObject.FindObjectOfType<PlayerController>();
		LeanTween.rotate(Camera.main.gameObject, pc.transform.position - Camera.main.transform.position, 1f);
		LeanTween.moveLocal(Camera.main.gameObject, jumpPosition.localPosition, 1f).setOnComplete(() => {
			StartCoroutine(WaitTilGrounded());
		});
	}
}
