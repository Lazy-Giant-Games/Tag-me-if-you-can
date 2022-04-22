using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
public class EnemyProgressBar : MonoBehaviour
{
    public Image imgDistanceProgressBar;
    public Transform enemyTransform;
    public Transform playerTransform;
    public Text textDistance;
    public static Action OnCaptured;
    public AIMovement aiMovement;

    public float distanceChecker = 10f;
    private bool m_captured;
    private void Update() {
        float fillAmount = 4f / Vector3.Distance(playerTransform.position, enemyTransform.position);
        fillAmount = Mathf.Clamp(fillAmount, 0f, 1f);

        textDistance.text = ((100f - (fillAmount * 100f)) / 4f).ToString("0") + "m";
        if (Vector3.Distance(playerTransform.position, enemyTransform.position) < distanceChecker) {
            PlayerAnimator.isNearEnemy = true;
            if (fillAmount >= 1f && !m_captured && distanceChecker > 0f) {
                m_captured = true;
                OnCaptured?.Invoke();
                aiMovement.SetCaptured();
                
            }
        } else {
            PlayerAnimator.isNearEnemy = false;
        }
    }

    public void HideCircularProgressBar() {
        if (imgDistanceProgressBar.transform.parent.gameObject.activeSelf) {
            imgDistanceProgressBar.transform.parent.gameObject.SetActive(false);
        }
    }
    public void ShowCircularProgressBar() {
        if (!imgDistanceProgressBar.transform.parent.gameObject.activeSelf) {
            imgDistanceProgressBar.transform.parent.gameObject.SetActive(true);
        }
    }

    public void UpdateNearProgressBarValue(float p_value) {
        imgDistanceProgressBar.fillAmount = p_value;
    }
}