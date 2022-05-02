using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FOVAdjuster : MonoBehaviour {
    private Camera m_camera;

    float m_initialFOV;
    float m_minFOV;
    float m_maxFOV;

    public float m_minFOVDifference = 30;
    public float m_maxFOVDifference = 30;
    public float factor;
    void Awake() {
        m_camera = Camera.main;
    }

	private void Start() {
        m_initialFOV = m_camera.fieldOfView;
        m_minFOV = m_initialFOV - m_minFOVDifference;
        m_maxFOV = m_initialFOV + m_maxFOVDifference;

    }

	// Update is called once per frame
	void Update() {
        if (Input.GetKey(KeyCode.I)) {
            m_camera.fieldOfView += factor * Time.deltaTime;
            m_camera.fieldOfView = Mathf.Clamp(m_camera.fieldOfView, m_minFOV, m_maxFOV);
        } else if (Input.GetKey(KeyCode.O)) {
            m_camera.fieldOfView -= factor * Time.deltaTime;
            m_camera.fieldOfView = Mathf.Clamp(m_camera.fieldOfView, m_minFOV, m_maxFOV);
        } else {
            m_camera.fieldOfView = Mathf.Lerp(m_camera.fieldOfView, m_initialFOV, 10f * Time.deltaTime);
        }
    }
}
