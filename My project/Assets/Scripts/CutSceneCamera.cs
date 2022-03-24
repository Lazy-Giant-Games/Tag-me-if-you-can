using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneCamera : MonoBehaviour {
	public Transform initialPosition;
	public Transform slidePosition;
	public Transform jumpPosition;

	private Vector3 m_initialLocalRotation;

	private void Start() {
		m_initialLocalRotation = Camera.main.transform.localEulerAngles;
	}
	public void DoCutSceneCameraForSlide() {
		PlayerController pc = GameObject.FindObjectOfType<PlayerController>();
		LeanTween.rotate(Camera.main.gameObject, pc.transform.position - Camera.main.transform.position, 1f);
		LeanTween.move(Camera.main.gameObject, slidePosition.position, 1f).setOnComplete(() => {
			LeanTween.move(Camera.main.gameObject, initialPosition.position, 1f);
			LeanTween.rotateLocal(Camera.main.gameObject, m_initialLocalRotation, 1f);
		});
	}

	public void DoCutSceneCameraForJump() {
		PlayerController pc = GameObject.FindObjectOfType<PlayerController>();
		LeanTween.rotate(Camera.main.gameObject, pc.transform.position - Camera.main.transform.position, 1f);
		LeanTween.moveLocal(Camera.main.gameObject, jumpPosition.localPosition, 1f).setOnComplete(() => {
			LeanTween.moveLocal(Camera.main.gameObject, initialPosition.localPosition, 1f);
			LeanTween.rotateLocal(Camera.main.gameObject, m_initialLocalRotation, 1f);
		});
	}
}
