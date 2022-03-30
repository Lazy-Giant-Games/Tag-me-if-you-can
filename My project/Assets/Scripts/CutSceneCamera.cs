using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneCamera : MonoBehaviour {
	public static bool IsOnCutScene { private set; get; }
	public Transform initialPosition;
	public Transform slidePosition;
	public Transform jumpPosition;

	private Vector3 m_initialLocalRotation;

	public GroundDetector droundDetector;
	private void Start() {
		m_initialLocalRotation = Camera.main.transform.localEulerAngles;
	}
	public void DoCutSceneCameraForSlide(Transform p_targetLook) {
		Debug.LogError("SLIDE");
		IsOnCutScene = true;
		Time.timeScale = 1f;
		PlayerController pc = GameObject.FindObjectOfType<PlayerController>();
		//LeanTween.rotate(Camera.main.gameObject, pc.transform.position - Camera.main.transform.position, 1f);
		LeanTween.moveLocal(Camera.main.gameObject, slidePosition.localPosition, 0.25f).setOnComplete(() => {
			StartCoroutine(WaitTilGrounded(p_targetLook, false, true));
		});
	}

	IEnumerator WaitTilGrounded(Transform p_targetLook, bool p_playRoll = true, bool p_dontCheckGrounded = false) {
		
		yield return new WaitForSeconds(0.1f);
		if (!p_dontCheckGrounded) {
			while (!droundDetector.isGrounded) {
				Camera.main.transform.LookAt(p_targetLook);
				yield return 0f;
			}
		} else {
			float timer = 0f;
			while (timer < 1.5f) {
				timer += Time.deltaTime;
				Camera.main.transform.LookAt(p_targetLook);
				yield return 0f;
			}
		}
		
		if (p_playRoll) {
			Debug.LogError("THIS");
			p_targetLook.GetComponent<PlayerController>().animator.PlayRoll();
		}
		
		LeanTween.moveLocal(Camera.main.gameObject, initialPosition.localPosition, 1f).setIgnoreTimeScale(true);
		LeanTween.rotateLocal(Camera.main.gameObject, m_initialLocalRotation, 1f).setIgnoreTimeScale(true);
		Time.timeScale = 1f;
		IsOnCutScene = false;
	}

	public void DoCutSceneCameraForJump(Transform p_targetLook, bool p_doRollJump = true) {
		Debug.LogError("JUMP");
		IsOnCutScene = true;
		Time.timeScale = 1f;
		PlayerController pc = GameObject.FindObjectOfType<PlayerController>();
		//LeanTween.rotate(Camera.main.gameObject, pc.transform.position - Camera.main.transform.position, 1f);
		LeanTween.moveLocal(Camera.main.gameObject, jumpPosition.localPosition, 0.25f).setOnComplete(() => {
			StartCoroutine(WaitTilGrounded(p_targetLook, p_doRollJump));
		});
	}
}
