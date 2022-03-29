using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
public class EnemyProgressBar : MonoBehaviour
{
    public Image imgDistanceProgressBar;
    public Transform enemyTransform;
    public Transform playerTransform;

    public static Action OnCaptured;

    private void Update() {
        if (Vector3.Distance(playerTransform.position, enemyTransform.position) < 15f) {
            ShowCircularProgressBar();
            float fillAmount = 4f / Vector3.Distance(playerTransform.position, enemyTransform.position);
            fillAmount = Mathf.Clamp(fillAmount, 0f, 1f);
            UpdateNearProgressBarValue(fillAmount);
            PlayerAnimator.isNearEnemy = true;
            if (fillAmount >= 1f) {
                OnCaptured?.Invoke();
            }
        } else {
            HideCircularProgressBar();
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