using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class FOVAdjuster : MonoBehaviour {
    private Camera m_camera;

    float m_initialFOV;
    float m_minFOV;
    float m_maxFOV;

    public float factor;
    void Awake() {
        m_camera = Camera.main;
    }

	private void Start() {
        m_initialFOV = m_camera.fieldOfView;
        m_minFOV = m_initialFOV - 30;
        m_maxFOV = m_initialFOV + 30;

    }

	// Update is called once per frame
	void Update() {
        if (Keyboard.current.iKey.isPressed) {
            m_camera.fieldOfView += factor * Time.deltaTime;
            m_camera.fieldOfView = Mathf.Clamp(m_camera.fieldOfView, m_minFOV, m_maxFOV);
        } else if (Keyboard.current.oKey.isPressed) {
            m_camera.fieldOfView -= factor * Time.deltaTime;
            m_camera.fieldOfView = Mathf.Clamp(m_camera.fieldOfView, m_minFOV, m_maxFOV);
        } else {
            m_camera.fieldOfView = Mathf.Lerp(m_camera.fieldOfView, m_initialFOV, 10f * Time.deltaTime);
        }
    }
}
