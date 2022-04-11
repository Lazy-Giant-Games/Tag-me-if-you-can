using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneCamera : MonoBehaviour {
	public static bool IsOnCutScene { private set; get; }
	public Transform initialPosition;
	public Transform slidePosition;
	public Transform jumpPosition;
	public Transform cutscenePosition;

	private Vector3 m_initialLocalRotation;

	public GroundDetector droundDetector;

	Vector3 m_initialPos;

	public static CutSceneCamera Instance = null;

	public Camera cutSceneCamera;
	private void OnEnable() {
		if (Instance == null) {
			Instance = this;
		}
	}

	private void OnDisable() {
		if (Instance == this) {
			Instance = null;
		}
	}
	private void Start() {
		m_initialLocalRotation = Camera.main.transform.localEulerAngles;
		m_initialPos = Camera.main.transform.position;
		//Camera.main.enabled = false;
		cutSceneCamera.enabled = true;
		//Camera.main.transform.position = cutscenePosition.position;
	}
	IEnumerator WaitTilGrounded(Transform p_targetLook, PlayerInput p_pi, bool p_dontCheckGrounded = false) {

		yield return new WaitForSeconds(0.1f);
		if (!p_dontCheckGrounded) {
			while (!droundDetector.isGrounded) {
				Camera.main.transform.LookAt(p_targetLook);
				yield return 0f;
			}
		} else {
			float timer = 0f;
			while (timer < 0.5f) {
				timer += Time.deltaTime;
				Camera.main.transform.LookAt(p_targetLook);
				yield return 0f;
			}
		}

		LeanTween.moveLocal(Camera.main.gameObject, initialPosition.localPosition, 1f).setIgnoreTimeScale(true).setOnComplete(() => p_pi.animator.forceDontShowFakeHands = false);
		LeanTween.rotateLocal(Camera.main.gameObject, m_initialLocalRotation, 1f).setIgnoreTimeScale(true);
		Time.timeScale = 1f;
		IsOnCutScene = false;
	}

	public void DoCutSceneCameraForSlide(Transform p_controller, PlayerInput p_pi) {
		Debug.LogError("SLIDE");
		IsOnCutScene = true;
		Time.timeScale = 1f;
		p_pi.animator.forceDontShowFakeHands = true;
		//LeanTween.rotate(Camera.main.gameObject, pc.transform.position - Camera.main.transform.position, 1f);
		LeanTween.moveLocal(Camera.main.gameObject, slidePosition.localPosition, 0.25f).setOnComplete(() => {
			StartCoroutine(WaitTilGrounded(p_controller.transform, p_pi, true));
		});
	}
	public void DoCutSceneCameraForJump(PlayerController p_controller, PlayerInput p_pi) {
		Debug.LogError("JUMP");
		IsOnCutScene = true;
		Time.timeScale = 1f;
		p_pi.animator.forceDontShowFakeHands = true;
		//LeanTween.rotate(Camera.main.gameObject, pc.transform.position - Camera.main.transform.position, 1f);
		LeanTween.moveLocal(Camera.main.gameObject, jumpPosition.localPosition, 0.25f).setOnComplete(() => {
			StartCoroutine(WaitTilGrounded(p_controller.transform, p_pi));
		});
	}

	public void GoToFPSCamera() {
		//Camera.main.transform.position = m_initialPos;
		//Camera.main.transform.localEulerAngles = m_initialLocalRotation;
		LeanTween.move(cutSceneCamera.gameObject, Camera.main.transform.position, 0.45f).setOnComplete(() => {
			//Camera.main.enabled = true;
			cutSceneCamera.enabled = false;
		});
		//LeanTween.rotateLocal(Camera.main.gameObject, m_initialLocalRotation, 0.25f);
	}
}